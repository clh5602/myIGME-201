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
namespace Heaton_PE9_3
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: PE_9 Question 3 - create a delegate to impersonate Console.ReadLine();
    internal static class Program
    {
        // Method: Main
        // Purpose: Prompt the user for input using the new delegate method
        // Restrictions: None
        
        // Declare delegate
        delegate string GetInput();
        static void Main(string[] args)
        {
            GetInput readUserInput = new GetInput(ReadInput); // initialize readUserInput as a new GetInput delegate using the ReadInput function
            string input = "";

            Console.Write("Enter any string: ");
            input = readUserInput(); // Use delegate
            Console.WriteLine("You entered: " + input);
        }
        // Method: ReadInput
        // Purpose: use in place of ReadLine, returns a string
        // Restrictions: None
        static string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
