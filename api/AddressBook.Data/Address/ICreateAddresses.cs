namespace AddressBook.Data.Address
{
  public interface ICreateAddresses
  {
    Task<AddressRecord> CreateAddressAsync(AddressRecord addressRecord);
  }
}