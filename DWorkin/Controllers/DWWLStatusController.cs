using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.DWorkin.Models.DataModels;
using NBSTimeReporting.Data;
using NBSTimeReporting.DWorkin.Models.ViewModels;

namespace NBSTimeReporting.DWorkin.Controllers
{
    public class DWWLStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DWWLStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DWWLStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.DWWLStatus.ToListAsync());
        }

        public IActionResult ListDWWLStatuses()
        {
            var dWWLStatusesViewModel = new DWWLStatusesViewModel()
            {
                DWWLStatuses = _context.DWWLStatus
                .ToList()
            };
            return View(dWWLStatusesViewModel);
        }

        // GET: DWWLStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dWWLStatus = await _context.DWWLStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dWWLStatus == null)
            {
                return NotFound();
            }

            return View(dWWLStatus);
        }

        // GET: DWWLStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DWWLStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DWWLStatusName")] DWWLStatus dWWLStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dWWLStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListDWWLStatuses));
            }
            return View(dWWLStatus);
        }

        // GET: DWWLStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dWWLStatus = await _context.DWWLStatus.FindAsync(id);
            if (dWWLStatus == null)
            {
                return NotFound();
            }
            return View(dWWLStatus);
        }

        // POST: DWWLStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DWWLStatusName")] DWWLStatus dWWLStatus)
        {
            if (id != dWWLStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dWWLStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DWWLStatusExists(dWWLStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListDWWLStatuses));
            }
            return View(dWWLStatus);
        }

        // GET: DWWLStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dWWLStatus = await _context.DWWLStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dWWLStatus == null)
            {
                return NotFound();
            }

            return View(dWWLStatus);
        }

        // POST: DWWLStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dWWLStatus = await _context.DWWLStatus.FindAsync(id);
            _context.DWWLStatus.Remove(dWWLStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListDWWLStatuses));
        }

        private bool DWWLStatusExists(int id)
        {
            return _context.DWWLStatus.Any(e => e.Id == id);
        }
    }
}
