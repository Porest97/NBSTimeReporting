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
    public class MonthlyTimeReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonthlyTimeReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonthlyTimeReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MonthlyTimeReport
                .Include(m => m.ReportStatus)
                .Include(m => m.WTR1)
                .Include(m => m.WTR1.Emloyee)
                .Include(m => m.WTR2)
                .Include(m => m.WTR2.Emloyee)
                .Include(m => m.WTR3)
                .Include(m => m.WTR3.Emloyee)
                .Include(m => m.WTR4)
                .Include(m => m.WTR4.Emloyee)
                .Include(m => m.WTR5)
                .Include(m => m.WTR5.Emloyee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MonthlyTimeReports HttpPost !
        [HttpPost]
        public IActionResult Index(MonthlyTimeReport montlyTimeReport)
        {
            // Sum of all worked hours during the Month !
            var applicationDbContext = _context.MonthlyTimeReport
                .Include(m => m.ReportStatus)
                .Include(m => m.WTR1)
                .Include(m => m.WTR1.Emloyee)
                .Include(m => m.WTR2)
                .Include(m => m.WTR2.Emloyee)
                .Include(m => m.WTR3)
                .Include(m => m.WTR3.Emloyee)
                .Include(m => m.WTR4)
                .Include(m => m.WTR4.Emloyee)
                .Include(m => m.WTR5)
                .Include(m => m.WTR5.Emloyee);
            //montlyTimeReport.TotalTimeWorked = 
            //      montlyTimeReport.WTR1.WorkedHoursTotal
            //    + montlyTimeReport.WTR2.WorkedHoursTotal
            //    + montlyTimeReport.WTR3.WorkedHoursTotal
            //    + montlyTimeReport.WTR4.WorkedHoursTotal
            //    + montlyTimeReport.WTR5.WorkedHoursTotal;
            return View(montlyTimeReport);
           
        }

        // GET: ListMonthlyTimeReports
        public IActionResult ListMonthlyTimeReports()
        {
            var monthlyTimeReportsViewModel = new MonthlyTimeReportsViewModel()
            {
                MonthlyTimeReports = _context.MonthlyTimeReport
                .Include(m => m.ReportStatus)
                .Include(m => m.WTR1)
                .Include(m => m.WTR1.Emloyee)
                .Include(m => m.WTR2)
                .Include(m => m.WTR2.Emloyee)
                .Include(m => m.WTR3)
                .Include(m => m.WTR3.Emloyee)
                .Include(m => m.WTR4)
                .Include(m => m.WTR4.Emloyee)
                .Include(m => m.WTR5)
                .Include(m => m.WTR5.Emloyee)
                .ToList()
            };
            return View(monthlyTimeReportsViewModel);
        }

        // GET: ListMonthlyTimeReportsPO
        public IActionResult ListMonthlyTimeReportsPO()
        {
            var monthlyTimeReportsViewModel = new MonthlyTimeReportsViewModel()
            {
                MonthlyTimeReports = _context.MonthlyTimeReport
                .Include(m => m.ReportStatus)
                .Include(m => m.WTR1)
                .Include(m => m.WTR1.Emloyee)
                .Include(m => m.WTR2)
                .Include(m => m.WTR2.Emloyee)
                .Include(m => m.WTR3)
                .Include(m => m.WTR3.Emloyee)
                .Include(m => m.WTR4)
                .Include(m => m.WTR4.Emloyee)
                .Include(m => m.WTR5)
                .Include(m => m.WTR5.Emloyee).Where(wtr => wtr.WTR1.PersonId == 1)
                .ToList()
            };
            return View(monthlyTimeReportsViewModel);
        }

        // GET: ListMonthlyTimeReportsJM
        public IActionResult ListMonthlyTimeReportsJM()
        {
            var monthlyTimeReportsViewModel = new MonthlyTimeReportsViewModel()
            {
                MonthlyTimeReports = _context.MonthlyTimeReport
                .Include(m => m.ReportStatus)
                .Include(m => m.WTR1)
                .Include(m => m.WTR1.Emloyee)
                .Include(m => m.WTR2)
                .Include(m => m.WTR2.Emloyee)
                .Include(m => m.WTR3)
                .Include(m => m.WTR3.Emloyee)
                .Include(m => m.WTR4)
                .Include(m => m.WTR4.Emloyee)
                .Include(m => m.WTR5)
                .Include(m => m.WTR5.Emloyee).Where(wtr => wtr.WTR1.PersonId == 2)
                .ToList()
            };
            return View(monthlyTimeReportsViewModel);
        }

        // GET: MonthlyTimeReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyTimeReport = await _context.MonthlyTimeReport
                .Include(m => m.ReportStatus)
                .Include(m => m.WTR1)
                .Include(m => m.WTR1.Emloyee)
                .Include(m => m.WTR2)
                .Include(m => m.WTR2.Emloyee)
                .Include(m => m.WTR3)
                .Include(m => m.WTR3.Emloyee)
                .Include(m => m.WTR4)
                .Include(m => m.WTR4.Emloyee)
                .Include(m => m.WTR5)
                .Include(m => m.WTR5.Emloyee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthlyTimeReport == null)
            {
                return NotFound();
            }

            return View(monthlyTimeReport);
        }

        // GET: MonthlyTimeReports/Create
        public IActionResult Create()
        {
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName");
            ViewData["WeeklyTimeReportId"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName");
            ViewData["WeeklyTimeReportId1"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName");
            ViewData["WeeklyTimeReportId2"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName");
            ViewData["WeeklyTimeReportId3"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName");
            ViewData["WeeklyTimeReportId4"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName");
            return View();
        }

        // POST: MonthlyTimeReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReportStatusId,Month,FromDate,ToDate,WeeklyTimeReportId,WeeklyTimeReportId1,WeeklyTimeReportId2,WeeklyTimeReportId3,WeeklyTimeReportId4,TotalTimeWorked")] MonthlyTimeReport monthlyTimeReport)
        {
            if (ModelState.IsValid)
            {
                // Sum of all worked hours during the Month !
                var applicationDbContext = _context.MonthlyTimeReport
                    .Include(m => m.ReportStatus)
                    .Include(m => m.WTR1)
                    .Include(m => m.WTR1.Emloyee)
                    .Include(m => m.WTR1.WorkedHoursTotal)
                    .Include(m => m.WTR2)
                    .Include(m => m.WTR2.Emloyee)
                    .Include(m => m.WTR2.WorkedHoursTotal)
                    .Include(m => m.WTR3)
                    .Include(m => m.WTR3.Emloyee)
                    .Include(m => m.WTR3.WorkedHoursTotal)
                    .Include(m => m.WTR4)
                    .Include(m => m.WTR4.Emloyee)
                    .Include(m => m.WTR4.WorkedHoursTotal)
                    .Include(m => m.WTR5)
                    .Include(m => m.WTR5.Emloyee)
                    .Include(m => m.WTR5.WorkedHoursTotal);
                //monthlyTimeReport.TotalTimeWorked =
                //      monthlyTimeReport.WTR1.WorkedHoursTotal
                //    + monthlyTimeReport.WTR2.WorkedHoursTotal
                //    + monthlyTimeReport.WTR3.WorkedHoursTotal
                //    + monthlyTimeReport.WTR4.WorkedHoursTotal
                //    + monthlyTimeReport.WTR5.WorkedHoursTotal;

                _context.Add(monthlyTimeReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListMonthlyTimeReports));
            }
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "ReportStatusName", "Id", monthlyTimeReport.ReportStatusId);
            ViewData["WeeklyTimeReportId"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId);
            ViewData["WeeklyTimeReportId1"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId1);
            ViewData["WeeklyTimeReportId2"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId2);
            ViewData["WeeklyTimeReportId3"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId3);
            ViewData["WeeklyTimeReportId4"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId4);
            return View(monthlyTimeReport);
        }

        // GET: MonthlyTimeReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyTimeReport = await _context.MonthlyTimeReport.FindAsync(id);
            if (monthlyTimeReport == null)
            {
                return NotFound();
            }
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "ReportStatusName", "Id", monthlyTimeReport.ReportStatusId);
            ViewData["WeeklyTimeReportId"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId);
            ViewData["WeeklyTimeReportId1"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId1);
            ViewData["WeeklyTimeReportId2"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId2);
            ViewData["WeeklyTimeReportId3"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId3);
            ViewData["WeeklyTimeReportId4"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId4);
            return View(monthlyTimeReport);
        }

        // POST: MonthlyTimeReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportStatusId,Month,FromDate,ToDate,WeeklyTimeReportId,WeeklyTimeReportId1,WeeklyTimeReportId2,WeeklyTimeReportId3,WeeklyTimeReportId4,TotalTimeWorked")] MonthlyTimeReport monthlyTimeReport)
        {
            if (id != monthlyTimeReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Sum of all worked hours during the Month !
                    var applicationDbContext = _context.MonthlyTimeReport
                        .Include(m => m.ReportStatus)
                        .Include(m => m.WTR1)
                        .Include(m => m.WTR1.Emloyee)
                        .Include(m => m.WTR2)
                        .Include(m => m.WTR2.Emloyee)
                        .Include(m => m.WTR3)
                        .Include(m => m.WTR3.Emloyee)
                        .Include(m => m.WTR4)
                        .Include(m => m.WTR4.Emloyee)
                        .Include(m => m.WTR5)
                        .Include(m => m.WTR5.Emloyee);
                    //monthlyTimeReport.TotalTimeWorked =
                    //      monthlyTimeReport.WTR1.WorkedHoursTotal
                    //    + monthlyTimeReport.WTR2.WorkedHoursTotal
                    //    + monthlyTimeReport.WTR3.WorkedHoursTotal
                    //    + monthlyTimeReport.WTR4.WorkedHoursTotal
                    //    + monthlyTimeReport.WTR5.WorkedHoursTotal;

                    _context.Update(monthlyTimeReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthlyTimeReportExists(monthlyTimeReport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListMonthlyTimeReports));
            }
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "ReportStatusName", "Id", monthlyTimeReport.ReportStatusId);
            ViewData["WeeklyTimeReportId"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId);
            ViewData["WeeklyTimeReportId1"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId1);
            ViewData["WeeklyTimeReportId2"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId2);
            ViewData["WeeklyTimeReportId3"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId3);
            ViewData["WeeklyTimeReportId4"] = new SelectList(_context.WeeklyTimeReport, "Id", "WTRName", monthlyTimeReport.WeeklyTimeReportId4);
            return View(monthlyTimeReport);
        }

        // GET: MonthlyTimeReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyTimeReport = await _context.MonthlyTimeReport
                .Include(m => m.ReportStatus)
                .Include(m => m.WTR1)
                .Include(m => m.WTR1.Emloyee)
                .Include(m => m.WTR2)
                .Include(m => m.WTR2.Emloyee)
                .Include(m => m.WTR3)
                .Include(m => m.WTR3.Emloyee)
                .Include(m => m.WTR4)
                .Include(m => m.WTR4.Emloyee)
                .Include(m => m.WTR5)
                .Include(m => m.WTR5.Emloyee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthlyTimeReport == null)
            {
                return NotFound();
            }

            return View(monthlyTimeReport);
        }

        // POST: MonthlyTimeReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthlyTimeReport = await _context.MonthlyTimeReport.FindAsync(id);
            _context.MonthlyTimeReport.Remove(monthlyTimeReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListMonthlyTimeReports));
        }

        private bool MonthlyTimeReportExists(int id)
        {
            return _context.MonthlyTimeReport.Any(e => e.Id == id);
        }
    }
}
