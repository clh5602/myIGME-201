using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4Question2
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Hosts the Main method
    // Restrictions: None 
    static internal class Program
    {
        // Method: Main
        // Purpose: Prompt the user to input two integers. It will continue to do so until one number
        //          is above 10, and one is less than or equal to 10.
        // Restrictions: None
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            string favoriteFood = "spaghetti";
            switch ("spaghetti")
            {
                case ("spaghetti"):
                    Console.WriteLine("You seem to really like spaghetti");
                    break;
                case ("cake"):
                    Console.WriteLine("Wrong. Spaghetti is the best food.");
                    break;
                default:
                    Console.WriteLine("You should like spaghetti.");
                    break;
            }


            while (!(num1 > 10 ^ num2 > 10)) // Main loop, checking for either num1 or num2 to be > 10, but not both.
            {
            AskAgain1:
                Console.Write("Please enter an integer: ");
                // Simultaneously prompt the user for input, parse the input as an int, and write the value to num1.
                // If it fails to parse, return to the AskAgain1 line.
                if (!int.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Input not recognized as an integer.");
                    goto AskAgain1;
                }
            AskAgain2:
                Console.Write("Please enter another integer: ");
                // Simultaneously prompt the user for input, parse the input as an int, and write the value to num2.
                // If it fails to parse, return to the AskAgain2 line.
                if (!int.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Input not recognized as an integer.");
                    goto AskAgain2;
                }

                // Write a sort-of error message if the loop will run again
                if (!(num1 > 10 ^ num2 > 10))
                {
                    Console.WriteLine("Either both values were above 10, or both were below 10.\nPlease try again.");
                }

            }
            // The grand finale
            Console.WriteLine("One number entered was above 10, and one was below 10.");
        }
    }
}
