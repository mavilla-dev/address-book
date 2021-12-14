namespace AddressBook.Data.Address
{
  public interface IReadAddresses
  {
    Task<IEnumerable<AddressRecord>> GetAddressesForPersonAsync(string personId);
    Task<IEnumerable<AddressRecord>> GetAddressesForPeopleAsync(IEnumerable<string> personIds);
  }
}