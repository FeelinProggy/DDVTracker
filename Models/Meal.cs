using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDVTracker.Models
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }

        /// <summary>
        /// Foreign key for GameVersionId of the game the Meal is included in
        /// Navigation property for the GameVersion
        /// </summary>
        public int GameVersionId { get; set; }
        public GameVersion? GameVersion { get; set; }

        public string MealName { get; set; }

        /// <summary>
        /// Type of meal category: Appetizer, Entree, Dessert.
        /// </summary>
        public string? MealType { get; set; }

        /// <summary>
        /// Price to sell to stall
        /// </summary>
        public int? SellsFor { get; set; }

        /// <summary>
        /// Energy gained from eating
        /// </summary>
        public int? Energy { get; set; }

        /// <summary>
        /// Navigation property for the Meal's Ingredients
        /// </summary>
        public ICollection<Ingredient>? Ingredients { get; set; }

        public ICollection<MealIngredient>? MealIngredients { get; set; }


        [NotMapped]
        public List<int>? SelectedIngredientIds { get; set; }

        // Calculated property for star rating
        public int? StarRating
        {
            get
            {
                return MealIngredients?.Count ?? 0;
            }
        }
    }
}
