using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Assets.DataModels;
using NBSTimeReporting.Data;
using NBSTimeReporting.NBSInventory.Models.DataModels;
using NBSTimeReporting.NBSInventory.Models.ViewModels;

namespace NBSTimeReporting.NBSInventory.Controllers
{
    public class NBSAssetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NBSAssetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NBSAssets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NBSAsset
                .Include(n => n.AssetBrand)
                .Include(n => n.AssetStatus)
                .Include(n => n.AssetType)
                .Include(n => n.Location)
                .Include(n => n.Owner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListNBSAssets
        public IActionResult ListNBSAssets()
        {


            var nBSAssetsViewModel = new NBSAssetsViewModel()
            {
                NBSAssets = _context.NBSAsset
                .Include(n => n.AssetBrand)
                .Include(n => n.AssetStatus)
                .Include(n => n.AssetType)
                .Include(n => n.Location)
                .Include(n => n.Owner)
                .ToList()
            };
            return View(nBSAssetsViewModel);
        }


        // GET: NBSAssets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nBSAsset = await _context.NBSAsset
                .Include(n => n.AssetBrand)
                .Include(n => n.AssetStatus)
                .Include(n => n.AssetType)
                .Include(n => n.Location)
                .Include(n => n.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nBSAsset == null)
            {
                return NotFound();
            }

            return View(nBSAsset);
        }

        // GET: NBSAssets/Create
        public IActionResult Create()
        {
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName");
            ViewData["AssetStatusId"] = new SelectList(_context.Set<AssetStatus>(), "Id", "AssetStatusName");
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite");
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            return View();
        }

        // POST: NBSAssets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NBSAssetNumber,NBSAssetName,CompanyId,SiteId,AssetStatusId,AssetTypeId,AssetBrandId,MACAddress,Model,SerialNumber,Connectivity,LocalIP,Ethernet1LLDP,Ethernet1")] NBSAsset nBSAsset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nBSAsset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListNBSAssets));
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", nBSAsset.AssetBrandId);
            ViewData["AssetStatusId"] = new SelectList(_context.Set<AssetStatus>(), "Id", "AssetStatusName", nBSAsset.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", nBSAsset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", nBSAsset.SiteId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", nBSAsset.CompanyId);
            return View(nBSAsset);
        }

        // GET: NBSAssets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nBSAsset = await _context.NBSAsset.FindAsync(id);
            if (nBSAsset == null)
            {
                return NotFound();
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", nBSAsset.AssetBrandId);
            ViewData["AssetStatusId"] = new SelectList(_context.Set<AssetStatus>(), "Id", "AssetStatusName", nBSAsset.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", nBSAsset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", nBSAsset.SiteId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", nBSAsset.CompanyId);
            return View(nBSAsset);
        }

        // POST: NBSAssets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NBSAssetNumber,NBSAssetName,CompanyId,SiteId,AssetStatusId,AssetTypeId,AssetBrandId,MACAddress,Model,SerialNumber,Connectivity,LocalIP,Ethernet1LLDP,Ethernet1")] NBSAsset nBSAsset)
        {
            if (id != nBSAsset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nBSAsset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NBSAssetExists(nBSAsset.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListNBSAssets));
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", nBSAsset.AssetBrandId);
            ViewData["AssetStatusId"] = new SelectList(_context.Set<AssetStatus>(), "Id", "AssetStatusName", nBSAsset.AssetStatusId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", nBSAsset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", nBSAsset.SiteId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", nBSAsset.CompanyId);
            return View(nBSAsset);
        }

        // GET: NBSAssets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nBSAsset = await _context.NBSAsset
                .Include(n => n.AssetBrand)
                .Include(n => n.AssetStatus)
                .Include(n => n.AssetType)
                .Include(n => n.Location)
                .Include(n => n.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nBSAsset == null)
            {
                return NotFound();
            }

            return View(nBSAsset);
        }

        // POST: NBSAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nBSAsset = await _context.NBSAsset.FindAsync(id);
            _context.NBSAsset.Remove(nBSAsset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListNBSAssets));
        }

        private bool NBSAssetExists(int id)
        {
            return _context.NBSAsset.Any(e => e.Id == id);
        }
    }
}
