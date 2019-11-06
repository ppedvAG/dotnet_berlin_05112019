using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HalloWeb.Models;

namespace HalloWeb.Controllers
{
    public class BananenController : Controller
    {
        private readonly BananenContext _context;

        public BananenController(BananenContext context)
        {
            _context = context;
        }

        // GET: Bananen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banane.ToListAsync());
        }

        // GET: Bananen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banane = await _context.Banane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banane == null)
            {
                return NotFound();
            }

            return View(banane);
        }

        // GET: Bananen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bananen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reifegrad,Pflückdatum,Land")] Banane banane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banane);
        }

        // GET: Bananen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banane = await _context.Banane.FindAsync(id);
            if (banane == null)
            {
                return NotFound();
            }
            return View(banane);
        }

        // POST: Bananen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Reifegrad,Pflückdatum,Land")] Banane banane)
        {
            if (id != banane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BananeExists(banane.Id))
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
            return View(banane);
        }

        // GET: Bananen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banane = await _context.Banane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banane == null)
            {
                return NotFound();
            }

            return View(banane);
        }

        // POST: Bananen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banane = await _context.Banane.FindAsync(id);
            _context.Banane.Remove(banane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BananeExists(int id)
        {
            return _context.Banane.Any(e => e.Id == id);
        }
    }
}
