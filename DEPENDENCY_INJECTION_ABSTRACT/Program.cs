Car car = new Car(new ElectricEngine());
car.StartCar();

Car gascar = new Car(new GasEngine());
gascar.StartCar();

//abstract: This means that the Engine class cannot be instantiated on its own.
//It's a blueprint for other classes to inherit from.
// PROBABLEMENTE, NUNCA TENGAS QUE TOCAR LA CLASE ABASTRACTA, Y GRACIAS A ESO, 
// NO TENGAS QUE TOCAR LA CLASE CAR, SINO LAS CLASES QUE TIENEN LA IMPLEMENTACION
// CONCRETA PARA LOS METODOS QUE DICE LA CLASE ABSTRACTA QUE SON NECESARIOS:
public abstract class Engine
{
    // Shared state: a boolean indicating whether the engine is running
    protected bool isRunning = false;

    //the Start method must be implemented by any class that inherits from Engine
    public abstract void Start();

    public abstract void Stop();

    // can also implement normal methods, sth that interfaces cannot do: 
    public void OwnMethod()
    {
        Console.WriteLine("this is the Engine own method");
    }

    // A method that uses the shared state
    public void CheckStatus()
    {
        if (isRunning)
        {
            Console.WriteLine("Engine is running");
        }
        else
        {
            Console.WriteLine("Engine is not running");
        }
    }
}

public class ElectricEngine : Engine
{
    public override void Start()
    {
        Console.WriteLine("Electricity flows!");
        isRunning = true; // Update the shared state
    }

    public override void Stop()
    {
        Console.WriteLine("Electric engine stopped");
        isRunning = false; 
    }
}

public class GasEngine : Engine
{
    public override void Start()
    {
        Console.WriteLine("gas explodes"!);
        isRunning = true; 
    }

    public override void Stop()
    {
        Console.WriteLine("gas closed");
        isRunning = false; 

    }
}

public class Car
{
    // Para poder injectar una classe en otra, esta otra tiene que tener un field
    private Engine engine;

    // En el constructor, injectamos la classe en el field, pasandola primero como 
    //parametro. Aquí la classe es de tipo Engine
    public Car(Engine engine)
    {
        this.engine = engine;
    }

    public void StartCar()
    {
        engine.Start();
        engine.CheckStatus();
        engine.Stop();
        engine.CheckStatus();
        engine.OwnMethod();
        Console.WriteLine("Car did it!!!");
    }
}


//Use an abstract class when :

//You want to provide a partial implementation: Abstract classes can have both
//abstract and concrete methods, allowing you to provide a partial implementation
//that can be shared by subclasses.

//You want to define a hierarchy: Abstract classes are useful when you want to
//define a hierarchy of classes, where subclasses inherit behavior from a common base class.

//You want to provide a default implementation: Abstract classes can provide a default
//implementation for methods that can be overridden by subclasses.

//State: When you need to maintain state between classes, an abstract class is a better choice.
//You can define properties and fields that can be inherited by subclasses (such as isRunning)