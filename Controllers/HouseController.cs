using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using House_Data.Data;
using House_Data.Models;

namespace House_Data.Controllers
{
    public class HouseController : Controller
    {
        private readonly House_DataContext _context;

        public HouseController(House_DataContext context)
        {
            _context = context;
        }

        // GET: House
        public async Task<IActionResult> Index()
        {
            return View(await _context.House.ToListAsync());
        }

        // GET: House/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // GET: House/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: House/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,region,Amount,area,houseType,houseAge,salesId,cDate,uDate")] House house)
        {
            house.salesId = 1;
            house.cDate = DateTime.Now;
            house.uDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: House/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            return View(house);
        }

        // POST: House/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,region,Amount,area,houseType,houseAge")] House house)
        {
            if (id != house.id)
            {
                return NotFound();
            }
            var house_old = _context.House.Where(v=>v.id==house.id).FirstOrDefault();
            _context.Entry(house_old).State = EntityState.Detached;

            //以下值不修改
            house.salesId = house_old.salesId;
            house.cDate = house_old.cDate;
            house.uDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.id))
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
            return View(house);
        }

        // GET: House/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // POST: House/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var house = await _context.House.FindAsync(id);
            if (house != null)
            {
                _context.House.Remove(house);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
            return _context.House.Any(e => e.id == id);
        }
    }
}
