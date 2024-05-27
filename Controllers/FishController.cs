using System;
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
        [HttpGet]
        [Authorize(Policy = "RequireModeratorRole")]
        public IActionResult Create()
        {
            var allLocations = _context.Locations.ToList();

            ViewBag.Locations = allLocations.Select(l => new SelectListItem
            {
                Value = l.LocationId.ToString(),
                Text = l.LocationName
            }).ToList();

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
        public async Task<IActionResult> Create([Bind("FishId,GameVersionId,FishName,SelectedLocationIds,RippleColor")] Fish fish, IFormFile? FishImage)
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

                // Save the Fish object first to generate a FishId
                _context.Add(fish);
                await _context.SaveChangesAsync();

                // Then create FishLocation objects for each selected location
                if (fish.SelectedLocationIds != null)
                {
                    fish.FishLocations = fish.SelectedLocationIds.Select(id => new FishLocation { FishId = fish.FishId, LocationId = id }).ToList();
                    _context.AddRange(fish.FishLocations);
                    await _context.SaveChangesAsync();
                }
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
        public async Task<IActionResult> Edit(int id, [Bind("FishId,GameVersionId,FishName,SelectedLocationIds,RippleColor")] Fish fish, IFormFile? FishImage)
        {
            if (id != fish.FishId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingFish = await _context.Fish.Include(f => f.FishLocations).SingleAsync(f => f.FishId == id);
                if (FishImage != null && FishImage.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await FishImage.CopyToAsync(memoryStream);
                        existingFish.FishImage = memoryStream.ToArray(); // Update existingFish.FishImage
                    }
                }
                else
                {
                    fish.FishImage = existingFish.FishImage;
                }
                // Update the properties of the existing Fish object
                existingFish.GameVersionId = fish.GameVersionId;
                existingFish.FishName = fish.FishName;
                existingFish.RippleColor = fish.RippleColor;

                // Get the current list of Location IDs
                var currentLocationIds = existingFish.FishLocations.Select(fl => fl.LocationId).ToList();

                // Get the list of new Location IDs
                var newLocationIds = fish.SelectedLocationIds ?? new List<int>();

                // Find the Location IDs to add and remove
                var locationIdsToAdd = newLocationIds.Except(currentLocationIds).ToList();
                var locationIdsToRemove = currentLocationIds.Except(newLocationIds).ToList();

                // Add new FishLocation objects
                foreach (var locationId in locationIdsToAdd)
                {
                    var fishLocation = new FishLocation { FishId = existingFish.FishId, LocationId = locationId };
                    existingFish.FishLocations.Add(fishLocation);
                }

                // Remove FishLocation objects
                foreach (var locationId in locationIdsToRemove)
                {
                    var fishLocation = existingFish.FishLocations.Single(fl => fl.LocationId == locationId);
                    existingFish.FishLocations.Remove(fishLocation);
                }

                _context.Update(existingFish);
                await _context.SaveChangesAsync();

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
