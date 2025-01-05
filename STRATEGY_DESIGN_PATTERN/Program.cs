var numbers = new List<int> { 10, 12, -100, 44, 55, -3 };
var filteringStrategySelector = new FilteringStrategySelector();

Console.WriteLine("Select filter:");

//This code, is like: 
Console.WriteLine(
    string.Join
    (
        Environment.NewLine,
        filteringStrategySelector.FilteringStrategiesNames
        )
    );

//this: 
//foreach (var strategyName in filteringStrategySelector.FilteringStrategiesNames)
//{
//    Console.WriteLine(strategyName);
//}

var userInput = Console.ReadLine();



// Adding the right filter: 

Func<int, bool> filteringStrategy;

if (!string.IsNullOrEmpty(userInput))
{
    filteringStrategy = new FilteringStrategySelector().Select(userInput);
}
else
{
    throw new Exception();
}

var result = new Filter().FilterBy(filteringStrategy, numbers);

Print(result);



///////////////////////////////////
///

var words = new[] { "dante", "nemo", "nina" }; // array
var nWords = new Filter().FilterBy(word => word.StartsWith("n"), words);
Console.WriteLine(nWords.GetType()); // list

Console.ReadKey();


void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

public class FilteringStrategySelector // This returns the function asked by the user (SRP)
{
    private readonly Dictionary<string, Func<int, bool>> _filteringStrategies =
        new Dictionary<string, Func<int, bool>>
        {
            ["Even"] = number => number % 2 == 0,
            ["Odd"] = number => number % 2 == 1,
            ["Positive"] = number => number > 0,
            ["Negative"] = number => number < 0,
        };

    public IEnumerable<string> FilteringStrategiesNames =>
        _filteringStrategies.Keys;

    public Func<int, bool> Select(string filteringType)
    {
        if (!_filteringStrategies.ContainsKey(filteringType))
        {
            throw new NotSupportedException(
                $"{filteringType} is not a valid filter");
        }
        return _filteringStrategies[filteringType];
    }
}

public class Filter // This applies the function to the list of numbers supplied by the user (but 
                           //doesn't know anything about the functions (SRP, OCP-cos I won't have to modify this class)
{
    public IEnumerable<T> FilterBy<T>(Func<T, bool> predicate, IEnumerable<T> items) //We use IEnumerable instead of
        //List, so we can iterate anything, even arrays. IEnumerable is more general.
    {
        var result = new List<T>();

        foreach (var item in items)
        {
            if (predicate(item)) //If the predicate function returns true (Func<int, BOOL>),
                                   //(because the number passes the filteringStrategies), the number is included in the filtered list.
            {
                result.Add(item);
            }
        }
        return result;
    }
}