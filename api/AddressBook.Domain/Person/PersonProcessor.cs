using AddressBook.Data.Address;
using AddressBook.Data.Person;
using AddressBook.Utils.DependencyInjection;

namespace AddressBook.Domain.Person
{
  [InjectTransient]
  public class PersonProcessor
  {
    private readonly IReadPersons _readPersons;
    private readonly ICreatePersons _createPersons;
    private readonly IReadAddresses _readAddresses;

    public PersonProcessor(
      IReadPersons readPersons,
      ICreatePersons createPersons,
      IReadAddresses readAddresses)
    {
      _readPersons = readPersons ?? throw new ArgumentNullException(nameof(readPersons));
      _createPersons = createPersons ?? throw new ArgumentNullException(nameof(createPersons));
      _readAddresses = readAddresses ?? throw new ArgumentNullException(nameof(readAddresses));
    }

    public Task<IEnumerable<PersonDto>> GetPersonsAsync()
    {
      return SearchPersonsAsync(new PersonFilters
      {
        Column = PersonSortableColumn.LastName,
        IsAscending = true,
        Page = 1,
        TakeAmount = 10
      });
    }

    public async Task<PersonDto> CreatePersonAsync(PersonNewPersonDto newPerson)
    {
      var person = await _createPersons.InsertPersonAsync(new PersonRecord
      {
        FirstName = newPerson.FirstName,
        LastName = newPerson.LastName,
        CreationTime = DateTimeOffset.UtcNow,
        LastUpdatedTime = null,
      });

      return new PersonDto
      {
        FirstName = person.FirstName,
        LastName = person.LastName,
        PersonId = person.PersonId,
        AddressCount = "0",
      };
    }

    private async Task<IEnumerable<PersonDto>> SearchPersonsAsync(PersonFilters filters)
    {
      var results = await _readPersons.GetPersonsAsync(filters);
      var addressesForPeople = await _readAddresses.GetAddressesForPeopleAsync(results.Select(x => x.PersonId));

      return results.Select(person => new PersonDto
      {
        FirstName = person.FirstName,
        LastName = person.LastName,
        PersonId = person.PersonId,
        AddressCount = addressesForPeople.Count(address => address.PersonID == person.PersonId).ToString(),
      });
    }
  }
}
