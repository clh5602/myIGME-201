using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Test1_8
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Unit 1 Test Question 8 - Use the delegate from problem 3 with edited code from PE8
    static internal class Program
    {
        public delegate double RoundNum(double one, int two);
        // Method: Main
        // Purpose: generate a 3d array with a formula, use a delegate method to round those values. Allow the user to search the array for values.
        // Restrictions: None
        static void Main(string[] args)
        {
            // Create delegate
            RoundNum round = new RoundNum(RoundNumber);

            double[,,] formulaTests = new double[41, 21, 3];

            // Variables for search function at end of program
            int xSearch;
            int ySearch;

            // Create 3D array
            for (double x = 0.0; x <= 4.0; x += 0.1) // Possible x
            {
                x = round(x, 1);
                for (double y = -1.0; y <= 1.0; y += 0.1) // Possible y
                {
                    y = round(y, 1);
                    double z = round((4 * Math.Pow(y, 3) + 2 * Math.Pow(x, 2) - 8 * x + 7), 3); // The formula
                    // Reverse engineer x and y values into usable indexes
                    int xCoord = (int)round((x) * 10, 0);
                    int yCoord = (int)round((y + 1) * 10, 0);

                    // Record values in innermost array
                    formulaTests[xCoord, yCoord, 0] = x;
                    formulaTests[xCoord, yCoord, 1] = y;
                    formulaTests[xCoord, yCoord, 2] = z;
                }
            }
            Console.WriteLine("Value Table Generated.");

        // Custom search function, allows user to search through the generated array
        contSearch:
            Console.WriteLine("Enter anything other than the requested number to end the program.");
            Console.Write("Enter an X index to search thru the database (0-40 inclusive): ");
            if (!(int.TryParse(Console.ReadLine(), out xSearch) && xSearch <= 40 && xSearch >= 0)) // Get an X index, end program if invalid
            {
                goto end;
            }
            Console.Write("Enter a Y index to search thru the database (0-20 inclusive): ");
            if (!(int.TryParse(Console.ReadLine(), out ySearch) && ySearch <= 20 && ySearch >= 0)) // Get a Y index, end program if invalid
            {
                goto end;
            }
            // Print the found array
            Console.WriteLine("Array found: [ " + formulaTests[xSearch, ySearch, 0] + ", " + formulaTests[xSearch, ySearch, 1] + ", " + formulaTests[xSearch, ySearch, 2] + "]");
            Console.WriteLine("");
            goto contSearch;

        end:
            Console.WriteLine("End");
        }

        // Method: ReadNumber
        // Purpose: use in place of Math.Round, returns a rounded double
        // Restrictions: None
        static double RoundNumber(double num, int precision)
        {
            return Math.Round(num, precision);
        }
    }
}
