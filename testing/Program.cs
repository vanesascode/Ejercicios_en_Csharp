//The Engine class is the dependency.
Engine engine2 = new Engine();
engine2.Start();

Car car = new Car();
car.StartCar();

public class Engine
{
    public void Start()
    {
        Console.WriteLine("Engine started");
    }
}

//The Car class has a direct dependency on the Engine class, because it creates an instance of Engine in its constructor.
public class Car
{
    //The private access modifier means that this field can only be accessed within the Car class itself, and not from outside the class.
    //field declaration
    //This means that the Car class has a private variable named engine that can hold a reference to an instance of the Engine class.
    private Engine engine;


    //A constructor is a special method in a class that is used to initialize objects of that class.
    //In C#, a constructor is defined like a method, but it has the same name as the class and doesn't have a return type.
    //It is called when a new Car object is created
    public Car()
    {
        //assignment statement. 
        engine = new Engine();
    }

    public void StartCar()
    {
        engine.Start();
        Console.WriteLine("Car started");
    }
}