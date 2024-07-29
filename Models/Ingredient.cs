using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DDVTracker.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        /// <summary>
        /// Foreign key for GameVersionId of the game the Ingredient is included in
        /// Navigation property for the GameVersion
        /// </summary>
        public int GameVersionId { get; set; }
        public GameVersion? GameVersion { get; set; }

        public string IngredientName { get; set; }

        /// <summary>
        /// Type of ingredient i.e. fruit, vegetable, fish, etc.
        /// </summary>
        public string? IngredientCategory { get; set; }

        /// <summary>
        /// Price to buy from stall
        /// </summary>
        public int? BuyPrice { get; set; }

        /// <summary>
        /// Price to sell to stall
        /// </summary>
        public int? SellsFor { get; set; }

        /// <summary>
        /// Energy gained from eating
        /// </summary>
        public int? Energy { get; set; }

        /// <summary>
        /// Time to grow crop in real time
        /// </summary>
        public string? GrowTime { get; set; }

        /// <summary>
        /// How many times it needs to be watered
        /// </summary>
        public int? Water { get; set; }

        /// <summary>
        /// Yield per harvest of one crop
        /// </summary>
        public int? Yield { get; set; }

        /// <summary>
        /// Location where the ingredient can be found
        /// </summary>
        public int? LocationId { get; set; }

        /// <summary>
        /// How to obtain the ingredient
        /// </summary>
        public string? Method { get; set; }

        /// <summary>
        /// Additional info for the ingredient
        /// i.e. quest to be completed first
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Navigation property for Meals containing the ingredient.
        /// </summary>
        public ICollection<Meal>? Meals { get; set; }

        
        //public ICollection<MealIngredient>? MealIngredients { get; set; }
    }
}
