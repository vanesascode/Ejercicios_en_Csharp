//DEPENDENCY INJECTION MEANS THE CLASS IS GIVEN THE DEPENDENCIES
//IT NEEDS; IT DoESN'T CREATE THEM ITSELF - It  is a design pattern: a typical solution to a
//commonly occurring problem in software design

//By using dependency injection and defining the Engine class as an abstract class or an interface,
//you can DECOUPLE(When two components are tightly coupled, changes to one component can have a ripple
//effect and impact the other component, making it harder to maintain, modify, or extend the system.)
//the Car class from the specific implementation of the Engine class.

//This makes it easier to create subclasses of the Engine class, such as ElectricEngine,
//GasolineEngine, DieselEngine, etc., without affecting the Car class.

//As long as the subclasses implement the same interface or inherit from the same base class
//as the Engine class, the Car class can work with them without any changes.

//This is an example of the OPEN-CLOSED Principle (OCP) in software design, which states that a
//class should be open for extension but closed for modification.

//By using dependency injection and polymorphism, you can extend the behavior of the Engine
//class without modifying the Car class, making your code more flexible and maintainable.



Car car = new Car(new ElectricEngine());
car.StartCar();

Car gascar = new Car(new GasEngine());
car.StartCar();

public class Engine
{
    //The virtual keyword in C# is used to declare a method
    //or property that can be overridden by derived classes.

    //It is absurd to use a public class when you are going
    //to leave the bodies empty. Use an abstract class instead: 
    public virtual void Start()
    {

    }
    // Eso si, de esta forma, no es obligatorio que el metodo Stop() se sobreescriba
    // en todas las classes que heredan de Engine. Pero es que esto,
    // puede llevar a problemas en el futuro! Mejor, utilizar una clase abstracta.
    public virtual void Stop()
    {

    }
}

public class ElectricEngine : Engine
{
    public override void Start()
    {
        Console.WriteLine("Electric engine started");
    }
}

public class GasEngine : Engine
{
    public override void Start()
    {
        Console.WriteLine("gas engine exploded");
    }

    public override void Stop()
    {
        Console.WriteLine("gas stopped");
    }

}

public class Car
{
    // Para poder injectar una class en otra, esta otra tiene que tener un field
    private Engine engine;

    public Car(Engine engine)
    {
        this.engine = engine;
    }

    public void StartCar()
    {
        engine.Start();
        engine.Stop();
        Console.WriteLine("Car started");
    }
}

//Here we are injecting the Engine class through the constructor of the
//Car class. This is an example of Dependency Injection (DI), a design
//pattern that allows you to decouple objects from their dependencies.

//In this case, the Car class depends on an Engine object to function.
//Instead of creating an Engine object directly within the Car class,
//you are passing an Engine object to the Car class through its constructor.
//This allows you to:

//----Decouple the Car class from a specific implementation of the Engine class.
//----Use different types of engines (e.g., ElectricEngine, GasolineEngine) with the same Car class.
//----Test the Car class with different engines or mock engines.