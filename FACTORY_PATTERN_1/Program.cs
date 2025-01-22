// SEPAREATE CHANGEABLE CODE USING FACTORIES

/*
Este código implementa el patrón de diseño Factory (Fábrica). Este patrón se utiliza para crear objetos (como objetos de tipo 
Cat y Tiger en este ejemplo) sin especificar la clase concreta que se va a instanciar (como lo hace en este ejemplo al usar 
AnimalFactory para crear tanto Cat como Tiger, sin que el código principal tenga que usar new Cat() o new Tiger() directamente). 
En lugar de crear objetos directamente con new (como podría ser new Cat() o new Tiger() directamente en el código que los utiliza, 
en lugar de usar las fábricas), se delega la creación a una "fábrica" (como CatFactory y TigerFactory en este ejemplo, 
cada una encargada de crear instancias de una clase concreta). Esto proporciona una mayor flexibilidad y desacoplamiento en el código.

Vamos a desglosar cómo se manifiesta la flexibilidad y el desacoplamiento en el código:

- Flexibilidad: Imagina que quieres añadir un nuevo tipo de animal, por ejemplo, un perro (Dog). Con el patrón Factory, solo necesitas:
        Crear una nueva clase Dog que implemente la interfaz IAnimal.
        Crear una nueva clase DogFactory que herede de AnimalFactory e implemente el método CreateAnimal() para devolver una instancia de Dog.
No necesitas modificar el código que usa las fábricas (el código principal que crea los animales). Simplemente cambias la fábrica que utilizas

- Desacoplamiento: El código que utiliza las fábricas (el código cliente) no depende de las clases concretas Cat y Tiger. Solo depende de la 
interfaz IAnimal y de la clase abstracta AnimalFactory. Esto significa que puedes cambiar las clases concretas (por ejemplo, modificar la 
implementación de Cat o Tiger) sin afectar al código cliente, siempre y cuando las clases sigan implementando la interfaz IAnimal.
*/

// The CatFactory creates cats
AnimalFactory animalFactory = new CatFactory();
IAnimal animal = animalFactory.CreateAnimal();
animal.DisplayBehavior();

// The TigerFactory creates tigers
animalFactory = new TigerFactory();
animal = animalFactory.CreateAnimal();
animal.DisplayBehavior();


#region Animal hierarchy

interface IAnimal
{
    void DisplayBehavior();
}

class Tiger : IAnimal
{
    public Tiger()
    {
        Console.WriteLine("\nA tiger is created.");
    }
    public void DisplayBehavior()
    {
        Console.WriteLine("""
            It roars.
            It loves to roam in the jungle.
        """);
    }
}

class Cat : IAnimal
{
    public Cat()
    {
        Console.WriteLine("\nA cat is created.");
    }
    public void DisplayBehavior()
    {
        Console.WriteLine("""
            It meows.
            It loves to stay at a home.
        """);
    }
}
#endregion

#region Factory hierarchy

/// <summary>
/// This class contains the "factory method"
/// </summary>
abstract class AnimalFactory
{
    // Deferring the instantiation process
    // to the subclasses.
    public abstract IAnimal CreateAnimal();
}

/// <summary>
/// CatFactory creates cats.
/// </summary>
class CatFactory : AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Cat();
    }
}

/// <summary>
/// TigerFactory creates tigers.
/// </summary>
class TigerFactory : AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Tiger();
    }
}

#endregion