using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _1001Rezepti.Models;
using Microsoft.AspNetCore.Authorization;
namespace _1001Rezepti.Controllers
{
    public class RecepiesController : Controller
    {
        private readonly RecepieContext _context;

        public RecepiesController(RecepieContext context)
        {
            _context = context;
        }

        // GET: Recepies
        public async Task<IActionResult> Index()
        {
            ViewData["Background"] = "\"../images/background2.jpg\"";
            //   ViewData["ProductIds"] = new SelectList(_context.Products, "ProductID", "ProductName");
            return View(await _context.Recepies.Include(p => p.Products).ToListAsync());
        }

        // GET: Recepies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepie = await _context.Recepies
                .FirstOrDefaultAsync(m => m.RecepieID == id);
            if (recepie == null)
            {
                return NotFound();
            }
            var recProds = await _context.RecProds.Include(p => p.Product)
                .Where(s => s.RecepieId == id)
                .ToListAsync();
            var productNames = new List<string>();
            foreach(RecProd recProd in recProds)
            {
                productNames.Add(recProd.Product.ProductName.ToString() + " - " + recProd.Quantity.ToString() +"гр.");
            }
            ViewData["ProductNames"] = productNames;

            return View(recepie);
        }

        // GET: Recepies/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recepies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("RecepieID,RecepieName,Description,ImagePath,TimeToCook")] Recepie recepie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(recepie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", "RecProds", new { recepieid = recepie.RecepieID });
                    //return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("",
                    "Номерът вече съществува, моля въведете друг.");
            }
            return View(recepie);
        }

        // GET: Recepies/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepie = await _context.Recepies.FindAsync(id);
            if (recepie == null)
            {
                return NotFound();
            }
            return View(recepie);
        }

        // POST: Recepies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecepieID,RecepieName,Description,ImagePath,TimeToCook")] Recepie recepie)
        {
            if (id != recepie.RecepieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recepie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepieExists(recepie.RecepieID))
                    {
                        return NotFound();
                    }
                    else
                        {
                            ModelState.AddModelError("",
                                "Номерът вече съществува, моля въведете друг.");
                        }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recepie);
        }

        // GET: Recepies/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepie = await _context.Recepies
                .FirstOrDefaultAsync(m => m.RecepieID == id);
            if (recepie == null)
            {
                return NotFound();
            }

            return View(recepie);
        }

        // POST: Recepies/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var recepie = await _context.Recepies.FindAsync(id);
                _context.Recepies.Remove(recepie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete",
                    new { id, saveChangesError = true });
            }
        }

        private bool RecepieExists(int id)
        {
            return _context.Recepies.Any(e => e.RecepieID == id);
        }
    }
}
