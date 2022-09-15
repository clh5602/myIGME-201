using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE8
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Hosts the Main method
    // Restrictions: None
    internal static class Program
    {
        // Method: Main
        // Purpose: Generate a 3D array that stores X, Y, and Z values.
        //          Allow the user to search through the generated array.
        // Restrictions: None
        static void Main(string[] args)
        {
            double[,,] formulaTests = new double[21, 31, 3];
            
            // Variables for search function at end of program
            int xSearch;
            int ySearch;

            // Create 3D array
            for (double x = -1.0; x <= 1.0; x += 0.1) // Possible x
            {
                Math.Round(x, 1);
                for (double y = 1.0; y <= 4.0; y += 0.1) // Possible y
                {
                    Math.Round(y, 1);
                    double z = Math.Round((3 * Math.Pow(y, 2) + 2 * x - 1), 2); // The formula
                    // Reverse engineer x and y values into usable indexes
                    int xCoord = (int)Math.Round((x + 1) * 10);
                    int yCoord = (int)Math.Round((y - 1) * 10);

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
            Console.Write("Enter an X index to search thru the database (0-20 inclusive): ");
            if (!(int.TryParse(Console.ReadLine(), out xSearch) && xSearch <= 20 && xSearch >= 0)) // Get an X index, end program if invalid
            {
                goto end;
            }
            Console.Write("Enter a Y index to search thru the database (0-30 inclusive): ");
            if (!(int.TryParse(Console.ReadLine(), out ySearch) && ySearch <= 30 && ySearch >= 0)) // Get a Y index, end program if invalid
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
    }
}
