namespace AddressBook.Data.Person
{
  public class PersonFilters
  {
    public int Page { get; set; }
    public int TakeAmount { get; set; }
    public PersonSortableColumn Column { get; set; }
    public bool IsAscending { get; set; }
  }
}