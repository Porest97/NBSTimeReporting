﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Assets.DataModels;
using NBSTimeReporting.Data;

namespace NBSTimeReporting.Assets.AssetsControllers
{
    public class AssetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Asset.Include(a => a.AssetBrand).Include(a => a.AssetType).Include(a => a.Site);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.AssetBrand)
                .Include(a => a.AssetType)
                .Include(a => a.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName");
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteId,AssetTypeId,AssetBrandId,Name,MACAddress,Model,SerialNumber,Connectivity,LocalIP,Ethernet1LLDP,Ethernet1")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", asset.AssetBrandId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", asset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", asset.SiteId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", asset.AssetBrandId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", asset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", asset.SiteId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteId,AssetTypeId,AssetBrandId,Name,MACAddress,Model,SerialNumber,Connectivity,LocalIP,Ethernet1LLDP,Ethernet1")] Asset asset)
        {
            if (id != asset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetBrandId"] = new SelectList(_context.Set<AssetBrand>(), "Id", "AssetBrandName", asset.AssetBrandId);
            ViewData["AssetTypeId"] = new SelectList(_context.Set<AssetType>(), "Id", "AssetTypeName", asset.AssetTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", asset.SiteId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.AssetBrand)
                .Include(a => a.AssetType)
                .Include(a => a.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asset = await _context.Asset.FindAsync(id);
            _context.Asset.Remove(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.Id == id);
        }
    }
}
