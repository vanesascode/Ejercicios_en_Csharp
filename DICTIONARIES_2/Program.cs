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


var result = Exercise.FindMaxWeights(myPets); 

Console.ReadKey();

public static class Exercise
{
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {
        var petsLists =  new Dictionary<PetType, List<Pet>>();

        foreach (Pet pet in pets)
        {
            if (!petsLists.ContainsKey(pet.PetType))
            {
                petsLists[pet.PetType] = new List<Pet>();
            }

            petsLists[pet.PetType].Add(pet);
        }

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