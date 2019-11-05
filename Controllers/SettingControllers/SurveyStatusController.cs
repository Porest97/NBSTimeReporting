using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Data;
using NBSTimeReporting.Models.SettingModels;
using NBSTimeReporting.Models.ViewModels;

namespace NBSTimeReporting.Controllers.SettingControllers
{
    public class SurveyStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveyStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SurveyStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.SurveyStatus.ToListAsync());
        }

        // GET: ListSurveyStatuses
        public IActionResult ListSurveyStatuses()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                SurveyStatuses = _context.SurveyStatus.ToList()
            };
            return View(settingsViewModel);
        }

        // GET: SurveyStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyStatus = await _context.SurveyStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surveyStatus == null)
            {
                return NotFound();
            }

            return View(surveyStatus);
        }

        // GET: SurveyStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SurveyStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SurveyStatusName")] SurveyStatus surveyStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveyStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSurveyStatuses));
            }
            return View(surveyStatus);
        }

        // GET: SurveyStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyStatus = await _context.SurveyStatus.FindAsync(id);
            if (surveyStatus == null)
            {
                return NotFound();
            }
            return View(surveyStatus);
        }

        // POST: SurveyStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SurveyStatusName")] SurveyStatus surveyStatus)
        {
            if (id != surveyStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveyStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyStatusExists(surveyStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListSurveyStatuses));
            }
            return View(surveyStatus);
        }

        // GET: SurveyStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyStatus = await _context.SurveyStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surveyStatus == null)
            {
                return NotFound();
            }

            return View(surveyStatus);
        }

        // POST: SurveyStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveyStatus = await _context.SurveyStatus.FindAsync(id);
            _context.SurveyStatus.Remove(surveyStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListSurveyStatuses));
        }

        private bool SurveyStatusExists(int id)
        {
            return _context.SurveyStatus.Any(e => e.Id == id);
        }
    }
}
