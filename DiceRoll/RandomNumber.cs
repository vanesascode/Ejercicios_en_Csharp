


public static class RandomNumber
{
    public static int Generate()
    {
        Console.WriteLine("Se ha tirado el dado.");
        return new Random().Next(1, 6);
    }
}
