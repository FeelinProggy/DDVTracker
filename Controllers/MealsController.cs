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
    public class MealsController : Controller
    {
        private readonly DreamlightDbContext _context;

        public MealsController(DreamlightDbContext context)
        {
            _context = context;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            var dreamlightDbContext = _context.Meals.Include(m => m.GameVersion);
            return View(await dreamlightDbContext.ToListAsync());
        }

        // GET: Meals/
        [HttpGet]
        [Authorize(Policy = "RequireModeratorRole")]
        public IActionResult Create()
        {
            var allIngredients = _context.Ingredients.ToList();

            ViewBag.Ingredients = allIngredients.Select(i => new SelectListItem
            {
                Value = i.IngredientId.ToString(),
                Text = i.IngredientName
            }).ToList();

            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName");
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireModeratorRole")]
        public async Task<IActionResult> Create([Bind("MealId,GameVersionId,MealName,MealType,SellsFor,Energy")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                // Save the Meal object first to get the MealId
                _context.Add(meal);
                await _context.SaveChangesAsync();

                // Then save the MealIngredients
                if (meal.SelectedIngredientIds != null)
                {
                    foreach (var ingredientId in meal.SelectedIngredientIds)
                    {
                        var mealIngredient = new MealIngredient
                        {
                            MealId = meal.MealId,
                            IngredientId = ingredientId
                        };

                        _context.Add(mealIngredient);
                    }

                    // Save changes for MealIngredients
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", meal.GameVersionId);
            ViewBag.Ingredients = _context.Ingredients.Select(i => new SelectListItem
            {
                Value = i.IngredientId.ToString(),
                Text = i.IngredientName
            }).ToList();

            return View(meal);
        }

        // GET: Meals/Edit/5
        [Authorize(Policy = "RequireModeratorRole")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.FindAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            var allIngredients = _context.Ingredients.ToList();
            var mealIngredients = _context.MealIngredients.Where(mi => mi.MealId == meal.MealId).Select(mi => mi.IngredientId).ToList();

            ViewBag.Ingredients = allIngredients.Select(i => new SelectListItem
            {
                Value = i.IngredientId.ToString(),
                Text = i.IngredientName,
                Selected = mealIngredients.Contains(i.IngredientId)
            }).ToList();

            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", meal.GameVersionId);
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealId,GameVersionId,MealName,MealType,SellsFor,Energy")] Meal meal)
        {
            if (id != meal.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(meal.MealId))
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
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", meal.GameVersionId);
            return View(meal);
        }

        // GET: Meals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.GameVersion)
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal != null)
            {
                _context.Meals.Remove(meal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.MealId == id);
        }



        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.GameVersion)
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }
    }
}
