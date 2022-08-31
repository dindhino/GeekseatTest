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
    public class VillagerController : Controller, IVillager
    {
        private readonly GeekseatWitchSagaContext _context;

        public VillagerController(GeekseatWitchSagaContext context)
        {
            _context = context;
        }

        // GET: Villager
        public async Task<IActionResult> Index()
        {
            ViewData["AverageNumber"] = GetAverageNumberOfKilledVillager();
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

        public decimal GetAverageNumberOfKilledVillager()
        {
            long totalKilled = 0;
            long counter = 0;
            foreach(var villagerData in _context.VillagerData)
            {
                int iBornOnYear = villagerData.iYear - villagerData.iAge;
                if (iBornOnYear < 0)
                    return -1m;

                totalKilled += GetNumberOfKilledVillagerInYear(iBornOnYear);
                counter++;
            }
            if (counter == 0)
                return -1m;
            else
                return (decimal)totalKilled/counter;
        }

        Dictionary<int, long> _memoryOfKilledVillager = new Dictionary<int, long>();
        public long GetNumberOfKilledVillagerInYear(int iBornOnYear)
        {
            if (_memoryOfKilledVillager.ContainsKey(iBornOnYear))
                return _memoryOfWitchRule[iBornOnYear];

            var value = WitchRules(iBornOnYear + 2) - 1;
            _memoryOfKilledVillager[iBornOnYear] = value;

            return value;
        }

        Dictionary<int, long> _memoryOfWitchRule = new Dictionary<int, long>() { { 0, 0 }, { 1, 1 } };
        public long WitchRules(int n)
        {
            if (n < 0)
                return 0;

            if (_memoryOfWitchRule.ContainsKey(n))
                return _memoryOfWitchRule[n];

            var value = WitchRules(n - 1) + WitchRules(n - 2);

            _memoryOfWitchRule[n] = value;

            return value;
        }
    }
}
