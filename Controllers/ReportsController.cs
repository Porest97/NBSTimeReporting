using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Data;
using NBSTimeReporting.Models.DataModels;
using NBSTimeReporting.Models.ViewModels;

namespace NBSTimeReporting.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Report
                .Include(r => r.Emloyee)
                .Include(r => r.ReportStatus)
                .Include(r => r.ReportType)
                .Include(r => r.Site)
                .Include(r => r.Ticket)
                .Include(r => r.Ticket.Site);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListReports
        public IActionResult ListReports()
        {


            var reportsViewModel = new ReportsViewModel()
            {
                Reports = _context.Report
                .Include(r => r.Emloyee)
                .Include(r => r.ReportStatus)
                .Include(r => r.ReportType)
                .Include(r => r.Site)
                .Include(r => r.Ticket)
                .Include(r => r.Ticket.Site)
                .ToList()
            };
            return View(reportsViewModel);
        }

        // GET: ListReportsPO
        public IActionResult ListReportsPO()
        {


            var reportsViewModel = new ReportsViewModel()
            {
                Reports = _context.Report
                .Include(r => r.Emloyee)
                .Include(r => r.ReportStatus)
                .Include(r => r.ReportType)
                .Include(r => r.Site)
                .Include(r => r.Ticket)
                .Include(r => r.Ticket.Site).Where(r=>r.PersonId == 1)
                .ToList()
            };
            return View(reportsViewModel);
        }

        // GET: ListReportsJM
        public IActionResult ListReportsJM()
        {


            var reportsViewModel = new ReportsViewModel()
            {
                Reports = _context.Report
                .Include(r => r.Emloyee)
                .Include(r => r.ReportStatus)
                .Include(r => r.ReportType)
                .Include(r => r.Site)
                .Include(r => r.Ticket)
                .Include(r => r.Ticket.Site).Where(r => r.PersonId == 2)
                .ToList()
            };
            return View(reportsViewModel);
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .Include(r => r.Emloyee)
                .Include(r => r.ReportStatus)
                .Include(r => r.ReportType)
                .Include(r => r.Site)                
                .Include(r => r.Ticket)
                .Include(r => r.Ticket.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName");
            ViewData["ReportTypeId"] = new SelectList(_context.ReportType, "Id", "ReportTypeName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "IncidentNumber");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReportStatusId,ReportTypeId,PersonId,SiteId,TicketId,DateTimeStarted,DateTimeEnded,WorkHours")] Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListReports));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", report.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", report.ReportStatusId);
            ViewData["ReportTypeId"] = new SelectList(_context.ReportType, "Id", "ReportTypeName", report.ReportTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", report.SiteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "IncidentNumber", report.TicketId);
            return View(report);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", report.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", report.ReportStatusId);
            ViewData["ReportTypeId"] = new SelectList(_context.ReportType, "Id", "ReportTypeName", report.ReportTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", report.SiteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "IncidentNumber", report.TicketId);
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportStatusId,ReportTypeId,PersonId,SiteId,TicketId,DateTimeStarted,DateTimeEnded,WorkHours")] Report report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListReports));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", report.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", report.ReportStatusId);
            ViewData["ReportTypeId"] = new SelectList(_context.ReportType, "Id", "ReportTypeName", report.ReportTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", report.SiteId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "IncidentNumber", report.TicketId);
            return View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .Include(r => r.Emloyee)
                .Include(r => r.ReportStatus)
                .Include(r => r.ReportType)
                .Include(r => r.Site)
                .Include(r => r.Ticket)
                .Include(r => r.Ticket.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Report.FindAsync(id);
            _context.Report.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListReports));
        }

        private bool ReportExists(int id)
        {
            return _context.Report.Any(e => e.Id == id);
        }
    }
}
