namespace AddressBook.Data.Address
{
  public class AddressRecord
  {
    public string AddressID { get; set; } = string.Empty;
    public string PersonID { get; init; } = string.Empty;
    public string Address1 { get; init; } = string.Empty;
    public string Address2 { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public bool IsDefault { get; init; } = false;
    public DateTimeOffset CreationTime { get; set; }
    public DateTimeOffset? LastUpdatedTime { get; set; }
  }
}