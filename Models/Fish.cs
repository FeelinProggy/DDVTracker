using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DDVTracker.Models
{
    public class Fish
    {
        [Key]
        public int FishId { get; set; }

        /// <summary>
        /// Foreign key for GameVersionId of the game the character is included in
        /// Navigation property for the GameVersion
        /// </summary>
        public int GameVersionId { get; set; }
        public GameVersion? GameVersion { get; set; }

        public string FishName { get; set; }

        /// <summary>
        /// to save the character's image
        /// </summary>
        [DisplayName("Image")]
        public byte[]? FishImage { get; set; }


        public string? RippleColor { get; set; }

        /// <summary>
        /// Price to buy from stall
        /// </summary>
        public int? SellsFor { get; set; }

        /// <summary>
        /// Energy gained from eating
        /// </summary>
        public int? Energy { get; set; }

        /// <summary>
        /// Addiiotnal info for the fish
        /// i.e. times or weather conditions
        /// </summary>
        public string? Notes { get; set; }


        // Navigation property for the FishLocation
        public ICollection<FishLocation>? FishLocations { get; set; }

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

        /// <summary>
        /// Used to store the selected location ids from the form to create FishLocation objects
        /// </summary>
        [NotMapped]
        public List<int>? SelectedLocationIds { get; set; }
    }
}