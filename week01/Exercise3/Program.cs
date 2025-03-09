using System;

class Program
{
    static void Main()
    {
        Random randomGenerator = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = randomGenerator.Next(1, 101); // Random number between 1 and 100
            int guess = 0;
            int attempts = 0;

            Console.WriteLine("Welcome to 'Guess My Number'!");
            Console.WriteLine("I've picked a number between 1 and 100. Try to guess it!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                // Validate input
                if (int.TryParse(input, out guess))
                {
                    attempts++;

                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it in {attempts} attempts!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            // Ask if the player wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response != "yes")
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}
