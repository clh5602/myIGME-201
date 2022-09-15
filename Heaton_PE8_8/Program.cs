using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE8_8
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Hosts the Main method
    // Restrictions: None
    internal static class Program
    {
        // Method: Main
        // Purpose: Prompts the user for a phrase, will replace all cases of the word "no" with "yes", with special cases for capitalization
        // Restrictions: None
        static void Main(string[] args)
        {
            string input;
            string[] breakdown;
            char[] trimming = { '{', '}', ',', '.', '?', '!', ' ' , '[', ']', '(', ')'}; // Add to this to accomodate for mor special characters
            string output = "";

            Console.Write("Enter a phrase that uses the word no: ");

            
            input = Console.ReadLine();
            breakdown = input.Split(' '); // Split input into array
            foreach (string line in breakdown)
            {
                string trimmed = line.Trim(trimming); // Get rid of special characters on ends
                switch (trimmed) // cases for capitalization
                {
                    case "no":
                        output += line.Replace("no", "yes");
                        break;
                    case "nO":
                        output += line.Replace("nO", "yEs");
                        break;
                    case "No":
                        output += line.Replace("No", "Yes");
                        break;
                    case "NO":
                        output += line.Replace("NO", "YES");
                        break;
                    default: // if does not contain no
                        output += line;
                        break;
                    
                }
                output += " "; // re-add spaces
            }

            Console.WriteLine(output);

        }
    }
}
