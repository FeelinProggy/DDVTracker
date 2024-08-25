using System.ComponentModel.DataAnnotations;
#nullable enable
namespace DDVTracker.Models
{
    public class ModelobjectLocations
    {
        public int ObjectId { get; set; }
        public int LocationId { get; set; }
        [Required]
        public string ObjectType { get; set; }
    }
}
