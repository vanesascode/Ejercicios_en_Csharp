var numbers = new[] { 1, 5, 3, 6, 13 };

Console.WriteLine("Is any larger than 10" + IsAny(numbers, IsLargerThanTen));

Func<int, bool> isEven = IsNumberEven;
Console.WriteLine("Is any number even" + IsAny(numbers, isEven));


//A lambda expression is a concise way to define an anonymous function.

// Lambda Expression as a parameter: 

Console.WriteLine("Is any number odd" + IsAny(numbers, x => x % 2 != 0));

//the lambda expression is assigned to a named variable printResults:

Action<int, bool> printResults = (x, y) => Console.WriteLine($"The results are {x} and {y}");
printResults(5, false);


///////////////////
///

Exercise exercise = new Exercise();
string myText = "Hola gatete Dante";
int result2 = exercise.GetLength(myText);
Console.WriteLine($"lenght of text {result2}");

///////////////////
///

int result3 = exercise.GetRandomNumberBetween1And10();
Console.WriteLine(result3);

Console.ReadKey();





bool IsLargerThanTen(int number)
{
    return number > 10;
}

bool IsNumberEven(int number)
{
    return number % 2 == 0;
}


Func<int, bool> isItEven = x => x % 2 == 0;
bool result = isItEven(4);



bool IsAny(IEnumerable<int> numbers, Func<int, bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
        {
            return true;
        }
    }
    return false;
}

public class Exercise
{
    public Func<string, int> GetLength = (text) => text.Length;
    public Func<int> GetRandomNumberBetween1And10 = () => new Random().Next(1, 11);
}