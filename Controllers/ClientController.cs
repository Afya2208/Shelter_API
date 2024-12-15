using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;
using WebApplication2.Entities.shorts;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        ShelterContext ShelterContext = new ShelterContext();
        [HttpGet("Clients")]
        public async Task<IActionResult> GetClientsList()
        {
            return Ok(await ShelterContext.Clients.ToListAsync());
        }
        [HttpGet("FindClientByLoginAndPassword")]
        public async Task<IActionResult> FindClientByLoginAndPassword(string login, string password)
        {
            Client? client = await ShelterContext.Clients.FirstOrDefaultAsync(cl => cl.Password == password && cl.Login == login);
            if (client == null)
            {
                return NotFound(null);
            }
            else
            {
                return Ok(client);
            }
        }
        [HttpGet("FindClientByLogin")]
        public async Task<IActionResult> FindClientByLogin(string login)
        {
            Client? client = await ShelterContext.Clients.FirstOrDefaultAsync(cl => cl.Login == login);
            if (client == null)
            {
                return NotFound(null);
            }
            else
            {
                return Ok(client);
            }
        }
        [HttpPut("AddPassportData")]
        public async Task<IActionResult> AddPassportData(int id, [FromBody] PassportData passport)
        {
            Client? client = await ShelterContext.Clients.FirstOrDefaultAsync(cl => cl.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    client.AddEditPassportData(passport);
                    ShelterContext.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }
        }
        [HttpGet("FindClientById")]
        public async Task<IActionResult> GetClientById(int id)
        {
            Client? client = await ShelterContext.Clients.FirstOrDefaultAsync(cl => cl.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(client);
            }
        }
        [HttpDelete("DeleteClientById")]
        public IActionResult DeleteClientById(int id)
        {
            Client? client = ShelterContext.Clients.FirstOrDefault(cl => cl.ClientId == id);
            if (client == null)
            {
                return NotFound("Как я удалю тебе того, кого нет?!");
            }
            try
            {
                ShelterContext.Clients.Remove(client);
                ShelterContext.SaveChanges();
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
        [HttpPost("CreateClient")]
        public IActionResult NewClient([FromBody] ClientShort clientShort)
        {
            
            try
            {
                Client client = new Client(clientShort);
                ShelterContext.Clients.Add(client);
                ShelterContext.SaveChanges();
                return Ok($"Создался твой клиент, с id={client.ClientId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("FindClientsByText")]
        public IActionResult FindClientsByText(string searchText)
        {
            List<Client> maybeClients = ShelterContext.Clients.Where(cl =>
            cl.FirstName.Contains(searchText)
            || cl.LastName.Contains(searchText)
            || cl.Address.Contains(searchText)
            || cl.Email.Contains(searchText)
            || cl.Phone.Contains(searchText)
            || cl.Phone2.Contains(searchText)
            || cl.Region.Contains(searchText)
            || cl.Serial.Contains(searchText)
            || cl.PostalZip.Contains(searchText)
            || cl.Number.Contains(searchText)
            ).ToList();
            if (maybeClients.Count == 0)
            {
                return NotFound();
            } else
            {
                return Ok(maybeClients);
            }
             
        }
        [HttpPut("ChangeClient")]
        public IActionResult ChangeClient(int id, [FromBody] ClientShort @short)
        {
            Client? client = ShelterContext.Clients.FirstOrDefault(cl => cl.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            
            try
            {
                client.Email = @short.Email;
                client.Phone = @short.Phone;
                client.Region = @short.Region;
                client.PostalZip = @short.PostalZip;
                client.FirstName = @short.FirstName;
                client.LastName = @short.LastName;
                client.Address = @short.Address;
                client.Login = @short.Login;
                client.Password = @short.Password;
                client.CountryId = @short.CountryId;

                ShelterContext.Clients.Update(client);
                ShelterContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "\n" + ex.InnerException?.Message);
            }


        }
        [HttpGet("SortClientsByField")]
        public IActionResult SortClientsByField(string fieldName)
        {
            List<Client> clients = new List<Client>();
            switch (fieldName)
            {
                case "Имя":
                case "FirstName":
                    clients = ShelterContext.Clients.OrderBy(c => c.FirstName).ToList();
                    break;
                case "Фамилия":
                case "LastName":
                    clients = ShelterContext.Clients.OrderBy(c => c.LastName).ToList();
                    break;
                case "Email":
                    clients = ShelterContext.Clients.OrderBy(c => c.Email).ToList();
                    break;
                case "Логин":
                case "Login":
                    clients = ShelterContext.Clients.OrderBy(c => c.Login).ToList();
                    break;
                default:
                    return BadRequest("Такого поля у клиентов нет/такое поле не поддерживается в сортировке");
                    
            }
            return Ok(clients);
        }

        [HttpGet("FilterClientsByCountryId")]
        public IActionResult FilterClientsByCountryId(int cointryId)
        {
            List<Client> maybeClients = ShelterContext.Clients.Where(cl =>
            cl.CountryId == cointryId
            ).ToList();
            if (maybeClients.Count == 0)
            {
                return NotFound("Клиентов с такой страной нет");
            }
            else
            {
               
                return Ok(maybeClients);
            }
            

        }
    }
}
