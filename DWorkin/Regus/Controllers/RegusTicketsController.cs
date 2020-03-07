using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.DWorkin.Regus.DataModels;
using NBSTimeReporting.Data;
using NBSTimeReporting.DWorkin.Regus.ViewModels;

namespace NBSTimeReporting.DWorkin.Regus.Controllers
{
    public class RegusTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegusTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegusTickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegusTicket
                .Include(r => r.Creator)
                .Include(r => r.FEAssigned)
                .Include(r => r.Receiver)
                .Include(r => r.Site)
                .Include(r => r.TicketPriority)
                .Include(r => r.TicketStatus)
                .Include(r => r.TicketType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegusListTickets
        public IActionResult ListRegusTickets()
        {


            var regusTicketsViewModel = new RegusTicketsViewModel()
            {
                RegusTickets = _context.RegusTicket
                .Include(t => t.Creator)
                .Include(t => t.FEAssigned)
                .Include(t => t.Receiver)
                .Include(t => t.Site)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.TicketType).Where(t => t.TicketStatusId < 5)
                .ToList()
            };
            return View(regusTicketsViewModel);
        }

        // GET: RegusTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regusTicket = await _context.RegusTicket
                .Include(r => r.Creator)
                .Include(r => r.FEAssigned)
                .Include(r => r.Receiver)
                .Include(r => r.Site)
                .Include(r => r.TicketPriority)
                .Include(r => r.TicketStatus)
                .Include(r => r.TicketType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regusTicket == null)
            {
                return NotFound();
            }

            return View(regusTicket);
        }

        // GET: RegusTickets/Create
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

        // POST: RegusTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketPriorityId,TicketStatusId,TicketTypeId,RegusTicketNumber,IncidentNumber,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,WLNumber,WLHours")] RegusTicket regusTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regusTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListRegusTickets));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId2);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", regusTicket.SiteId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriority, "Id", "TicketPriorityName", regusTicket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatus, "Id", "TicketStatusName", regusTicket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketType, "Id", "TicketTypeName", regusTicket.TicketTypeId);
            return View(regusTicket);
        }

        // GET: RegusTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regusTicket = await _context.RegusTicket.FindAsync(id);
            if (regusTicket == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId2);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", regusTicket.SiteId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriority, "Id", "TicketPriorityName", regusTicket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatus, "Id", "TicketStatusName", regusTicket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketType, "Id", "TicketTypeName", regusTicket.TicketTypeId);
            return View(regusTicket);
        }

        // POST: RegusTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketPriorityId,TicketStatusId,TicketTypeId,RegusTicketNumber,IncidentNumber,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,WLNumber,WLHours")] RegusTicket regusTicket)
        {
            if (id != regusTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regusTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegusTicketExists(regusTicket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListRegusTickets));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId2);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", regusTicket.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", regusTicket.SiteId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriority, "Id", "TicketPriorityName", regusTicket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatus, "Id", "TicketStatusName", regusTicket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketType, "Id", "TicketTypeName", regusTicket.TicketTypeId);
            return View(regusTicket);
        }

        // GET: RegusTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regusTicket = await _context.RegusTicket
                .Include(r => r.Creator)
                .Include(r => r.FEAssigned)
                .Include(r => r.Receiver)
                .Include(r => r.Site)
                .Include(r => r.TicketPriority)
                .Include(r => r.TicketStatus)
                .Include(r => r.TicketType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regusTicket == null)
            {
                return NotFound();
            }

            return View(regusTicket);
        }

        // POST: RegusTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regusTicket = await _context.RegusTicket.FindAsync(id);
            _context.RegusTicket.Remove(regusTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListRegusTickets));
        }

        private bool RegusTicketExists(int id)
        {
            return _context.RegusTicket.Any(e => e.Id == id);
        }
    }
}
