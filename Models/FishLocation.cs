using System.ComponentModel.DataAnnotations;

namespace DDVTracker.Models
{
    public class FishLocation
    {
        [Key]
        public int FishLocationId { get; set; }
        public int FishId { get; set; }
        public Fish Fish { get; set; } 

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
