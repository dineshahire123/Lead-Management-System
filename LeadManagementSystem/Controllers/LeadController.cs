using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeadManagementSystem.Models;
using System.Linq;
using System.Threading.Tasks;


namespace LeadManagementSystem.Controllers
{
    public class LeadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lead
        [Route("Home/Lead")]
        public async Task<IActionResult> Index()
        {
            var leads = await _context.Leads.ToListAsync();
            return View(leads);
        }

        // GET: Lead/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Leads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lead == null)
            {
                return NotFound();
            }

            return View(lead);
        }

        // GET: Lead/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lead/Create
     [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Name,Organization,Email,Phone,Source")] Lead lead)
{
    try
    {
       
            _context.Add(lead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
    }
    catch (Exception ex)
    {
    
        Console.WriteLine(ex.ToString());

        // Handle the exception gracefully, e.g., return an error view
        return View("Error");
    }
}

        // GET: Lead/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
            {
                return NotFound();
            }
            return View(lead);
        }



         // POST: Lead/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Lead lead)
        {
            if (id != lead.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(lead);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadExists(lead.Id))
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

        // GET: Lead/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lead lead = _context.Leads.FirstOrDefault(s => s.Id == id);

            if (lead == null)
            {
                return NotFound();
            }

            return View(lead);
        }



  [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Lead lead = _context.Leads.FirstOrDefault(s => s.Id == id);

            if (lead == null)
            {
                return NotFound();
            }

            _context.Leads.Remove(lead);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    private bool LeadExists(int id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
