using System.ComponentModel.DataAnnotations;
namespace DDVTracker.Models
{
    public class GameVersion
    {
        [Key]
        public int GameVersionId { get; set; }

        [Required]
        public string GameVersionName { get; set; }

        /// <summary>
        /// Navigation property for Characters.
        /// </summary>
        public ICollection<Character> Characters { get; set; }
    }
}
