﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDVTracker.Data;
using DDVTracker.Models;

namespace DDVTracker.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly DreamlightDbContext _context;

        public IngredientsController(DreamlightDbContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var dreamlightDbContext = _context.Ingredients.Include(i => i.GameVersion);
            return View(await dreamlightDbContext.ToListAsync());
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = _context.Ingredients
                .Include(i => i.GameVersion)
                .Include(i => i.MealIngredients)
                    .ThenInclude(mi => mi.Meal)
                .FirstOrDefault(i => i.IngredientId == id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return PartialView("_IngredientDetails", ingredient);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,GameVersionId,IngredientName,IngredientCategory,BuyPrice,SellsFor,Energy,GrowTime,Water,Yield,LocationId,Method,Notes")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", ingredient.GameVersionId);
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", ingredient.GameVersionId);
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,GameVersionId,IngredientName,IngredientCategory,BuyPrice,SellsFor,Energy,GrowTime,Water,Yield,LocationId,Method,Notes")] Ingredient ingredient)
        {
            if (id != ingredient.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IngredientId))
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
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", ingredient.GameVersionId);
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .Include(i => i.GameVersion)
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IngredientId == id);
        }
    }
}
