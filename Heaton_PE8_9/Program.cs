using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE8_9
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Hosts the Main method
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: Prompts the user for a phrase, will surround all words with quotation marks.
        static void Main(string[] args)
        {
            string input;
            string[] breakdown;
            string output = "";

            Console.Write("Enter a phrase: ");


            input = Console.ReadLine();
            breakdown = input.Split(' '); // Split input into array
            foreach (string line in breakdown)
            {
                output += "\"" + line + "\" "; // re-add spaces with quotes
            }

            Console.WriteLine(output);

        }
    }
}
