using AddressBook.Domain.Address;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AddressController : ControllerBase
  {
    [HttpGet("{personId}")]
    public Task<AddressListDto> Get(
      [FromRoute] string personId,
      [FromServices] AddressProcessor processor)
      => processor.GetAddressesForPersonAsync(personId);

    [HttpPost("{personId}")]
    public Task<AddressDto> Post(
      [FromRoute] string personId,
      [FromBody] AddressNewAddressDto addressDto,
      [FromServices] AddressProcessor processor)
      => processor.CreateAddressForPersonAsync(personId, addressDto);
  }
}
