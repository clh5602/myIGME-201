using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE6
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Guessing game exercise
    // Restrictions: None
    internal static class Program
    {
        // Method: Main
        // Purpose: Generate a random number between 1 and 100 inclusive.
        //          Give the user 8 attempts to guess the number, giving feedback
        //          after every attempt on if the real value is higher or lower than the guess.
        // Restrictions: None
        static void Main(string[] args)
        {
            const int MAX_ATTEMPTS = 8;
            const int UPPER_BOUNDS = 100;
            const int LOWER_BOUNDS = 0;
            int numAttempts = 0;
            int userGuess = 0;

            // Generate Random Number
            Random rand = new Random();

            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(LOWER_BOUNDS, UPPER_BOUNDS + 1);

            // Print the random number
            Console.WriteLine(randomNumber);

            // Begin a for loop for # of attempts
            for (numAttempts = 1; numAttempts <= MAX_ATTEMPTS; ++numAttempts)
            {
                // Prompt the user for an input
                Console.Write("Turn #" + numAttempts + ": Enter your guess: ");

                // While loop to parse submission & check range
                while (!(int.TryParse(Console.ReadLine(), out userGuess) && userGuess <= UPPER_BOUNDS && userGuess >= LOWER_BOUNDS))
                {
                    Console.WriteLine("Invalid guess – try again");
                    Console.Write("Turn #" + numAttempts + ": Enter your guess: ");
                }
                // If equal, break loop
                if (userGuess == randomNumber)
                {
                    break;
                }

                // Compare submission to random value
                if (userGuess > randomNumber)
                {
                    Console.WriteLine("Too high");
                } else
                {
                    Console.WriteLine("Too low");
                }
            }


            // Print results based on # of attempts
            if (numAttempts <= MAX_ATTEMPTS)
            {
                Console.WriteLine("Correct! You won in " + numAttempts + " turn(s).");
            }
            else
            {
                Console.WriteLine("You ran out of turns. The number was " + randomNumber + ".");
            }
        }
    }
}
