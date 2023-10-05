using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeadManagementSystem.Models;

namespace LeadManagementSystem.Controllers
{
    public class SalesPersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesPersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesPerson
        [Route("Home/SalesPerson")]
        public IActionResult Index()
        {
             List<SalesPerson> salesPeople = _context.SalesPeople.ToList();
            return View(salesPeople);
        }

        // GET: SalesPerson/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesPerson/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SalesPerson salesPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesPerson);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(salesPerson);
        }

        // GET: SalesPerson/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesPerson salesPerson = _context.SalesPeople.FirstOrDefault(s => s.Id == id);

            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // POST: SalesPerson/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SalesPerson salesPerson)
        {
            if (id != salesPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesPerson);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesPersonExists(salesPerson.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(salesPerson);
        }

        // GET: SalesPerson/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesPerson salesPerson = _context.SalesPeople.FirstOrDefault(s => s.Id == id);

            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // POST: SalesPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            SalesPerson salesPerson = _context.SalesPeople.FirstOrDefault(s => s.Id == id);

            if (salesPerson == null)
            {
                return NotFound();
            }

            _context.SalesPeople.Remove(salesPerson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
     

        private bool SalesPersonExists(int id)
        {
            return _context.SalesPeople.Any(s => s.Id == id);
        }
    }
}
