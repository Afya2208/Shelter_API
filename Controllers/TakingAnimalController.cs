using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;
using WebApplication2.Entities.shorts;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route()]
    public class TakingAnimalController : Controller
    {
        ShelterContext context = new ShelterContext();

        [HttpGet("GetList")]
        public async Task<ActionResult> GetList()
        {
            return Ok(await context.TakingAnimals.ToListAsync());
        }
        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            TakingAnimal? doc = context.TakingAnimals.FirstOrDefault(d=> d.TakingAnimalId == id);
            if (doc == null)
            {
                return Ok();
            }
            else
            {
                try
                {
                    context.TakingAnimals.Remove(doc);
                    context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }
        }
        [HttpPost("Add")]
        public ActionResult Add(TakingAnimalShort @short)
        {
            TakingAnimal takingAnimal = new TakingAnimal(@short);
            try
            {
                context.TakingAnimals.Add(takingAnimal);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public ActionResult Update(int id, TakingAnimalShort @short)
        {
            TakingAnimal? takingAnimal = context.TakingAnimals.FirstOrDefault(ta => ta.TakingAnimalId == id);
            if (takingAnimal == null)
            {
                return NotFound("Такого договора нет");
            }
            try
            {
                takingAnimal.DateOfTaking = @short.DateOfTaking;
                takingAnimal.AnimalId = @short.AnimalId;
                takingAnimal.ClientId = @short.ClientId;
                context.TakingAnimals.Update(takingAnimal);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

    }
}
