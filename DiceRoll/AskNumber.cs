


public class AskNumber
{
    public int Number()

    {
        int validNumber;
        string input;
        bool isValid;

        Console.WriteLine("¿Qué número ha salido?");

        do
        {
            input = Console.ReadLine();
            isValid = int.TryParse(input, out validNumber);

            if (!isValid)
            {
                Console.WriteLine("Invalid number. Try again.");
            }
        } while (!isValid);
        return validNumber;
    }
}
