using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnterpriseProgrammingAssignment.Data;
using EnterpriseProgrammingAssignment.Models;

namespace EnterpriseProgrammingAssignment.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string SortOrder,string SearchParam, string Locations)
        {
            ViewBag.CatSortParm = SortOrder == "Dsc" ? "Asc" : "Dsc";
            var carContext = _context.Cars.Include(c => c.Location);
            var Cars = from cars in _context.Cars.Include(c => c.Location)
                       select cars;
            var LocationList = from l in _context.Cars.Include(C => C.Location)
                               orderby l.Location.ID
                               select l.Location.Address;
            var LocList = new List<string>();
            LocList.AddRange(LocationList.Distinct());
            ViewBag.Locations = new SelectList(LocList);
            if (!String.IsNullOrEmpty(SearchParam))
            {
                Cars = Cars.Where(c => c.Make.Contains(SearchParam));
            }
            if (!String.IsNullOrEmpty(SortOrder))
            {
                switch (SortOrder)
                {
                    case "Asc":
                        Cars = Cars.OrderBy(cars => cars.Category);
                        break;
                    case "Dsc":
                        Cars = Cars.OrderByDescending(cars => cars.Category);
                        break;
                    default:
                        Cars = Cars.OrderBy(cars => cars.ID);
                        break;
                }
            }
            if (!String.IsNullOrEmpty(Locations))
            {
                Cars = Cars.Where(c => c.Location.Address == Locations);
            }

            return View(await Cars.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["SiteID"] = new SelectList(_context.Sites, "ID", "Address");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Make,Model,Category,PurchaseDate,MOTExpDate,TaxExpDate,InsuranceExpDate,SiteID")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiteID"] = new SelectList(_context.Sites, "ID", "Address", car.SiteID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["SiteID"] = new SelectList(_context.Sites, "ID", "Address", car.SiteID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Make,Model,Category,PurchaseDate,MOTExpDate,TaxExpDate,InsuranceExpDate,SiteID")] Car car)
        {
            if (id != car.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.ID))
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
            ViewData["SiteID"] = new SelectList(_context.Sites, "ID", "Address", car.SiteID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.ID == id);
        }
    }
}
