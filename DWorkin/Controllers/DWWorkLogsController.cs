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
    public class DWWorkLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DWWorkLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DWWorkLogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DWWorkLog
                .Include(d => d.Company)
                .Include(d => d.Site)
                .Include(d => d.Technician)
                .Include(d => d.DWWLStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        //List All WLs !
        public IActionResult ListDWWorkLogs()
        {

            var dWWorklogViewModel = new DWWorkLogViewModel()
            {
                DWWorkLogs = _context.DWWorkLog
                .Include(d => d.Company)                
                .Include(d => d.Site)
                .Include(d => d.Technician)
                .Include(d => d.DWWLStatus)
                .ToList()
            };
            return View(dWWorklogViewModel);
        }

        //List All WLs !
        public IActionResult ListDWWorkLogsIWG()
        {

            var dWWorklogViewModel = new DWWorkLogViewModel()
            {
                DWWorkLogs = _context.DWWorkLog
                .Include(d => d.Company)
                .Include(d => d.Site)
                .Include(d => d.Technician)
                .Include(d => d.DWWLStatus).Where(d => d.CompanyId == 8)
                .ToList()
            };
            return View(dWWorklogViewModel);
        }

        // GET: DWWorkLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dWWorkLog = await _context.DWWorkLog
                .Include(d => d.Company)
                .Include(d => d.Site)
                .Include(d => d.Technician)
                .Include(d => d.DWWLStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dWWorkLog == null)
            {
                return NotFound();
            }

            return View(dWWorkLog);
        }

        // GET: DWWorkLogs/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["DWWLStatusId"] = new SelectList(_context.DWWLStatus, "Id", "DWWLStatusName");
            return View();
        }

        // POST: DWWorkLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WLNumber,Type,State,PersonId,DateFrom,DateTo,BusUnit,CompanyId,SiteId,Subject,TotalHours,DayOffHours,ToInvoiceHours,OBH,WH,WSatisfactionHours,Coefficient,DWWLStatusId")] DWWorkLog dWWorkLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dWWorkLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListDWWorkLogs));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", dWWorkLog.CompanyId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", dWWorkLog.SiteId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", dWWorkLog.PersonId);
            ViewData["DWWLStatusId"] = new SelectList(_context.DWWLStatus, "Id", "DWWLStatusName", dWWorkLog.DWWLStatusId);
            return View(dWWorkLog);
        }

        // GET: DWWorkLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dWWorkLog = await _context.DWWorkLog.FindAsync(id);
            if (dWWorkLog == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", dWWorkLog.CompanyId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", dWWorkLog.SiteId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", dWWorkLog.PersonId);
            ViewData["DWWLStatusId"] = new SelectList(_context.DWWLStatus, "Id", "DWWLStatusName", dWWorkLog.DWWLStatusId);
            return View(dWWorkLog);
        }

        // POST: DWWorkLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WLNumber,Type,State,PersonId,DateFrom,DateTo,BusUnit,CompanyId,SiteId,Subject,TotalHours,DayOffHours,ToInvoiceHours,OBH,WH,WSatisfactionHours,Coefficient,DWWLStatusId")] DWWorkLog dWWorkLog)
        {
            if (id != dWWorkLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dWWorkLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DWWorkLogExists(dWWorkLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListDWWorkLogs));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", dWWorkLog.CompanyId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", dWWorkLog.SiteId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", dWWorkLog.PersonId);
            ViewData["DWWLStatusId"] = new SelectList(_context.DWWLStatus, "Id", "DWWLStatusName", dWWorkLog.DWWLStatusId);
            return View(dWWorkLog);
        }

        // GET: DWWorkLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dWWorkLog = await _context.DWWorkLog
                .Include(d => d.Company)
                .Include(d => d.Site)
                .Include(d => d.Technician)
                .Include(d => d.DWWLStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dWWorkLog == null)
            {
                return NotFound();
            }

            return View(dWWorkLog);
        }

        // POST: DWWorkLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dWWorkLog = await _context.DWWorkLog.FindAsync(id);
            _context.DWWorkLog.Remove(dWWorkLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListDWWorkLogs));
        }

        private bool DWWorkLogExists(int id)
        {
            return _context.DWWorkLog.Any(e => e.Id == id);
        }
    }
}
