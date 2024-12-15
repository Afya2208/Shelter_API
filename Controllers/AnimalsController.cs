﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : Controller
    {
        private readonly ShelterContext context = new ShelterContext();

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            return Ok(context.Animals.ToList());
        }

        //public AnimalsController(ShelterContext context)
        //{
        //    _context = context;
        //}

        //// GET: Animals
        //public async Task<IActionResult> Index()
        //{
        //    var shelterContext = _context.Animals.Include(a => a.Breed).Include(a => a.GenderCodeNavigation);
        //    return View(await shelterContext.ToListAsync());
        //}

        //// GET: Animals/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var animal = await _context.Animals
        //        .Include(a => a.Breed)
        //        .Include(a => a.GenderCodeNavigation)
        //        .FirstOrDefaultAsync(m => m.AnimalId == id);
        //    if (animal == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(animal);
        //}

        //// GET: Animals/Create
        //public IActionResult Create()
        //{
        //    ViewData["BreedId"] = new SelectList(_context.Breeds, "BreedId", "BreedId");
        //    ViewData["GenderCode"] = new SelectList(_context.Genders, "GenderCode", "GenderCode");
        //    return View();
        //}

        //// POST: Animals/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AnimalId,Name,GenderCode,DateOfArrival,BreedId")] Animal animal)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(animal);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["BreedId"] = new SelectList(_context.Breeds, "BreedId", "BreedId", animal.BreedId);
        //    ViewData["GenderCode"] = new SelectList(_context.Genders, "GenderCode", "GenderCode", animal.GenderCode);
        //    return View(animal);
        //}

        //// GET: Animals/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var animal = await _context.Animals.FindAsync(id);
        //    if (animal == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["BreedId"] = new SelectList(_context.Breeds, "BreedId", "BreedId", animal.BreedId);
        //    ViewData["GenderCode"] = new SelectList(_context.Genders, "GenderCode", "GenderCode", animal.GenderCode);
        //    return View(animal);
        //}

        //// POST: Animals/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("AnimalId,Name,GenderCode,DateOfArrival,BreedId")] Animal animal)
        //{
        //    if (id != animal.AnimalId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(animal);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AnimalExists(animal.AnimalId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["BreedId"] = new SelectList(_context.Breeds, "BreedId", "BreedId", animal.BreedId);
        //    ViewData["GenderCode"] = new SelectList(_context.Genders, "GenderCode", "GenderCode", animal.GenderCode);
        //    return View(animal);
        //}

        //// GET: Animals/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var animal = await _context.Animals
        //        .Include(a => a.Breed)
        //        .Include(a => a.GenderCodeNavigation)
        //        .FirstOrDefaultAsync(m => m.AnimalId == id);
        //    if (animal == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(animal);
        //}

        //// POST: Animals/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var animal = await _context.Animals.FindAsync(id);
        //    if (animal != null)
        //    {
        //        _context.Animals.Remove(animal);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AnimalExists(int id)
        //{
        //    return _context.Animals.Any(e => e.AnimalId == id);
        //}
    }
}
