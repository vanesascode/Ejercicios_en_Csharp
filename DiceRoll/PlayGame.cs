


public static class PlayGame
{
    public static void Go(bool isGuessRight, int randomNumber, int userGuess)
    {

        for (int i = 2; i > 0; i--)
        {
            if (isGuessRight)
            {
                Console.WriteLine($"¡Correcto! el número del dado es {randomNumber}. ¡Ganaste!");
                break;
            }
            else
            {
                if (i == 1)
                {
                    Console.WriteLine("No es ese, te queda 1 oportunidad, vuelve a intentarlo");
                }
                else
                {
                    Console.WriteLine($"No es ese, te quedan {i} oportunidades, vuelve a intentarlo");
                }
                userGuess = new AskNumber().Number();
                isGuessRight = ValidateNumber.IsValid(userGuess, randomNumber);
            }
        }

        if (!isGuessRight)
        {
            Console.WriteLine("Lo siento. Perdiste...");
        }

    }
}
