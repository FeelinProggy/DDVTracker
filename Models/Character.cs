﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DDVTracker.Models
{
    public class Character
    {
        /// <summary>
        /// The Character's Id number
        /// </summary>
        [Key]
        public int CharacterId { get; set; }

        /// <summary>
        /// Foreign key for version of the game the character is included in
        /// </summary>
        public int GameVersionId { get; set; }

        /// <summary>
        /// Navigation property for the GameVersion
        /// </summary>
        public GameVersion? GameVersion { get; set; }

        /// <summary>
        /// The name of the character
        /// </summary>
        [Required]
        public string CharacterName { get; set; }

        public string? AcquiredBy { get; set; }

        public string? AcquiredFrom { get; set; }

        public string? Notes { get; set; }


        /// <summary>
        /// to save the character's image
        /// </summary>
        [DisplayName("Image")]
        public byte[]? CharacterImage { get; set; }
        

        /// <summary>
        /// For user to note whether they have unlocked the character
        /// </summary>
        public bool? isUnlocked { get; set; }

        /// <summary>
        /// For user to track Character's level
        /// </summary>
        [Range(1, 10)]
        public int? CharacterLevel { get; set; }

        /// <summary>
        /// For user to note the skill they've assigned to the character
        /// </summary>
        public string? AssignedSkill { get; set; }

        /// <summary>
        /// For user to note the character's favorite
        /// gifts for the day. 3 items reset daily
        /// </summary>
        public string? FavoriteThing1 { get; set; }
        public string? FavoriteThing2 { get; set; }
        public string? FavoriteThing3 { get; set; }

        /// <summary>
        /// Used to convert bit back into and image to be displayed
        /// </summary>
        [NotMapped] // This attribute means the property will not be mapped to a database column
        public string? ImageBase64
        {
            get
            {
                return CharacterImage != null ? Convert.ToBase64String(CharacterImage) : null;
            }
        }

    }
}
