using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE8_7
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: PE8 question 7
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: Prompt the user to input a string, and output a string in the reverse order.
        // Restrictions: None
        static void Main(string[] args)
        {
            string userIn;
            char[] charArray;
            string reversed = "";

            // Get user input
            Console.Write("Enter any string: ");
            userIn = Console.ReadLine();

            // Convert input to char array
            charArray = userIn.ToCharArray();

            // Loop thru char array backwards, append each char to output string
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                reversed += charArray[i];
            }

            // print output
            Console.WriteLine(reversed);
        }
    }
}
