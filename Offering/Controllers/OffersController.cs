using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Data;
using NBSTimeReporting.Offering.DataModels;
using NBSTimeReporting.Offering.ViewModels;

namespace NBSTimeReporting.Offering.Controllers
{
    public class OffersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Site);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: ListOffers
        public IActionResult ListOffers()
        {
            var offersViewModel = new OffersViewModel()
            {
                Offers = _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Site)
                .ToList()
            };
            return View(offersViewModel);
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTimeOffered,PersonId,SiteId,TicketNumber,Description,DateTimeScheduledStart,DateTimeScheduledEnd,HoursOnSite,PricePerHour,KostHours,KostMtrl,Riskfaktor,TotalOfferAmount")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.Offer
                    .Include(o => o.Employee)
                    .Include(o => o.Site);
                offer.KostHours = offer.HoursOnSite * offer.PricePerHour;

                offer.TotalOfferAmount = (offer.KostHours + offer.KostMtrl) * offer.Riskfaktor;
                                             

                _context.Add(offer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListOffers));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", offer.PersonId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", offer.SiteId);
            return View(offer);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", offer.PersonId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", offer.SiteId);
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTimeOffered,PersonId,SiteId,TicketNumber,Description,DateTimeScheduledStart,DateTimeScheduledEnd,HoursOnSite,PricePerHour,KostHours,KostMtrl,Riskfaktor,TotalOfferAmount")] Offer offer)
        {
            if (id != offer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.Offer
                   .Include(o => o.Employee)
                   .Include(o => o.Site);
                    offer.KostHours = offer.HoursOnSite * offer.PricePerHour;

                    offer.TotalOfferAmount = (offer.KostHours + offer.KostMtrl) * offer.Riskfaktor;

                    _context.Update(offer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListOffers));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", offer.PersonId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "SiteName", offer.SiteId);
            return View(offer);
        }

        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offer = await _context.Offer.FindAsync(id);
            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListOffers));
        }

        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.Id == id);
        }
    }
}
