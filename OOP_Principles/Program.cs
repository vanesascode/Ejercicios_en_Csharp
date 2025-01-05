
using OOP_Principles.Abstract_Class_Example;

var square = new Square(4);
var rectangle = new Rectangle(3, 5);
var circle = new Circle(2.5);

var listShapes = new List<Shape> { square, rectangle, circle };
var differentShapes = ExerciseShapes.GetShapesAreas(listShapes);

foreach (var shape in differentShapes)
{
    Console.WriteLine(shape);
}

////

var nemo = new Lion();
Console.WriteLine(nemo.NumberOfLegs);

var legs = new Exercise().GetCountsOfAnimalsLegs();
foreach (var leg in legs)
{
    Console.WriteLine(leg);
}

////


Animal animal1 = new Animal();
// the following is the same as...
if (animal1 is Lion)
{
    Lion lion1 = (Lion)animal1;
    Console.WriteLine("lion object: " + lion1);
}
//this...
if (animal1 is Lion lion)
{
    Console.WriteLine("lion object: " + lion);
}


//This is better...
if (animal1 is not null) // than this... if(animal1 != null) - because operators can be overloaded
{
    Console.WriteLine(animal1.NumberOfLegs);
}


////

var words = new List<string>
        {
            "apple",
            "banana",
            "cherry",
            "date",
            "elderberry",
            "fig",
            "grape",
            "honeydew",
            "kiwi",
            "lemon"
        };

var processedWords = new Exercise2().ProcessAll(words);
foreach (var word in processedWords)
{
    Console.WriteLine(word);
};

///


Console.WriteLine("Next after winter is " + Season.Winter.Next());


///

List<int> myNumbers = new List<int> { 2, 5, 3, 4, 7, 6, 5, };

var result = myNumbers.TakeEverySecond();

foreach (var number in result)
{

    Console.WriteLine(number);
};

///

int numberToBeTransformed = 7;
var numberTransformed = ExerciseInterface.Transform(numberToBeTransformed);
Console.WriteLine("number transformed " + numberTransformed);




Console.ReadKey();

/// Interfaces


public static class ExerciseInterface
{
    public static int Transform(
        int number)
    {
        var transformations = new List<INumericTransformation>
            {
                new By1Incrementer(),
                new By2Multiplier(),
                new ToPowerOf2Raiser()
            };

        var result = number;
        foreach (var transformation in transformations)
        {
            result = transformation.Transform(result);
        }
        return result;
    }
}

interface INumericTransformation
{
    int Transform(int input);

}

public class By1Incrementer : INumericTransformation
{
    public int Transform(int input) => input + 1;
}

public class By2Multiplier : INumericTransformation
{
    public int Transform(int input) => input * 2;
}

public class ToPowerOf2Raiser : INumericTransformation
{
    public int Transform(int input) => input * input;
}

/// Extension for an enum


public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

public static class SeasonExtensions
{
    public static Season Next(this Season season)
    {
        int seasonAsInt = (int)season;
        int nextSeason = (seasonAsInt + 1) % 4;
        return (Season)nextSeason;

    }
}

// Extension for a List<int> type:

public static class ListOfIntExtensions
{
    public static List<int> TakeEverySecond(this List<int> list)
    {

        List<int> modifiedList = new List<int>();


        for (int i = 0; i < list.Count; i += 2)
        {
            modifiedList.Add(list[i]);
        }
        return modifiedList;
    }
}

//1 - Inheritance and virtual property

public class Exercise
{
    public List<int> GetCountsOfAnimalsLegs()
    {
        var animals = new List<Animal>
            {
                new Lion(),
                new Tiger(),
                new Duck(),
                new Spider()
            };

        var result = new List<int>();
        foreach (var animal in animals)
        {
            result.Add(animal.NumberOfLegs);
        }
        return result;
    }
}

public class Animal
{
    public virtual int NumberOfLegs { get; } = 4;

}

public class Lion : Animal
{


}
public class Tiger : Animal
{

}
public class Duck : Animal
{
    public override int NumberOfLegs { get; } = 2;

}
public class Spider : Animal
{
    public override int NumberOfLegs { get; } = 8;
}


//2 - Inheritance and virtual methods


public class Exercise2
{
    public List<string> ProcessAll(List<string> words)
    {
        var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

        List<string> result = words;
        foreach (var stringsProcessor in stringsProcessors)
        {
            result = stringsProcessor.Process(result);
        }
        return result;
    }
}

class StringsProcessor
{
    public List<string> Process(List<string> strings)
    {
        var result = new List<string>();
        foreach (var text in strings)
        {
            result.Add(ProcessSingle(text));
        }
        return result;
    }
    protected virtual string ProcessSingle(string input) => input;
}

class StringsTrimmingProcessor : StringsProcessor
{
    protected override string ProcessSingle(string input) =>
        input.Substring(0, input.Length / 2);
}

class StringsUppercaseProcessor : StringsProcessor
{
    protected override string ProcessSingle(string input) =>
        input.ToUpper();
}