using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDVTracker.Data;
using DDVTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Azure.Storage.Blobs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;

namespace DDVTracker.Controllers
{
    public class CharactersController : Controller
    {
        private readonly DreamlightDbContext _context;
        private readonly IFileStorageService _fileStorageService;

        public CharactersController(DreamlightDbContext context, IFileStorageService fileStorageService)
        {
            _context = context;
            _fileStorageService = fileStorageService;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var dreamlightDbContext = _context.Characters.Include(c => c.GameVersion);
            return View(await dreamlightDbContext.ToListAsync());
        }

        // GET: Characters/Create
        [Authorize(Policy = "RequireModeratorRole")]
        public IActionResult Create()
        {
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName");
            return View();
        }

        // POST: Characters/Create
        /// <summary>
        /// For admins to create new character objects to display. 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="CharacterImageUpload">Will check if an image has been selected and then convert it
        /// to be stored in the database as varbinary</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireModeratorRole")]
        public async Task<IActionResult> Create([Bind("CharacterId,GameVersionId,CharacterName,isUnlocked,CharacterLevel," +
        "AssignedSkill,FavoriteThing1,FavoriteThing2,FavoriteThing3")] Character character, IFormFile? CharacterImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (CharacterImageUpload != null)
                {
                    var fileName = $"{character.CharacterName}.webp";
                    character.CharacterImageUpload = await _fileStorageService.SaveFileAsync(CharacterImageUpload, "characters", fileName);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterId,GameVersionId,CharacterName,isUnlocked,CharacterLevel," +
            "AssignedSkill,FavoriteThing1,FavoriteThing2,FavoriteThing3")] Character character, IFormFile? CharacterImageUpload)
        {
            if (id != character.CharacterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingCharacter = await _context.Characters.AsNoTracking().FirstOrDefaultAsync(c => c.CharacterId == id);
                if (CharacterImageUpload != null && CharacterImageUpload.Length > 0)
                {
                    var fileName = $"{character.CharacterName}.webp";
                    character.CharacterImageUpload = await _fileStorageService.SaveFileAsync(CharacterImageUpload, "characters", fileName);
                }
                else
                {
                    character.CharacterImageUpload = existingCharacter.CharacterImageUpload;
                }

                _context.Update(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameVersionId"] = new SelectList(_context.GameVersion, "GameVersionId", "GameVersionName", character.GameVersionId);
            return View(character);
        }

        // GET: Characters/Delete/5
        [Authorize(Policy = "RequireModeratorRole")]
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
        [Authorize(Policy = "RequireModeratorRole")]
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
