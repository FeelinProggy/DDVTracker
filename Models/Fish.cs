/*
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDVTracker.Models.Collections
{
    public class Fish
    {
        public int FishId { get; set; }

        /// <summary>
        /// Foreign key for version of the game the character is included in
        /// </summary>
        public int GameVersionId { get; set; }

        /// <summary>
        /// Navigation property for the GameVersion
        /// </summary>
        public GameVersion? GameVersion { get; set; }

        public string FishName { get; set; }

        /// <summary>
        /// to save the character's image
        /// </summary>
        [DisplayName("Image")]
        public byte[]? FishImage { get; set; }

        public string

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
*/