using System;

namespace Week2.Assignment1
{
    public class GuessTheNumber
    {
        public void RunGame()
        {
            int targetNumber = GenerateRandomNumber();
            int attempts = 0;
            bool isCorrect = false;

            Console.WriteLine("Guess a number between 1 and 100.");

            while (!isCorrect)
            {
                int guess = GetValidGuess();
                attempts++;
                isCorrect = CheckGuess(guess, targetNumber, attempts);
            }
        }

        private int GenerateRandomNumber() 
        {
            return new Random().Next(1, 101);
        } 

        private int GetValidGuess()
        {
            while (true)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number) && number >= 1 && number <= 100)
                    return number;

                Console.WriteLine("Invalid! Please enter a number between 1 and 100.");
            }
        }

        private bool CheckGuess(int guess, int target, int attempts)
        {
            if (guess < target)
                Console.WriteLine("Too low. Guess again.");
            else if (guess > target)
                Console.WriteLine("Too high. Guess again.");
            else
            {
                Console.WriteLine($"Correct! You guessed it in {attempts} guesses.");
                return true;
            }

            return false;
        }

        public static void Main()
        {
            var game = new GuessTheNumber();
            game.RunGame();
        }
    }
}
