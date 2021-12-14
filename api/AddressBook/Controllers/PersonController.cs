using AddressBook.Domain.Person;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddressBook.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PersonController : ControllerBase
  {
    [HttpGet]
    public Task<IEnumerable<PersonDto>> Get(
      [FromServices] PersonProcessor processor)
      => processor.GetPersonsAsync();

    [HttpPost]
    public Task<PersonDto> Post(
      [FromBody] PersonNewPersonDto newPerson,
      [FromServices] PersonProcessor processor)
      => processor.CreatePersonAsync(newPerson);
  }
}
