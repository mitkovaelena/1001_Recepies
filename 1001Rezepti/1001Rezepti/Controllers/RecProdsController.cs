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
    public class RecProdsController : Controller
    {
        private readonly RecepieContext _context;

        public RecProdsController(RecepieContext context)
        {
            _context = context;
        }

        // GET: RecProds
        public async Task<IActionResult> Index()
        {
            ViewData["Background"] = "\"../images/background2.jpg\"";
            ViewData["ProductIds"] = new SelectList(_context.Products,
                "ProductID", "ProductName", 0);
                ViewBag.Selected = "Всички";
                var recprods = _context.RecProds
                .OrderBy(r => r.Quantity)
                .Include(r => r.Recepie)
                .Include(r => r.Product);
                return View(await recprods.ToListAsync());
                // var recepieContext = _context.RecProds.Include(r => r.Product).Include(r => r.Recepie);
               // return View(await recepieContext.ToListAsync());
        }

        // POST: RecProds
        [HttpPost]
        public async Task<IActionResult> Index(RecProd recProd)
        {
            ViewData["Background"] = "\"../images/background2.jpg\"";
            int? SelectedNumber = recProd.Product.ProductID;
            ViewData["ProductIds"] = new SelectList(_context.Products,
                 "ProductID", "ProductName", SelectedNumber);
            var d = _context.Products;
            int productID = SelectedNumber.GetValueOrDefault();
            var recProds = _context.RecProds
            .Where(p => !SelectedNumber.HasValue || p.ProductId == productID)
            .OrderBy(p => p.Quantity)
            .Include(r => r.Recepie);
            if(SelectedNumber == null || SelectedNumber == 0)
            {
                ViewBag.Selected = "Всички";
                recProds = _context.RecProds.OrderBy(r => r.Quantity)
            .Include(p => p.Recepie);
            }
            return View(await recProds.ToListAsync());
        }

        // GET: RecProds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recProd = await _context.RecProds
                .Include(r => r.Product)
                .Include(r => r.Recepie)
                .FirstOrDefaultAsync(m => m.RecepieId == id);
            if (recProd == null)
            {
                return NotFound();
            }

            return View(recProd);
        }

        // GET: RecProds/Create/5
        [Authorize]
        public async Task<IActionResult> Create(int? recepieId)
        {
            if (recepieId == null)
            {
                return NotFound();
            }
            var recepie = await _context.Recepies.FindAsync(recepieId);  
            if (recepie == null)
            {
                return NotFound();
            }
            ViewData["RecepieName"] = recepie.RecepieName;
            ViewData["RecepieId"] = recepieId;
            ViewData["ProductIds"] = new SelectList(_context.Products, "ProductID", "ProductName");
            ViewData["RecepieIds"] = new SelectList(_context.Recepies, "RecepieID", "Description");
            return View();
        }

        // POST: RecProds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecepieId,ProductId,Quantity")] RecProd recProd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(recProd);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("",
                    "Номерът вече съществува, моля въведете друг.");
            }
            ViewData["ProductIds"] = new SelectList(_context.Products, "ProductID", "ProductName", recProd.ProductId);
            ViewData["RecepieIds"] = new SelectList(_context.Recepies, "RecepieID", "Description", recProd.RecepieId);
            return View(recProd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddMore([Bind("RecepieId,ProductId,Quantity")] RecProd recProd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(recProd);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", "RecProds", new { recepieid = recProd.RecepieId });
                }
            }
            catch
            {
                ModelState.AddModelError("",
                    "Номерът вече съществува, моля въведете друг.");
            }
            ViewData["ProductIds"] = new SelectList(_context.Products, "ProductID", "ProductName", recProd.ProductId);
            ViewData["RecepieIds"] = new SelectList(_context.Recepies, "RecepieID", "Description", recProd.RecepieId);
            return View(recProd);
        }

        // GET: RecProds/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? productId, int? recepieId)
        {
            if (productId == null || recepieId== null)
            {
                return NotFound();
            }

            var recProd = await _context.RecProds
                .Include(e => e.Product)
                .Include(e => e.Recepie)
                .FirstOrDefaultAsync(m => m.ProductId == productId && 
                m.RecepieId == recepieId);
            if (recProd == null)
            {
                return NotFound();
            }
            ViewData["ProductIds"] = new SelectList(_context.Products, "ProductID", "ProductName", recProd.ProductId);
            ViewData["RecepieIds"] = new SelectList(_context.Recepies, "RecepieID", "Description", recProd.RecepieId);
            return View(recProd);
        }

        // POST: RecProds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? productId, int? recepieId,
            [Bind("RecepieId,ProductId,Quantity")] RecProd recProd)
        {
            if (recepieId != recProd.RecepieId || productId != recProd.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    try
                    {
                        _context.Update(recProd);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RecProdExists(recProd.RecepieId))
                        {
                            ModelState.AddModelError("",
                                "Рецептата не може да бъде намерена.");
                        }
                    else
                        {
                            ModelState.AddModelError("",
                                "Номерът вече съществува, моля въведете друг.");
                        }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductIds"] = new SelectList(_context.Products, "ProductID", "ProductName", recProd.ProductId);
            ViewData["RecepieIds"] = new SelectList(_context.Recepies, "RecepieID", "Description", recProd.RecepieId);
            return View(recProd);
        }

        // GET: RecProds/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? productId, int? recepieId, bool? saveChangesError = false)
        {
            if (productId == null || recepieId == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault()) { }
            ViewBag.ErrorMessage = "Неуспешно изтриване. Опитайте пак";
            var recProd = await _context.RecProds
                .Include(e => e.Product)
                .Include(e => e.Recepie)
                .FirstOrDefaultAsync(m => m.ProductId == productId && m.RecepieId == recepieId);
            if (recProd == null)
            {
                return NotFound();
            }

            return View(recProd);
        }

        // POST: RecProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? productId, int? recepieId)
        {
            try
            {
                var recProd = await _context.RecProds.FirstOrDefaultAsync(m => m.ProductId == productId && m.RecepieId == recepieId);
                _context.RecProds.Remove(recProd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete",
                    new { productId, recepieId, saveChangesError = true });
            }
        }

        private bool RecProdExists(int id)
        {
            return _context.RecProds.Any(e => e.RecepieId == id);
        }
    }
}
