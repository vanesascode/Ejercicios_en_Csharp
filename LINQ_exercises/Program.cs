
using System.Linq;

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