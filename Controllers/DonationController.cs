using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Entities.shorts;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonationController : Controller
    {
        ShelterContext shelterContext = new ShelterContext();
        [HttpGet("GetList")]
        public ActionResult GetList()
        {
            return Ok(shelterContext.Donations.ToList());
        }
        [HttpPost("Add")]
        public ActionResult Add([FromBody] DonationShort @short)
        {
            Donation donation = new Donation(@short);
            try
            {
                shelterContext.Donations.Add(donation);
                shelterContext.SaveChanges();
                return Ok(donation.DonationId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //// GET: DonationController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: DonationController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: DonationController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DonationController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DonationController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DonationController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DonationController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DonationController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
