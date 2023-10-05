using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeadManagementSystem.Models;

namespace LeadManagementSystem.Controllers
{
    public class LeadActivityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadActivityController(ApplicationDbContext context) 
        {
            _context = context;
        }

        // GET: LeadActivity/Index
        public IActionResult Index()
        {
            List<LeadActivity> activities = _context.LeadActivities.ToList();
            return View(activities);
        }

       
      // POST: LeadActivity/Create
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(LeadActivity leadActivity)
{
    if (ModelState.IsValid)
    {
        // Add the lead activity to the context
        _context.LeadActivities.Add(leadActivity);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    // If the model state is not valid, reload the view with errors
    ViewBag.Leads = new SelectList(_context.Leads.ToList(), "Id", "Name", leadActivity.LeadId);
    return View(leadActivity);
}

  // GET: LeadActivity/Create
        public IActionResult Create()
        {
            return View();
        }

 }
}
