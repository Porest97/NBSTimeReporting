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
    public class EmployeeAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeAccounts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeAccount
                .Include(e => e.AccountStatus)
                .Include(e => e.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListEmployeeAccounts
        public IActionResult ListEmployeeAccounts()
        {
            var employeeAccountViewModel = new EmployeeAccountsViewModel()
            {
                EmployeeAccounts = _context.EmployeeAccount
                .Include(e => e.AccountStatus)
                .Include(e => e.Employee)
                .ToList()
            };
            return View(employeeAccountViewModel);
        }

        // GET: EmployeeAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAccount = await _context.EmployeeAccount
                .Include(e => e.AccountStatus)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeAccount == null)
            {
                return NotFound();
            }

            return View(employeeAccount);
        }

        // GET: EmployeeAccounts/Create
        public IActionResult Create()
        {
            ViewData["AccountStatusId"] = new SelectList(_context.AccountStatus, "Id", "AccountStatusName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: EmployeeAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountStatusId,AccountNumber,PersonId,EmployeeAccountDescription")] EmployeeAccount employeeAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListEmployeeAccounts));
            }
            ViewData["AccountStatusId"] = new SelectList(_context.AccountStatus, "Id", "AccountStatusName", employeeAccount.AccountStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "´FullName", employeeAccount.PersonId);
            return View(employeeAccount);
        }

        // GET: EmployeeAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAccount = await _context.EmployeeAccount.FindAsync(id);
            if (employeeAccount == null)
            {
                return NotFound();
            }
            ViewData["AccountStatusId"] = new SelectList(_context.AccountStatus, "Id", "AccountStatusName", employeeAccount.AccountStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "´FullName", employeeAccount.PersonId);
            return View(employeeAccount);
        }

        // POST: EmployeeAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountStatusId,AccountNumber,PersonId,EmployeeAccountDescription")] EmployeeAccount employeeAccount)
        {
            if (id != employeeAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAccountExists(employeeAccount.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListEmployeeAccounts));
            }
            ViewData["AccountStatusId"] = new SelectList(_context.AccountStatus, "Id", "AccountStatusName", employeeAccount.AccountStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "´FullName", employeeAccount.PersonId);
            return View(employeeAccount);
        }

        // GET: EmployeeAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAccount = await _context.EmployeeAccount
                .Include(e => e.AccountStatus)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeAccount == null)
            {
                return NotFound();
            }

            return View(employeeAccount);
        }

        // POST: EmployeeAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeAccount = await _context.EmployeeAccount.FindAsync(id);
            _context.EmployeeAccount.Remove(employeeAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListEmployeeAccounts));
        }

        private bool EmployeeAccountExists(int id)
        {
            return _context.EmployeeAccount.Any(e => e.Id == id);
        }
    }
}
