

//It's not advisable to use the Random() class in a class, so we declare it here, and in the Dice class we pass it in the constractor.
using Assignment2_DiceRoll_Solution.Game;

var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

GameResult gameResult = guessingGame.Play();
GuessingGame.PrintResult(gameResult);


Console.ReadKey();

