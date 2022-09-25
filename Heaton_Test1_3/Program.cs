using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// delegate steps
/// 1. define the delegate method data type based on the method signature
///         delegate double MathFunction(double n1, double n2);
/// 2. declare the delegate method variable
///         MathFunction processDivMult;
/// 3. point the variable to the method that it should call
///         processDivMult = new MathFunction(Multiply);
/// 4. call the delegate method / add the delegate method to the object's event handler
///         nAnswer = processDivMult(n1, n2);
///         timer.Elapsed += TimesUp;
namespace Heaton_Test1_3
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Unit 1 Test Question 3 - create a delegate to impersonate Math.Round();
    static internal class Program
    {
        // Method: Main
        // Purpose: Prompt the user for a decimal to round, and for which method to use.
        // Restrictions: None
        public delegate double RoundNum(double one, int two);
        static void Main(string[] args)
        {
            RoundNum round = new RoundNum(RoundNumber);
            double input = 0;
            int toPoint = 0;

        firstInput:
            Console.Write("Please enter a decimal value to be rounded: ");
            if (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input.");
                goto firstInput;
            }

       secondInput:
            Console.Write("Please enter the rounding precision as an integer (0 = whole, 1 = tenths, 2 = hundreths, etc): ");
            if (!int.TryParse(Console.ReadLine(), out toPoint))
            {
                Console.WriteLine("Invalid input.");
                goto secondInput;
            }

            Console.WriteLine("Output from delegate: " + round(input, toPoint));
        }

        // Method: ReadNumber
        // Purpose: use in place of Math.Round, returns a double
        // Restrictions: None
        static double RoundNumber(double num, int precision)
        {
            return Math.Round(num, precision);
        }
    }
}

