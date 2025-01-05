
using System.Net.Http.Headers;

var reservation1 = new HotelBooking("Vanesa", new DateTime(2024, 4, 29), 10);
Console.WriteLine(reservation1.GuestName);

var triangle1 = new Triangle(2, 4);
Console.WriteLine(triangle1.AsString());
Console.WriteLine(triangle1.CalculateArea());

var dog1 = new Dog("Walter", "Border Collie", 20);
Console.WriteLine(dog1.Describe());

var dog2 = new Dog("Laxy", 58);
Console.WriteLine(dog2.Describe());

var orderDate = new DateTime(2024, 1, 1);
var order1 = new Order("cat", orderDate);
Console.WriteLine(order1.Date);
Console.WriteLine(order1.Item);
var newDate = new DateTime(2024, 2, 2);
order1.Date = newDate;
Console.WriteLine(order1.Date);

var bankState1 = new DailyAccountState(600, 800);
Console.WriteLine(bankState1.InitialState);
Console.WriteLine(bankState1.Report);

var tuesday = NumberToDayOfWeekTranslator.Translate(2);
Console.WriteLine(tuesday);

var myString = "La,Vanesa,es,guapa";
Console.WriteLine(StringsTransformator.TransformSeparators(myString, ",", " "));


Console.ReadKey();

class HotelBooking
{
    public string GuestName;
    public DateTime StartDate;
    public DateTime EndDate;


    public HotelBooking(string guestName, DateTime startDate, int lengthOfStayInDays)
    {
        GuestName = guestName;
        StartDate = startDate;
        EndDate = startDate.AddDays(lengthOfStayInDays);
    }

}

class Triangle
{
    private int _base;
    private int _height;

    public Triangle(int @base, int height)
    {
        _base = @base;
        _height = height;

    }

    public int CalculateArea()
    {
        return (_base * _height) / 2;
    }

    public string AsString()
    {
        return $"Base is {_base}, height is {_height}";
    }

}


public class Dog
{
    private string _name;
    private string _breed;
    private int _weight;

    public Dog(string name, string breed, int weight)
    {
        _name = name;
        _breed = breed;
        _weight = weight;
    }

    public Dog(string name, int weight) : this(name, "mixed-breed", weight)
    {
    }

    public string Describe()
    {
        return $"This dog is named {_name}, it's a {_breed}, and it weighs {_weight} kilograms, so it's a {DescribeSize()} dog.";

    }

    private string DescribeSize()
    {
        if (_weight < 5)
        {
            return "tiny";
        }
        if (_weight < 30)
        {
            return "medium";
        }
        return "large";
    }
}

public class Order
{
    // property using short syntax: 
    public string Item { get; }

    // backing field, because the property needs validation and cannot use modern syntax:
    private DateTime _date;
    //property:
    public DateTime Date
    {
        get { return _date; }
        set
        {
            if (value.Year == DateTime.Now.Year)
            {
                _date = value;
            }
        }
    }
    public Order(string item, DateTime date)
    {
        Item = item;
        Date = date;
    }
}

public class DailyAccountState
{
    public int InitialState { get; }
    public int SumOfOperations { get; }

    public DailyAccountState(int initialState, int sumOfOperations)
    {
        InitialState = initialState;
        SumOfOperations = sumOfOperations;
    }

    // Computed properties (when properties have to make a big calculation, so they are faster - They look like methods, but they don't end in ())
    public int EndOfDateState => InitialState + SumOfOperations;

    public string Report => $"Day: {DateTime.Now.Day}, month: {DateTime.Now.Month}, year: {DateTime.Now.Year}, initial state: {InitialState}, end of day state: {EndOfDateState}";
}


//Static class
public static class NumberToDayOfWeekTranslator
{
    public static string Translate(int number)
    {
        switch (number)
        {
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thursday";
            case 5:
                return "Friday";
            case 6:
                return "Saturday";
            case 7:
                return "Sunday";
            default:
                return "Invalid day of the week";
        }
    }
}

// Remember that the Split method is non-static, and we call it directly on a string object.

// On the other hand, the string.Join method is static, so we must call it on the string class itself.


public static class StringsTransformator
{
    public static string TransformSeparators(
        string input,
        string originalSeparator,
        string targetSeparator)
    {
        var stringPieces = input.Split(originalSeparator);
        return string.Join(targetSeparator, stringPieces);
        // return input.Replace(originalSeparator, targetSeparator);
    }
}

