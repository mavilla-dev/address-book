namespace AddressBook.Domain.Address
{
  public class AddressDto
  {
    public string AddressID { get; set; } = string.Empty;
    public string Address1 { get; init; } = string.Empty;
    public string Address2 { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public string IsDefault { get; init; } = string.Empty;
  }
}