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
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ticket
                .Include(t => t.Creator)
                .Include(t => t.FEAssigned)
                .Include(t => t.Receiver)
                .Include(t => t.Site)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.TicketType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListTickets
        public IActionResult ListTickets()
        {


            var ticketsViewModel = new TicketsViewModel()
            {
                Tickets = _context.Ticket
                .Include(t => t.Creator)
                .Include(t => t.FEAssigned)
                .Include(t => t.Receiver)
                .Include(t => t.Site)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.TicketType)
                .ToList()
            };
            return View(ticketsViewModel);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Creator)
                .Include(t => t.FEAssigned)
                .Include(t => t.Receiver)
                .Include(t => t.Site)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.TicketType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName");
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriority, "Id", "TicketPriorityName");
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatus, "Id", "TicketStatusName");
            ViewData["TicketTypeId"] = new SelectList(_context.TicketType, "Id", "TicketTypeName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketPriorityId,TicketStatusId,TicketTypeId,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,IncidentNumber")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListTickets));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId2);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", ticket.SiteId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriority, "Id", "TicketPriorityName", ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatus, "Id", "TicketStatusName", ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketType, "Id", "TicketTypeName", ticket.TicketTypeId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId2);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", ticket.SiteId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriority, "Id", "TicketPriorityName", ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatus, "Id", "TicketStatusName", ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketType, "Id", "TicketTypeName", ticket.TicketTypeId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketPriorityId,TicketStatusId,TicketTypeId,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,IncidentNumber")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListTickets));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId2);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", ticket.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", ticket.SiteId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriority, "Id", "TicketPriorityName", ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatus, "Id", "TicketStatusName", ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketType, "Id", "TicketTypeName", ticket.TicketTypeId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Creator)
                .Include(t => t.FEAssigned)
                .Include(t => t.Receiver)
                .Include(t => t.Site)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.TicketType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListTickets));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
