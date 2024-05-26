﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDVTracker.Data;
using DDVTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace DDVTracker.Controllers
{
    public class FishController : Controller
    {
        private readonly DreamlightDbContext _context;

        public FishController(DreamlightDbContext context)
        {
            _context = context;
        }

        // GET: Fish
        public async Task<IActionResult> Index()
        {
            var dreamlightDbContext = _context.Fish.Include(f => f.GameVersion);
            var fish = _context.Fish.Include(f => f.FishLocations).ThenInclude(fl => fl.Location).ToList();
            return View(await dreamlightDbContext.ToListAsync());
        }


        // GET: Fish/Create
        [Authorize(Policy = "RequireModeratorRole")]
        public IActionResult Create()
        {
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName");
            return View();
        }

        // POST: Fish/Create
        /// <summary>
        /// For admins to create new Fish objects to display. 
        /// </summary>
        /// <param name="fish"></param>
        /// <param name="FishImage">Will check if an image has been selected and then convert it
        /// to be stored in the database as varbinary</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireModeratorRole")]
        public async Task<IActionResult> Create([Bind("FishId,GameVersionId,FishName,FishLocations,RippleColor")] Fish fish, IFormFile? FishImage)
        {
            if (ModelState.IsValid)
            {
                if (FishImage != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await FishImage.CopyToAsync(memoryStream);
                        fish.FishImage = memoryStream.ToArray();
                    }
                }
                _context.Add(fish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", fish.GameVersionId);
            return View(fish);
        }

        // GET: Fish/Edit/5
        [Authorize(Policy = "RequireModeratorRole")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish.FindAsync(id);

            if (fish == null)
            {
                return NotFound();
            }

            var allLocations = _context.Locations.ToList();
            var fishLocations = _context.FishLocations.Where(fl => fl.FishId == fish.FishId).Select(fl => fl.LocationId).ToList();

            ViewBag.Locations = allLocations.Select(l => new SelectListItem
            {
                Value = l.LocationId.ToString(),
                Text = l.LocationName,
                Selected = fishLocations.Contains(l.LocationId)
            }).ToList();

            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", fish.GameVersionId);
            return View(fish);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireModeratorRole")]
        public async Task<IActionResult> Edit(int id, [Bind("FishId,GameVersionId,FishName,FishImage,FishLocations,RippleColor")] Fish fish)
        {
            if (id != fish.FishId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishExists(fish.FishId))
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
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", fish.GameVersionId);
            return View(fish);
        }

        // GET: Fish/Delete/5
        [Authorize(Policy = "RequireModeratorRole")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish
                .Include(f => f.GameVersion)
                .FirstOrDefaultAsync(m => m.FishId == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireModeratorRole")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fish = await _context.Fish.FindAsync(id);
            if (fish != null)
            {
                _context.Fish.Remove(fish);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Fish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish
                .Include(f => f.GameVersion)
                .FirstOrDefaultAsync(m => m.FishId == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }
        private bool FishExists(int id)
        {
            return _context.Fish.Any(e => e.FishId == id);
        }
    }
}