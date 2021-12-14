using AddressBook.Data.Address;
using AddressBook.Data.Person;
using AddressBook.Utils.DependencyInjection;

namespace AddressBook.Domain.Address
{
  [InjectTransient]
  public class AddressProcessor
  {
    private readonly IReadAddresses _readAddresses;
    private readonly ICreateAddresses _createAddresses;
    private readonly IReadPersons _readPersons;

    public AddressProcessor(
      IReadAddresses readAddresses,
      ICreateAddresses createAddresses,
      IReadPersons readPersons)
    {
      _readAddresses = readAddresses ?? throw new ArgumentNullException(nameof(readAddresses));
      _createAddresses = createAddresses ?? throw new ArgumentNullException(nameof(createAddresses));
      _readPersons = readPersons ?? throw new ArgumentNullException(nameof(readPersons));
    }

    public async Task<AddressListDto> GetAddressesForPersonAsync(string personId)
    {
      var person = await _readPersons.GetPersonAsync(personId);
      if (person == null)
      {
        throw new InvalidOperationException("Cannot create address for a person that does not exist");
      }

      var addressesForPerson = await _readAddresses.GetAddressesForPersonAsync(personId);
      return new AddressListDto
      {
        Addresses = addressesForPerson.Select(address => new AddressDto
        {
          Address1 = address.Address1,
          Address2 = address.Address2,
          AddressID = address.AddressID,
          City = address.City,
          IsDefault = address.IsDefault ? "Yes" : "No",
          PostalCode = address.PostalCode,
          State = address.State,
        }),
        PersonFirstName = person.FirstName,
        PersonId = person.PersonId,
        PersonLastName = person.LastName,
      };
    }

    public async Task<AddressDto> CreateAddressForPersonAsync(string personId, AddressNewAddressDto addressDto)
    {
      var doesPersonExist = await _readPersons.DoesPersonExistAsync(personId);
      if (!doesPersonExist)
      {
        throw new InvalidOperationException("Cannot create address for a person that does not exist");
      }

      var newAddres = await _createAddresses.CreateAddressAsync(new AddressRecord
      {
        Address1 = addressDto.Address1,
        Address2 = addressDto.Address2,
        City = addressDto.City,
        CreationTime = DateTimeOffset.UtcNow,
        IsDefault = addressDto.IsDefault,
        LastUpdatedTime = null,
        PersonID = personId,
      });

      return new AddressDto
      {
        Address1 = newAddres.Address1,
        Address2 = newAddres.Address2,
        AddressID = newAddres.AddressID,
        City = newAddres.City,
        IsDefault = newAddres.IsDefault ? "Yes" : "No",
        PostalCode = newAddres.PostalCode,
        State = newAddres.State,
      };
    }
  }
}
