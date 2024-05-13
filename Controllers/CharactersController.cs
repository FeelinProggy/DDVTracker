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
    public class CharactersController : Controller
    {
        private readonly DreamlightDbContext _context;

        public CharactersController(DreamlightDbContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var dreamlightDbContext = _context.Characters.Include(c => c.GameVersion);
            return View(await dreamlightDbContext.ToListAsync());
        }

        // GET: Characters/Create
        [Authorize(Roles = IdentityHelper.Master + "," + IdentityHelper.Admin + "," + IdentityHelper.Moderator)]
        public IActionResult Create()
        {
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// For admins to create new character objects to display. 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="CharacterImage">Will check if an image has been selected and then convert it
        /// to be stored in the database as varbinary</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterId,GameVersionId,CharacterName,isUnlocked,CharacterLevel," +
        "AssignedSkill,FavoriteThing1,FavoriteThing2,FavoriteThing3")] Character character, IFormFile? CharacterImage)
        {
            if (ModelState.IsValid)
            {
                if (CharacterImage != null) { 
                        using (var memoryStream = new MemoryStream())
                        {
                            await CharacterImage.CopyToAsync(memoryStream);
                            character.CharacterImage = memoryStream.ToArray();
                        }
                }
                    _context.Add(character);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", character.GameVersionId);
                return View(character);
            }

        // GET: Characters/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", character.GameVersionId);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterId,GameVersionId,CharacterName,isUnlocked,CharacterLevel," +
            "AssignedSkill,FavoriteThing1,FavoriteThing2,FavoriteThing3")] Character character, IFormFile? CharacterImage)
        {
            if (id != character.CharacterId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                var existingCharacter = await _context.Characters.AsNoTracking().FirstOrDefaultAsync(c => c.CharacterId == id);
                if (CharacterImage != null && CharacterImage.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await CharacterImage.CopyToAsync(memoryStream);
                        character.CharacterImage = memoryStream.ToArray();
                    }
                }
                else
                {
                    character.CharacterImage = existingCharacter.CharacterImage;
                }
            
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", character.GameVersionId);
            return View(character);
        }

        // GET: Characters/Delete/5
        [Authorize(Roles = IdentityHelper.Master + "," + IdentityHelper.Admin + "," + IdentityHelper.Moderator)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.GameVersion)
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.GameVersion)
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }
    }
}
