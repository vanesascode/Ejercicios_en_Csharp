

//When to use both Abstract classes & interfaces: You can define
//an abstract class that implements one or more interfaces.
//This provides a way to share implementation and still benefit
//from the flexibility of interfaces.

//ALSO: Interface with default implementation: Some languages,
//like C# 8.0 and later, allow you to define default implementations
//for interfaces. This provides a way to provide a default
//implementation while still using an interface.


var gascar = new Car(new GasolineEngine());
gascar.Drive();
gascar.Start();
gascar.Stop();


var elcar = new Car(new ElectricEngine());
elcar.Drive();
elcar.Start();
elcar.Stop();

public interface IEngine
{
    void Start();
    void Stop();
}

//la clase Vehicle no implementa la interfaz IEngine
//porque no es un motor, sino un vehículo que utiliza un motor.
//En su lugar, utiliza la interfaz IEngine como un parámetro de
//constructor para trabajar con cualquier tipo de motor que
//implemente esa interfaz: 
public abstract class Vehicle
{
    //  a protected field is a member of a class that can be accessed
    //  by the class itself and by any class that inherits from it.
    protected readonly IEngine _engine;

    public Vehicle(IEngine engine)
    {
        _engine = engine;
    }

    public void Drive()
    {
        _engine.Start();
        _engine.Stop();
    }
}

public class GasolineEngine : IEngine
{
    public void Start() => Console.WriteLine("Gasoline engine started");
    public void Stop() => Console.WriteLine("Gasoline engine stopped");
}

public class ElectricEngine : IEngine
{
    public void Start() => Console.WriteLine("Electric engine started");
    public void Stop() => Console.WriteLine("Electric engine stopped");
}

public class Car : Vehicle
{
    //constructor chaining: This is making it possible that the Vehicle 
    //class is initialized and Drive() works with the GasolineEngine or
    //the ElectricEngine methods
    public Car(IEngine engine) : base(engine) { }

    public void Start() => Console.WriteLine("Car started");
    public void Stop() => Console.WriteLine("Car stopped");
}

