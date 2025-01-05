
int randomNumber = RandomNumber.Generate();
int userGuess = new AskNumber().Number();
bool isGuessRight = ValidateNumber.IsValid(userGuess, randomNumber);
PlayGame.Go(isGuessRight, randomNumber, userGuess);


Console.ReadKey();
