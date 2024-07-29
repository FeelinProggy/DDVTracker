namespace DDVTracker.Models
{
    public class MealIngredient
    {
        public int MealID { get; set; }
        public Meal Meal { get; set; }
        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
