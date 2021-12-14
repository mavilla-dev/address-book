namespace AddressBook.Domain.Address
{
  public class AddressListDto
  {
    public IEnumerable<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    public string PersonId { get; set; } = string.Empty;
    public string PersonFirstName { get; set; } = string.Empty;
    public string PersonLastName { get; set; } = string.Empty;
  }
}
