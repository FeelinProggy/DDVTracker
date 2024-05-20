using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DDVTracker.Models
{
    public class Fish
    {
        public int FishId { get; set; }

        /// <summary>
        /// Foreign key for GameVersionId of the game the character is included in
        /// Navigation property for the GameVersion
        /// </summary>
        public GameVersion? GameVersion { get; set; }
        public int GameVersionId { get; set; }

        public string FishName { get; set; }

        /// <summary>
        /// to save the character's image
        /// </summary>
        [DisplayName("Image")]
        public byte[]? FishImage { get; set; }

        // Navigation property for the FishLocation
        public List<FishLocation>? FishLocations { get; set; }
        public int FishLocationId { get; set; }

        
        public string RippleColor { get; set; }

        /// <summary>
        /// Used to convert bit back into and image to be displayed
        /// </summary>
        [NotMapped] // This attribute means the property will not be mapped to a database column
        public string? ImageBase64
        {
            get
            {
                return FishImage != null ? Convert.ToBase64String(FishImage) : null;
            }
        }
    }
}