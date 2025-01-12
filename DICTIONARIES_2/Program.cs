// DICTIONARY

var myPets = new List<Pet>
{
    new Pet(PetType.Cat, 7),
    new Pet(PetType.Dog, 8),
    new Pet(PetType.Fish, 0.6),
    new Pet(PetType.Cat, 8),
    new Pet(PetType.Dog, 12)
};

var Nemo = new Pet(PetType.Cat, 7);
Console.WriteLine(Nemo);
Console.WriteLine();

var result = PetWeightAnalyzer.FindMaxWeights(myPets);
Console.WriteLine(myPets); /////////////////////////////////////////////////


/// SORTED DICTIONARY


Console.WriteLine("Welcome to your encyclopedia!\n");

SortedDictionary<string, string> definitions = [];
do
{
    Console.WriteLine("\nChoose option ([A]dd, [L]ist): ");

    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    if (keyInfo.Key == ConsoleKey.A)
    {
        Console.Write("Enter the key: ");
        string key = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter the explanation: ");
        string explanation = Console.ReadLine()
        ?? string.Empty;
        definitions[key] = explanation;
    }
    else if (keyInfo.Key == ConsoleKey.L)
    {
        foreach ((string k, string e) in definitions)
        {
            Console.WriteLine($"{k}: {e}");
        }
    }
    else
    {
        Console.WriteLine("Do you want to exit? Y or N.");
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            break;
        }
    }
}
while (true);

Console.ReadKey();

////////////////////////////////////////////////////////////////////////////////////

public static class PetWeightAnalyzer
{
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {
        //var petsLists = new Dictionary<PetType, List<Pet>>();

        //foreach (Pet pet in pets)
        //{
        //    if (!petsLists.ContainsKey(pet.PetType))
        //    {
        //        petsLists[pet.PetType] = new List<Pet>();
        //    }

        //    petsLists[pet.PetType].Add(pet);
        //}

        var petsLists = pets
            .GroupBy(pet => pet.PetType)
            .ToDictionary(g => g.Key, g => g.ToList());

        var result = new Dictionary<PetType, double>();

        foreach (var petsList in petsLists)
        {
            double maxWeight = 0;

            foreach (var pet in petsList.Value)
            {
                if (pet.Weight > maxWeight)
                {
                    maxWeight = pet.Weight;
                }
            }

            result[petsList.Key] = maxWeight;
        }
        return result;
    }
}

public class Pet
{
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
        PetType = petType;
        Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
}

public enum PetType { Dog, Cat, Fish }