Car myNewCar = new Car("Lambo", Color.Blue);

Console.WriteLine(myNewCar.Color);
Console.WriteLine(myNewCar.Name);
myNewCar.PrintColorInfo();

public enum Color
{
    Red,
    Green,
    Blue
}

//an extension method must be a static method in a static class.
//This is because the compiler needs to be able to resolve the method
//call at compile-time, and static classes and methods are essentially
//just a collection of functions that can be called without creating
//an instance of the class:
public static class ColorExtensions
{
    //When you use the this keyword as a parameter modifier,
    //you're telling the compiler that this method is an extension
    //method for the type that follows the this keyword:
    public static string ToHexCode(this Color color)
    {

        switch (color)
        {
            case Color.Red:
                return "#FF0000";
            case Color.Green:
                return "#00FF00";
            case Color.Blue:
                return "#0000FF";
            //This  throws an ArgumentOutOfRangeException exception
            //when the color parameter passed to the ToHexCode method is
            //not one of the expected values (Red, Green, or Blue):

            //The nameof operator allows you to get
            //the name of a variable or parameter as a string.
            //So, e.g.: nameof(color) = color // color = Black

            //null: This is the message that will be displayed when the exception is thrown.
            default:
                throw new ArgumentOutOfRangeException(nameof(color), color, null);
        }
    }
}

public class Car
{
    public string Name { get; set; }
    public Color Color { get; set; }

    public Car(string name, Color color)
    {
        Name = name;
        Color = color;
    }

    public void PrintColorInfo()
    {
        Console.WriteLine($"The {Name} is {Color.ToHexCode()}");
    }
}