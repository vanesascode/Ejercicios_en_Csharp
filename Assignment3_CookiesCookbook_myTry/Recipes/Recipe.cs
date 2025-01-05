using Assignment3_CookiesCookbook.Recipes.Ingredients;

namespace Assignment3_CookiesCookbook.Recipes
{
    public class Recipe
    {
        //IEnumerable is an interface for lists (in fact it is substituting List here), that doesn't have modifying methods, so makes it difficult for someone to modify the list. 
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            var steps = new List<string>();
            foreach (var ingredient in Ingredients)
            {
                steps.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
            }

            return string.Join(Environment.NewLine, steps);
        }

    }
}