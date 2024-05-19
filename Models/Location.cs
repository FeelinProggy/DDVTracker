using System.ComponentModel.DataAnnotations;

namespace DDVTracker.Models
{
    public class Location
    {
        /// <summary>
        /// The Character's Id number
        /// </summary>
        [Key]
        public int LocationId { get; set; }

        /// <summary>
        /// Foreign key for version of the game the character is included in
        /// </summary>
        public int GameVersionId { get; set; }

        /// <summary>
        /// Navigation property for the GameVersion
        /// </summary>
        public GameVersion? GameVersion { get; set; }

        public string LocationName { get; set; }


    }
}
