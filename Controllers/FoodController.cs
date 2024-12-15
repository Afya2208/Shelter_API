using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : Controller
    {
        ShelterContext shelterContext = new ShelterContext();
        [HttpGet("GetList")]
        public ActionResult GetList()
        {
            return Ok(shelterContext.Foods.ToList());
        }
    }
}
