using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Data;
using NBSTimeReporting.Models.AccountingModels;
using NBSTimeReporting.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Controllers.AccountingControllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transaction
                .Include(t => t.Account)
                .Include(t => t.TransactionType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListTransactions
        public IActionResult ListTransactions()
        {
            var transactionsViewModel = new TransactionsViewModel()
            {
                Transactions = _context.Transaction
                .Include(t => t.Account)
                .Include(t => t.TransactionType)
                .ToList()
            };
            return View(transactionsViewModel);
        }

        // GET: ListTransactionsAccountEva
        public IActionResult ListTransactionsAccountEva()
        {
            var transactionsViewModel = new TransactionsViewModel()
            {
                Transactions = _context.Transaction
                .Include(t => t.Account)
                .Include(t => t.TransactionType).Where(a => a.AccountId == 1)
                .ToList()
            };
            return View(transactionsViewModel);
        }

        // GET: ListTransactionsAccountPer
        public IActionResult ListTransactionsAccountPer()
        {
            var transactionsViewModel = new TransactionsViewModel()
            {
                Transactions = _context.Transaction
                .Include(t => t.Account)
                .Include(t => t.TransactionType).Where(a => a.AccountId == 2)
                .ToList()
            };
            return View(transactionsViewModel);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .Include(t => t.TransactionType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName");
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionType, "Id", "TransactionTypeName");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AccountId,TransactionTypeId,TransactionDateTime,Amount,TransactionText")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListTransactions));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName", transaction.AccountId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionType, "Id", "TransactionTypeName", transaction.TransactionTypeId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName", transaction.AccountId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionType, "Id", "TransactionTypeName", transaction.TransactionTypeId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AccountId,TransactionTypeId,TransactionDateTime,Amount,TransactionText")] Transaction transaction)
        {
            if (id != transaction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListTransactions));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName", transaction.AccountId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionType, "Id", "TransactionTypeName", transaction.TransactionTypeId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .Include(t => t.TransactionType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListTransactions));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.ID == id);
        }
    }
}
