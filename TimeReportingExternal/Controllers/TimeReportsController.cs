using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Data;
using NBSTimeReporting.TimeReportingExternal.DataModels;

namespace NBSTimeReporting.TimeReportingExternal.Controllers
{
    public class TimeReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeReport.Include(t => t.Site);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TimeReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport
                .Include(t => t.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeReport == null)
            {
                return NotFound();
            }

            return View(timeReport);
        }

        // GET: TimeReports/Create
        public IActionResult Create()
        {
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName");
            return View();
        }

        // POST: TimeReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteId,IncidentNumber,ShiftStarted,ShiftEnded,WorkedHours,FeeHour,TotalFee,Notes")] TimeReport timeReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", timeReport.SiteId);
            return View(timeReport);
        }

        // GET: TimeReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport.FindAsync(id);
            if (timeReport == null)
            {
                return NotFound();
            }
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", timeReport.SiteId);
            return View(timeReport);
        }

        // POST: TimeReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteId,IncidentNumber,ShiftStarted,ShiftEnded,WorkedHours,FeeHour,TotalFee,Notes")] TimeReport timeReport)
        {
            if (id != timeReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeReportExists(timeReport.Id))
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
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", timeReport.SiteId);
            return View(timeReport);
        }

        // GET: TimeReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport
                .Include(t => t.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeReport == null)
            {
                return NotFound();
            }

            return View(timeReport);
        }

        // POST: TimeReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeReport = await _context.TimeReport.FindAsync(id);
            _context.TimeReport.Remove(timeReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeReportExists(int id)
        {
            return _context.TimeReport.Any(e => e.Id == id);
        }
    }
}
