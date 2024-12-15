using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        ShelterContext shelterContext = new ShelterContext();
        [HttpGet("GetCountriesList")]
        public IActionResult GetCountriesList()
        {
            return Ok(shelterContext.Countries.ToList());
        }
    }
}
