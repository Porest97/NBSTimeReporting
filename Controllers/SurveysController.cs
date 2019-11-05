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
    public class SurveysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Survey
                .Include(s => s.SurveyStatus)
                .Include(s => s.SurveyType)
                .Include(s => s.Ticket);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListSurveys
        public IActionResult ListSurveys()
        {


            var surveysViewModel = new SurveysViewModel()
            {
                Surveys = _context.Survey
                .Include(s => s.SurveyStatus)
                .Include(s => s.SurveyType)
                .Include(s => s.Ticket)
                .ToList()
            };
            return View(surveysViewModel);
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .Include(s => s.SurveyStatus)
                .Include(s => s.SurveyType)
                .Include(s => s.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {
            ViewData["SurveyStatusId"] = new SelectList(_context.SurveyStatus, "SurveyStatusName", "Id");
            ViewData["SurveyTypeId"] = new SelectList(_context.SurveyType, "SurveyTypeName", "Id");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "IncidentNumber");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SurveyStatusId,SurveyTypeId,TicketId,Version,SurveyStarted,SurveyEnded,NumberOfAPs,APBrandModel,APFloorMap,NetSpotReport,SpeedTestIMG")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSurveys));
            }
            ViewData["SurveyStatusId"] = new SelectList(_context.SurveyStatus, "Id", "SurveyStatusName", survey.SurveyStatusId);
            ViewData["SurveyTypeId"] = new SelectList(_context.SurveyType, "Id", "SurveyTypeName", survey.SurveyTypeId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "IncidentNumber", survey.TicketId);
            return View(survey);
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            ViewData["SurveyStatusId"] = new SelectList(_context.SurveyStatus, "Id", "SurveyStatusName", survey.SurveyStatusId);
            ViewData["SurveyTypeId"] = new SelectList(_context.SurveyType, "Id", "SurveyTypeName", survey.SurveyTypeId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "IncidentNumber", survey.TicketId);
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SurveyStatusId,SurveyTypeId,TicketId,Version,SurveyStarted,SurveyEnded,NumberOfAPs,APBrandModel,APFloorMap,NetSpotReport,SpeedTestIMG")] Survey survey)
        {
            if (id != survey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListSurveys));
            }
            ViewData["SurveyStatusId"] = new SelectList(_context.SurveyStatus, "Id", "SurveyStatusName", survey.SurveyStatusId);
            ViewData["SurveyTypeId"] = new SelectList(_context.SurveyType, "Id", "SurveyTypeName", survey.SurveyTypeId);
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "IncidentNumber", survey.TicketId);
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .Include(s => s.SurveyStatus)
                .Include(s => s.SurveyType)
                .Include(s => s.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var survey = await _context.Survey.FindAsync(id);
            _context.Survey.Remove(survey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListSurveys));
        }

        private bool SurveyExists(int id)
        {
            return _context.Survey.Any(e => e.Id == id);
        }
    }
}
