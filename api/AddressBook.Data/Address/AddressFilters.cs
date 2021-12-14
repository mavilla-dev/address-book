namespace AddressBook.Data.Address
{
  public class AddressFilters
  {
    public AddressSortableColumn Column { get; set; }
    public bool IsAscending { get; set; }
    public int Page { get; set; }
    public int TakeAmount { get; set; }
  }
}
