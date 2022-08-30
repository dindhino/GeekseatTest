using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeekseatWitchSaga.Data;
using GeekseatWitchSaga.Models;

namespace GeekseatWitchSaga.Controllers
{
    public class VillagerController : Controller
    {
        private readonly GeekseatWitchSagaContext _context;

        public VillagerController(GeekseatWitchSagaContext context)
        {
            _context = context;
        }

        // GET: Villager
        public async Task<IActionResult> Index()
        {
            return View(await _context.VillagerData.ToListAsync());
        }

        // GET: Villager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villagerData = await _context.VillagerData
                .FirstOrDefaultAsync(m => m.ID == id);
            if (villagerData == null)
            {
                return NotFound();
            }

            return View(villagerData);
        }

        // GET: Villager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Villager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,iAge,iYear")] VillagerData villagerData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(villagerData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(villagerData);
        }

        // GET: Villager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villagerData = await _context.VillagerData.FindAsync(id);
            if (villagerData == null)
            {
                return NotFound();
            }
            return View(villagerData);
        }

        // POST: Villager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,iAge,iYear")] VillagerData villagerData)
        {
            if (id != villagerData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(villagerData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VillagerDataExists(villagerData.ID))
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
            return View(villagerData);
        }

        // GET: Villager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villagerData = await _context.VillagerData
                .FirstOrDefaultAsync(m => m.ID == id);
            if (villagerData == null)
            {
                return NotFound();
            }

            return View(villagerData);
        }

        // POST: Villager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var villagerData = await _context.VillagerData.FindAsync(id);
            _context.VillagerData.Remove(villagerData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VillagerDataExists(int id)
        {
            return _context.VillagerData.Any(e => e.ID == id);
        }
    }
}
