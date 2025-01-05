//Both interfaces and abstract classes can declare methods without
//implementing them (the abstract classes using the abstract methods). The key difference is that abstract classes can
//also provide a partial implementation (adding normal methods along to its abstract methods), whereas interfaces cannot.

// SO, use an abstract class only if you need a  a default implementation (a general
// normal method that can be used by all the classes inhereted) that can be inherited by subclasses.

//BUT: Multiple inheritance: When you need to implement multiple abstractions, interfaces are a better choice since
//a class can implement multiple interfaces but inherit from only one class.

//ALSO: Testability: Interfaces make it easier to write unit tests,
//as you can mock out the interface and test the class in isolation.

//BUT: State: When you need to maintain state between classes, an abstract class is a better choice.
//You can define properties and fields that can be inherited by subclasses.

//ALSO: Template method pattern: When you need to define a template method that provides a skeleton
//for subclasses to implement, an abstract class is a better choice.

//AND: Versioning: When you need to maintain backward compatibility, an abstract class is a better choice.
//You can add new methods and properties without breaking existing subclasses.



// PROBABLEMENTE, NUNCA TENGAS QUE TOCAR LA INTERFAZ, Y GRACIAS A ESO, 
// NO TENGAS QUE TOCAR LA CLASE CAR, SINO LAS CLASES QUE SIGUEN LA INTERFAZ Y POR TANTO
// TIENEN LA IMPLEMENTACION CONCRETA PARA LOS METODOS QUE DICE LA INTERFAZ QUE SON
// NECESARIOS. Y SI INJECTAS EN LA CONSTRUCCION DE LA CLASSE, OTRA CLASE CUALQUIERA, 
//PERO QUE SIGA LA INTERFAZ, NO HAY PROBLEMA: El principio de Liskov Substitution
//establece que las subclases deben ser sustituibles por sus superclases.
//En otras palabras, si una clase B es una subclase de una clase A,
//entonces cualquier código que utilice una instancia de A debe poder trabajar
//correctamente con una instancia de B sin necesidad de conocer la diferencia.
// AQUI, la clase ElectricEngine es una subclase de la interfaz Engine.
// El principio de Liskov Substitution establece que cualquier código
// que utilice una instancia de Engine debe poder trabajar correctamente
// con una instancia de ElectricEngine sin necesidad de conocer la diferencia.

Car car = new Car(new ElectricEngine());
car.StartCar();

public interface IEngine
{
    void Start();
}

// "I'm a class that meets the requirements of the IEngine interface":
public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Electric engine started");
    }
}

public class Car
{
    private IEngine engine;

    // En el constructor, injectamos la classe en el field, pasandola primero como 
    //parametro. Aquí la classe no es de un tipo, sino que sigue una interfaz
    public Car(IEngine engine)
    {
        this.engine = engine;
    }

    public void StartCar()
    {
        engine.Start();
        Console.WriteLine("Car started");
    }
}

