namespace AddressBook.Data.Person
{
  public class PersonRecord
  {
    public string PersonId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTimeOffset CreationTime { get; set; }
    public DateTimeOffset? LastUpdatedTime { get; set; }
  }
}
