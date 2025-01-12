// TRABAJAR ESTE EJERCICIO QUE SIGUE: 

List<Person> people = new List<Person>
{
    new Person { Name = "John", Age = 25 },
    new Person { Name = "Jane", Age = 30 },
    new Person { Name = "Bob", Age = 20 }
};
List<Address> addresses = new List<Address>
{
    new Address { Street = "123 Main St", PersonName = "John" },
    new Address { Street = "456 Elm St", PersonName = "Jane" },
    new Address { Street = "789 Oak St", PersonName = "Bob" }
};

//people.Join(addresses, ...) : Esta es la operación de unión. Se está uniendo la lista people con la lista addresses.
// p => p.Name : Esta es la función de selección para la lista people. Se está seleccionando el campo Name de cada objeto Person en la lista people.
// a => a.PersonName : Esta es la función de selección para la lista addresses. Se está seleccionando el campo PersonName de cada objeto Address en la lista addresses.
//El resultado es una lista de objetos anónimos que contienen los campos Person y Address.
var joinedData = people.Join(addresses, p => p.Name, a => a.PersonName, (p, a) => new { Person = p, Address = a });

foreach (var data in joinedData)
{
    Console.WriteLine($"Name: {data.Person.Name}, Address: {data.Address.Street}");
}



//////////////////////////////////////////


List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
List<int> evenNumbers = GetEvenNumbers(numbers);

foreach (var num in evenNumbers)
{
    Console.WriteLine(num);
}

List<string> strings = new List<string> { "walter", "lis", "nina", "dante", "nemo", };
List<string> orderedStrings = SortStrings(strings);

foreach (var str in orderedStrings)
{
    Console.WriteLine(str);
}

Console.WriteLine("Press any key to close");
Console.ReadKey();


/////////////////////////////////////////////////////////////////////

//static List<int> GetEvenNumbers(List<int> numbers)
//{
//    List<int> evenNumbers = new List<int>();
//    foreach (int number in numbers)
//    {
//        if (number % 2 == 0)
//        {
//            evenNumbers.Add(number);
//        }
//    }
//    return evenNumbers;
//}

static List<int> GetEvenNumbers(List<int> numbers)
{
    return numbers.Where(n => n % 2 == 0).ToList();
}

/////////////////////////////////////////////////////////////////////////////


//Selection sort algorithm:

//static List<string> SortStrings(List<string> strings)
//{
//    List<string> sortedStrings = new List<string>();
//    for (int i = 0; i < strings.Count; i++)
//    {
//        bool inserted = false;
//        for (int j = 0; j < sortedStrings.Count; j++)
//        {
//            if (string.Compare(strings[i], sortedStrings[j]) < 0)
//            {
//                sortedStrings.Insert(j, strings[i]);
//                inserted = true;
//                break;
//            }
//        }
//        if (!inserted)
//        {
//            sortedStrings.Add(strings[i]);
//        }
//    }
//    return sortedStrings;
//}

static List<string> SortStrings(List<string> strings)
{
    return strings.OrderBy(s => s).ToList();
}



////////////////////////////////////////////////////////////

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Address
{
    public string Street { get; set; }
    public string PersonName { get; set; }
}