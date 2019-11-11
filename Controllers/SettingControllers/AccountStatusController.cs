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
    public class AccountStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountStatus.ToListAsync());
        }

        // GET: ListAccountStatuses
        public IActionResult ListAccountStatuses()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                AccountStatuses = _context.AccountStatus.ToList()
            };
            return View(settingsViewModel);
        }

        // GET: AccountStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountStatus == null)
            {
                return NotFound();
            }

            return View(accountStatus);
        }

        // GET: AccountStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountStatusName")] AccountStatus accountStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListAccountStatuses));
            }
            return View(accountStatus);
        }

        // GET: AccountStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatus.FindAsync(id);
            if (accountStatus == null)
            {
                return NotFound();
            }
            return View(accountStatus);
        }

        // POST: AccountStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountStatusName")] AccountStatus accountStatus)
        {
            if (id != accountStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountStatusExists(accountStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListAccountStatuses));
            }
            return View(accountStatus);
        }

        // GET: AccountStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountStatus == null)
            {
                return NotFound();
            }

            return View(accountStatus);
        }

        // POST: AccountStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountStatus = await _context.AccountStatus.FindAsync(id);
            _context.AccountStatus.Remove(accountStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListAccountStatuses));
        }

        private bool AccountStatusExists(int id)
        {
            return _context.AccountStatus.Any(e => e.Id == id);
        }
    }
}
