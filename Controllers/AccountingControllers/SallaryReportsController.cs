using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Data;
using NBSTimeReporting.Models.AccountingModels;
using NBSTimeReporting.Models.ViewModels;

namespace NBSTimeReporting.Controllers.AccountingControllers
{
    public class SallaryReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SallaryReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SallaryReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SallaryReport
                .Include(s => s.Employee)
                .Include(s => s.ReportStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SallaryReports HttpPost !
        [HttpPost]
        public IActionResult Index(SallaryReport sallaryReport)
        {

            var applicationContext = _context.SallaryReport
                .Include(sr => sr.Employee)
                .Include(sr => sr.ReportStatus);
            sallaryReport.TotalPayment = sallaryReport.TimeWorked
                * sallaryReport.PaymentPerHour;
            sallaryReport.DueToPay = sallaryReport.TimeWorked
                * sallaryReport.PaymentPerHour
                - sallaryReport.AmountPayed;
            return View(sallaryReport);
        }

        // GET: AllaryReports to ListSallaryReports
        public IActionResult ListSallaryReports()
        {


            var sallaryReportsViewModel = new SallaryReportsViewModel()
            {
                SallaryReports = _context.SallaryReport
                .Include(sr => sr.ReportStatus)
                .Include(sr => sr.Employee)                
                .ToList()
            };
            return View(sallaryReportsViewModel);
        }

        // GET: AllaryReports to ListSallaryReports Emloyee => Per Orest
        public IActionResult ListSallaryReportsPO()
        {


            var sallaryReportsViewModel = new SallaryReportsViewModel()
            {
                SallaryReports = _context.SallaryReport
                .Include(sr => sr.ReportStatus)
                .Include(sr => sr.Employee).Where(sr=> sr.PersonId == 1)
                .ToList()
            };
            return View(sallaryReportsViewModel);
        }

        // GET: SallaryReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallaryReport = await _context.SallaryReport
                .Include(s => s.Employee)
                .Include(s => s.ReportStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sallaryReport == null)
            {
                return NotFound();
            }

            return View(sallaryReport);
        }

        // GET: SallaryReports/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName");
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName");
            return View();
        }

        // POST: SallaryReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReportStatusId,Month,PersonId,TimeWorked,PaymentPerHour,TotalPayment,Payed,AmountPayed,DueToPay")] SallaryReport sallaryReport)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.SallaryReport
                    .Include(s => s.Employee)
                    .Include(s => s.ReportStatus);
                sallaryReport.TotalPayment = sallaryReport.TimeWorked
                    * sallaryReport.PaymentPerHour;
                sallaryReport.DueToPay = sallaryReport.TimeWorked
                    * sallaryReport.PaymentPerHour
                    - sallaryReport.AmountPayed;
                

                _context.Add(sallaryReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSallaryReports));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", sallaryReport.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", sallaryReport.ReportStatusId);
            return View(sallaryReport);
        }

        // GET: SallaryReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallaryReport = await _context.SallaryReport.FindAsync(id);
            if (sallaryReport == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", sallaryReport.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", sallaryReport.ReportStatusId);
            return View(sallaryReport);
        }

        // POST: SallaryReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportStatusId,Month,PersonId,TimeWorked,PaymentPerHour,TotalPayment,Payed,AmountPayed,DueToPay")] SallaryReport sallaryReport)
        {
            if (id != sallaryReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.SallaryReport
                        .Include(s => s.Employee)
                        .Include(s => s.ReportStatus);
                    sallaryReport.TotalPayment = sallaryReport.TimeWorked
                        * sallaryReport.PaymentPerHour;
                    sallaryReport.DueToPay = sallaryReport.TimeWorked
                        * sallaryReport.PaymentPerHour
                        - sallaryReport.AmountPayed;

                    _context.Update(sallaryReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SallaryReportExists(sallaryReport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListSallaryReports));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", sallaryReport.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", sallaryReport.ReportStatusId);
            return View(sallaryReport);
        }

        // GET: SallaryReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallaryReport = await _context.SallaryReport
                .Include(s => s.Employee)
                .Include(s => s.ReportStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sallaryReport == null)
            {
                return NotFound();
            }

            return View(sallaryReport);
        }

        // POST: SallaryReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sallaryReport = await _context.SallaryReport.FindAsync(id);
            _context.SallaryReport.Remove(sallaryReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListSallaryReports));
        }

        private bool SallaryReportExists(int id)
        {
            return _context.SallaryReport.Any(e => e.Id == id);
        }
    }
}
