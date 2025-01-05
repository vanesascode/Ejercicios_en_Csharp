Person person1 = new Person("Walter");
Console.WriteLine(person1.GetName());

// if the accesor of the fild was public,
// I could do this, but cos it's private, I can't:
Console.WriteLine(person1.name); 

//Now, if the accessor was public and the readonly
//wasn't there, I could change the value of the name,
//but because it is readonly, I cannot change the value
//after being initialized:
person1.name = "Lis";
Console.WriteLine(person1.name);


public class Person
{
    private readonly string name;

    public Person(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}