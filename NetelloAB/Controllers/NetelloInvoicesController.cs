using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Data;
using NBSTimeReporting.Models.SettingModels;
using NBSTimeReporting.NetelloAB.Models.DataModels;
using NBSTimeReporting.NetelloAB.Models.ViewModels;

namespace NBSTimeReporting.NetelloAB.Controllers
{
    public class NetelloInvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NetelloInvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NetelloInvoices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NetelloInvoice
                .Include(n => n.DWWorkLog)
                .Include(n => n.InvoiceStatus)
                .Include(n => n.RegusTicket);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListNetelloInvoices
        public IActionResult ListNetelloInvoices()
        {


            var netelloInvoicesViewModel = new NetelloInvoicesViewModel()
            {
                NetelloInvoices = _context.NetelloInvoice
                .Include(n => n.DWWorkLog)
                .Include(n => n.DWWorkLog.Technician)                
                .Include(n => n.InvoiceStatus)
                .Include(n => n.RegusTicket)
                .Include(n => n.RegusTicket.Site)
                .ToList()
            };
            return View(netelloInvoicesViewModel);
        }

        // GET: NetelloInvoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netelloInvoice = await _context.NetelloInvoice
                .Include(n => n.DWWorkLog)
                .Include(n => n.InvoiceStatus)
                .Include(n => n.RegusTicket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (netelloInvoice == null)
            {
                return NotFound();
            }

            return View(netelloInvoice);
        }

        // GET: NetelloInvoices/Create
        public IActionResult Create()
        {
            ViewData["DWWorkLogId"] = new SelectList(_context.DWWorkLog, "Id", "WLNumber");
            ViewData["InvoiceStatusId"] = new SelectList(_context.Set<InvoiceStatus>(), "Id", "InvoiceStatusName");
            ViewData["RegusTicketId"] = new SelectList(_context.RegusTicket, "Id", "RegusTicketNumber");
            return View();
        }

        // POST: NetelloInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegusTicketId,DWWorkLogId,WLHours,MaterialKost,HourPrice,TotalKost,InvoiceStatusId,DueDate,PayedDate,FoerNoxNumber")] NetelloInvoice netelloInvoice)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.NetelloInvoice
                 .Include(n => n.DWWorkLog)
                .Include(n => n.InvoiceStatus)
                .Include(n => n.RegusTicket);
                netelloInvoice.TotalKost = netelloInvoice.WLHours * netelloInvoice.HourPrice + netelloInvoice.MaterialKost;
                    

                _context.Add(netelloInvoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListNetelloInvoices));
            }
            ViewData["DWWorkLogId"] = new SelectList(_context.DWWorkLog, "Id", "WLNumber", netelloInvoice.DWWorkLogId);
            ViewData["InvoiceStatusId"] = new SelectList(_context.Set<InvoiceStatus>(), "Id", "InvoiceStatusName", netelloInvoice.InvoiceStatusId);
            ViewData["RegusTicketId"] = new SelectList(_context.RegusTicket, "Id", "RegusTicketNumber", netelloInvoice.RegusTicketId);
            return View(netelloInvoice);
        }

        // GET: NetelloInvoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netelloInvoice = await _context.NetelloInvoice.FindAsync(id);
            if (netelloInvoice == null)
            {
                return NotFound();
            }
            ViewData["DWWorkLogId"] = new SelectList(_context.DWWorkLog, "Id", "WLNumber", netelloInvoice.DWWorkLogId);
            ViewData["InvoiceStatusId"] = new SelectList(_context.Set<InvoiceStatus>(), "Id", "InvoiceStatusName", netelloInvoice.InvoiceStatusId);
            ViewData["RegusTicketId"] = new SelectList(_context.RegusTicket, "Id", "RegusTicketNumber", netelloInvoice.RegusTicketId);
            return View(netelloInvoice);
        }

        // POST: NetelloInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegusTicketId,DWWorkLogId,WLHours,MaterialKost,HourPrice,TotalKost,InvoiceStatusId,DueDate,PayedDate,FoerNoxNumber")] NetelloInvoice netelloInvoice)
        {
            if (id != netelloInvoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.NetelloInvoice
                .Include(n => n.DWWorkLog)
               .Include(n => n.InvoiceStatus)
               .Include(n => n.RegusTicket);
                    netelloInvoice.TotalKost = netelloInvoice.WLHours * netelloInvoice.HourPrice + netelloInvoice.MaterialKost;

                    _context.Update(netelloInvoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetelloInvoiceExists(netelloInvoice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListNetelloInvoices));
            }
            ViewData["DWWorkLogId"] = new SelectList(_context.DWWorkLog, "Id", "WLNumber", netelloInvoice.DWWorkLogId);
            ViewData["InvoiceStatusId"] = new SelectList(_context.Set<InvoiceStatus>(), "Id", "InvoiceStatusName", netelloInvoice.InvoiceStatusId);
            ViewData["RegusTicketId"] = new SelectList(_context.RegusTicket, "Id", "RegusTicketNumber", netelloInvoice.RegusTicketId);
            return View(netelloInvoice);
        }

        // GET: NetelloInvoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netelloInvoice = await _context.NetelloInvoice
                .Include(n => n.DWWorkLog)
                .Include(n => n.InvoiceStatus)
                .Include(n => n.RegusTicket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (netelloInvoice == null)
            {
                return NotFound();
            }

            return View(netelloInvoice);
        }

        // POST: NetelloInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var netelloInvoice = await _context.NetelloInvoice.FindAsync(id);
            _context.NetelloInvoice.Remove(netelloInvoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListNetelloInvoices));
        }

        private bool NetelloInvoiceExists(int id)
        {
            return _context.NetelloInvoice.Any(e => e.Id == id);
        }
    }
}
