namespace Assignment3_CookiesCookbook.Recipes.Ingredients
{
    public abstract class Ingredient
    {
        public abstract int Id { get; }
        public abstract string Name { get; }

        // remember this defines a getter-only property:
        public virtual string PreparationInstructions =>
            "Add to other ingredients.";
    }
}