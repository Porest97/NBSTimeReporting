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
    public class WeeklyTimeReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeeklyTimeReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeeklyTimeReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WeeklyTimeReport
                .Include(w => w.Emloyee)
                .Include(w => w.ReportStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WeeklyTimeReports HttpPost !
        [HttpPost]
        public IActionResult Index(WeeklyTimeReport weeklyTimeReport)
        {
            // Sum of all worked hours during the Week !
            var applicationDbContext = _context.WeeklyTimeReport
                .Include(wtr => wtr.Emloyee)
                .Include(wtr => wtr.ReportStatus);
            weeklyTimeReport.WorkedHoursTotal = weeklyTimeReport.WorkedDay1
                + weeklyTimeReport.WorkedDay2
                + weeklyTimeReport.WorkedDay3
                + weeklyTimeReport.WorkedDay4
                + weeklyTimeReport.WorkedDay5 
                + weeklyTimeReport.WorkedDay6
                + weeklyTimeReport.WorkedDay7;
           
            return View(weeklyTimeReport);
        }

        // GET: ListWeeklyTimeReports
        public IActionResult ListWeeklyTimeReports()
        {
            var weeklyTimeReportsViewModel = new WeeklyTimeReportsViewModel()
            {
                WeeklyTimeReports = _context.WeeklyTimeReport
                .Include(w => w.Emloyee)
                .Include(w => w.ReportStatus)
                .ToList()
            };
            return View(weeklyTimeReportsViewModel);
        }

        // GET: ListWeeklyTimeReportsPO
        public IActionResult ListWeeklyTimeReportsPO()
        {
            var weeklyTimeReportsViewModel = new WeeklyTimeReportsViewModel()
            {
                WeeklyTimeReports = _context.WeeklyTimeReport
                .Include(w => w.Emloyee)
                .Include(w => w.ReportStatus).Where(w=>w.PersonId == 1)
                .ToList()
            };
            return View(weeklyTimeReportsViewModel);
        }

        // GET: ListWeeklyTimeReportsJM
        public IActionResult ListWeeklyTimeReportsJM()
        {
            var weeklyTimeReportsViewModel = new WeeklyTimeReportsViewModel()
            {
                WeeklyTimeReports = _context.WeeklyTimeReport
                .Include(w => w.Emloyee)
                .Include(w => w.ReportStatus).Where(w => w.PersonId == 2)
                .ToList()
            };
            return View(weeklyTimeReportsViewModel);
        }

        // GET: WeeklyTimeReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyTimeReport = await _context.WeeklyTimeReport
                .Include(w => w.Emloyee)
                .Include(w => w.ReportStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weeklyTimeReport == null)
            {
                return NotFound();
            }

            return View(weeklyTimeReport);
        }

        // GET: WeeklyTimeReports/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName");
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName");
            return View();
        }

        // POST: WeeklyTimeReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReportStatusId,WeekNumber,FromDate,ToDate,PersonId,Day1,Day1Started,Day1Ended,WorkedDay1,Day2,Day2Started,Day2Ended,WorkedDay2,Day3,Day3Started,Day3Ended,WorkedDay3,Day4,Day4Started,Day4Ended,WorkedDay4,Day5,Day5Started,Day5Ended,WorkedDay5,Day6,Day6Started,Day6Ended,WorkedDay6,Day7,Day7Started,Day7Ended,WorkedDay7,WorkedHoursTotal")] WeeklyTimeReport weeklyTimeReport)
        {
            if (ModelState.IsValid)
            {
                // Sum of all worked hours during the Week !
                var applicationDbContext = _context.WeeklyTimeReport
                    .Include(wtr => wtr.Emloyee)
                    .Include(wtr => wtr.ReportStatus);
                weeklyTimeReport.WorkedHoursTotal = weeklyTimeReport.WorkedDay1
                    + weeklyTimeReport.WorkedDay2
                    + weeklyTimeReport.WorkedDay3
                    + weeklyTimeReport.WorkedDay4
                    + weeklyTimeReport.WorkedDay5
                    + weeklyTimeReport.WorkedDay6
                    + weeklyTimeReport.WorkedDay7;

                _context.Add(weeklyTimeReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListWeeklyTimeReports));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", weeklyTimeReport.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", weeklyTimeReport.ReportStatusId);
            return View(weeklyTimeReport);
        }

        // GET: WeeklyTimeReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyTimeReport = await _context.WeeklyTimeReport.FindAsync(id);
            if (weeklyTimeReport == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", weeklyTimeReport.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", weeklyTimeReport.ReportStatusId);
            return View(weeklyTimeReport);
        }

        // POST: WeeklyTimeReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportStatusId,WeekNumber,FromDate,ToDate,PersonId,Day1,Day1Started,Day1Ended,WorkedDay1,Day2,Day2Started,Day2Ended,WorkedDay2,Day3,Day3Started,Day3Ended,WorkedDay3,Day4,Day4Started,Day4Ended,WorkedDay4,Day5,Day5Started,Day5Ended,WorkedDay5,Day6,Day6Started,Day6Ended,WorkedDay6,Day7,Day7Started,Day7Ended,WorkedDay7,WorkedHoursTotal")] WeeklyTimeReport weeklyTimeReport)
        {
            if (id != weeklyTimeReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Sum of all worked hours during the Week !
                    var applicationDbContext = _context.WeeklyTimeReport
                       .Include(wtr => wtr.Emloyee)
                       .Include(wtr => wtr.ReportStatus);
                    weeklyTimeReport.WorkedHoursTotal = weeklyTimeReport.WorkedDay1
                        + weeklyTimeReport.WorkedDay2
                        + weeklyTimeReport.WorkedDay3
                        + weeklyTimeReport.WorkedDay4
                        + weeklyTimeReport.WorkedDay5
                        + weeklyTimeReport.WorkedDay6
                        + weeklyTimeReport.WorkedDay7;

                    _context.Update(weeklyTimeReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeeklyTimeReportExists(weeklyTimeReport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListWeeklyTimeReports));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", weeklyTimeReport.PersonId);
            ViewData["ReportStatusId"] = new SelectList(_context.ReportStatus, "Id", "ReportStatusName", weeklyTimeReport.ReportStatusId);
            return View(weeklyTimeReport);
        }

        // GET: WeeklyTimeReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyTimeReport = await _context.WeeklyTimeReport
                .Include(w => w.Emloyee)
                .Include(w => w.ReportStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weeklyTimeReport == null)
            {
                return NotFound();
            }

            return View(weeklyTimeReport);
        }

        // POST: WeeklyTimeReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weeklyTimeReport = await _context.WeeklyTimeReport.FindAsync(id);
            _context.WeeklyTimeReport.Remove(weeklyTimeReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListWeeklyTimeReports));
        }

        private bool WeeklyTimeReportExists(int id)
        {
            return _context.WeeklyTimeReport.Any(e => e.Id == id);
        }
    }
}
