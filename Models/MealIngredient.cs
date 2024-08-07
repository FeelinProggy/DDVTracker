namespace DDVTracker.Models
{
    public class MealIngredient
    {
        // Composite key for MealId and IngredientId
        public int MealId { get; set; }
        public Meal Meal { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
