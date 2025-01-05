// First define the high-level design of the app, before creating any classes yet (except for the main one, in this case the CookiesRecipesApp, whose only
// responsability is to manage the flow of the app): 


using Assignment3_CookiesCookbook.Recipes;
using Assignment3_CookiesCookbook.Recipes.Ingredients;


var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction(new IngredientsRegister()));

cookiesRecipesApp.Run("recipes.txt");

public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    //These dependencies are injected into the CookiesRecipesApp class via its constructor, promoting the Dependency Inversion Principle (DIP) from SOLID principles.
    public CookiesRecipesApp(
        IRecipesRepository recipesRepository,
        IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();

        //var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        //if (ingredients.Count > 0)
        //{
        //    var recipe = new Recipe(ingredients);
        //    allRecipes.Add(recipe);
        //    _recipesRepository.Write(filePath, allRecipes);

        //    _recipesUserInteraction.ShowMessage("Recipe added:");
        //    _recipesUserInteraction.ShowMessage(recipe.ToString());
        //}
        //else
        //{
        //    _recipesUserInteraction.ShowMessage(
        //        "No ingredients have been selected. " +
        //        "Recipe will not be saved.");
        //}

        _recipesUserInteraction.Exit();

    }
}

// the interface doesn't say anything about the console, only the methods needed to communicate with the user. This is because, in the future, we
// may want to communicate not through console but by graphic interface (for example). Then, we avoid breaking the Dependency Inversion Principle, (which says that high-level classes and low-level 
// classes should not depend on each other: that would make classes less reusable and maintanable)
public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
}

public class IngredientsRegister
{

    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>();
    {
        new WheatFlour(),
        new Sugar()
     };

}


public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        // Count() is an extension method for the IEnumerable<AnyType> that comes from the LINQ library, living in the System.Linq namespace
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are:" + Environment.NewLine);

            var counter = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{counter}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++counter;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe!" +
            "Available ingredients are:");

        foreach (var ingredient in _ingredientsRegister.All)
        {

        }

    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
}

public class RecipesRepository : IRecipesRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>
            {
                new WheatFlour(),
                new SpeltFlour(),
            }),
             new Recipe(new List<Ingredient>
            {
                new Sugar(),
                new Cinnamon(),
                new Butter()
            })
        };
    }
}