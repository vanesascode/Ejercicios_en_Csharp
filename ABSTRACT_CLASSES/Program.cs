//Car myCar = new Car("Red");
//myCar.Start();
//myCar.Honk();
//myCar.Stop();

//Truck myTruck = new Truck("Black");
//myTruck.Start();
//myTruck.Honk();
//myTruck.LoadCargo();
//myTruck.Stop();

///

// I didn't instantiate the Vehicle class directly.
//you can create a list of objects of a certain type (in this case, Vehicle)
//and add instances of classes that inherit from that type (in this case, Car and Truck).

//This is known as polymorphism, which I mentioned earlier. It allows you to
//treat objects of different classes as if they were of the same class,
//as long as they share a common base class or interface.

using System.Reflection;

///
List<Vehicle> vehicles = new List<Vehicle>();

Car myCar2 = new Car("Red");
Truck myTruck2 = new Truck("Black");

vehicles.Add(myCar2);
vehicles.Add(myTruck2);

foreach (Vehicle vehicle in vehicles)
{
    vehicle.Start();
    vehicle.Honk();
    vehicle.Stop();
    //The truck class is just inheriting the implementation from the
    //Car class of the accelerate method, and is not necessary it overrides
    //the accelerate class itself, cos the car class is already doing it.
    vehicle.Accelerate();
}

//Even though the color field is private, the Color property
//provides public get and set access to it in the Truck instance 
Console.WriteLine(myTruck2.Color);
myTruck2.Color = "red";
Console.WriteLine(myTruck2.Color);

Console.WriteLine(myTruck2.Model); // here you have an empty line in the console, cos it isn't
                                   // defined in the constructor. 
myTruck2.Model = "TractorPirineus"; // now here you set it 
Console.WriteLine(myTruck2.Model);

//Abstract classes cannot be instantiated on its own, and must be inherited by another class.
public abstract class Vehicle
{
    //protected: This is the ACCESS MODIFIER, which means that
    //the field can be accessed by the class itself and by any classes that inherit from it.
    private string color;

    //abstract classes can have constructors. The purpose of the constructor
    //in this case is to initialize the color field, which is shared by all vehicles.
    //Even though you can't instantiate the Vehicle class directly, its constructor is still called when you create instances of classes that inherit from it, such as Car and Truck. This is because the constructors of the derived classes (Car and Truck) call the constructor of the base class (Vehicle) using the base keyword.
    public Vehicle(string color)
    {
        //this.color: This refers to the color field of the class.
        this.color = color;
    }

    //This is an abstract property, so it is necessary that it is overriden by the 
    //classes that derive from Vehicle
    public abstract string Model { get; set; }

    //since you have a public property Color that provides get and set access
    //to the color field, it's generally better to use that property instead of
    //accessing the color field directly. This helps to ENCAPSULATE the color
    //field and ensures that any validation or logic in the Color property is executed. If you 
    //didn't have this public property Color, you would have to turn your field protected, so
    //it could be used by the inhereting classes.
    public string Color
    {
        get => color;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El color no puede ser vacío", nameof(value));
            }
            color = value;
        }
    }

    public void Start()
    {
        Console.WriteLine("Vehicle started");
    }

    public void Honk()
    {
        Console.WriteLine("Honk!");
    }

    public virtual void Stop()
    {
        Console.WriteLine("Vehicle stopped");
    }

    //any non-abstract class that inherits from Vehicle will be
    //required to implement this method, because it is abstract:
    public abstract void Accelerate();
}

public class Car : Vehicle
{

    //: base(color): This is called a constructor initializer, and it
    //calls the constructor of the base class (Vehicle) with the color parameter.
    //This allows the Car class to initialize the color field of the Vehicle class. IT'S COMPULSARY TO 
    //OVERRIDE THE CONSTRUCTOR IF THE ABSTRACT CLASS HAS IT. 
    public Car(string color) : base(color)
    {
    }

    private string model;

    public override string Model
    {
        get => model;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El modelo no puede ser vacío", nameof(value));
            }
            model = value;
        }
    }

    public override void Accelerate()
    {
        Console.WriteLine("Car accelerating...");
    }

    public void Start()
    {
        Console.WriteLine("Car started");
    }

    public void Stop()
    {
        Console.WriteLine("Car stopped");
    }
}

//You can also use the Car class as a base class for other types of vehicles,
//such as Truck or Motorcycle, and inherit their behavior from Car. This is an
//example of inheritance and polymorphism in object-oriented programming.
public class Truck : Car
{
    public Truck(string color) : base(color)
    {
    }

    public void LoadCargo()
    {
        Console.WriteLine("Loading cargo...");
    }
}


//POLYMORPHISM:

//The Car class and the Truck class are examples of polymorphism because
//they demonstrate the ability of objects of different classes to be treated as
//objects of a common base class.



//The color field is declared in the Vehicle class, but it's initialized
//through the constructors of the derived classes.
//So, the flow is:

//---You create an instance of Car or Truck, calling its constructor.
//---The constructor of Car or Truck calls the constructor of Vehicle using base.
//---The constructor of Vehicle initializes its own fields, such as color.