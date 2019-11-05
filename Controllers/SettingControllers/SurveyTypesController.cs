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
    public class SurveyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SurveyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SurveyType.ToListAsync());
        }

        // GET: ListSurveyTypes
        public IActionResult ListSurveyTypes()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                SurveyTypes = _context.SurveyType.ToList()
            };
            return View(settingsViewModel);
        }

        // GET: SurveyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyType = await _context.SurveyType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surveyType == null)
            {
                return NotFound();
            }

            return View(surveyType);
        }

        // GET: SurveyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SurveyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SurveyTypeName")] SurveyType surveyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSurveyTypes));
            }
            return View(surveyType);
        }

        // GET: SurveyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyType = await _context.SurveyType.FindAsync(id);
            if (surveyType == null)
            {
                return NotFound();
            }
            return View(surveyType);
        }

        // POST: SurveyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SurveyTypeName")] SurveyType surveyType)
        {
            if (id != surveyType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyTypeExists(surveyType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListSurveyTypes));
            }
            return View(surveyType);
        }

        // GET: SurveyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyType = await _context.SurveyType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surveyType == null)
            {
                return NotFound();
            }

            return View(surveyType);
        }

        // POST: SurveyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveyType = await _context.SurveyType.FindAsync(id);
            _context.SurveyType.Remove(surveyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListSurveyTypes));
        }

        private bool SurveyTypeExists(int id)
        {
            return _context.SurveyType.Any(e => e.Id == id);
        }
    }
}
