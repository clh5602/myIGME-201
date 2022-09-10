using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE7
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Mad Libs exercise
    // Restrictions: None
    static internal class Program
    {
        // Method: Main
        // Purpose: Generate a random number between 1 and 100 inclusive.
        //          Give the user 8 attempts to guess the number, giving feedback
        //          after every attempt on if the real value is higher or lower than the guess.
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare our variables
            const string templatePath = @"..\..\MadLibsTemplate.txt"; // Change this for the correct file path
            int selection = -1;
            string[] madLibs = File.ReadAllLines(templatePath);
            string result = "";

            Console.Write("Hello! Would you like to play MadLibs? :");
            result = Console.ReadLine().ToLower();
            while (result != "yes" && result != "no")
            {
                Console.Write("Sorry, I didn't quite get that. Would you like to play MadLibs? :");
                result = Console.ReadLine().ToLower();
            }
            if (result == "no")
            {
                result = "Oh, alright then. Goodbye.";
                goto end;
            }


            result = "";
            // Prompt user for selection of madLib
            Console.Write("Please enter a number corresponding to the MadLib story you'd like to play (from 1 to " + madLibs.Length + "): ");
            // Check for valid entry
            while (!(int.TryParse(Console.ReadLine(), out selection) && selection >= 1 && selection <= madLibs.Length))
            {
                Console.WriteLine("Selection invalid. Try again.");
                Console.Write("Please enter a number corresponding to the MadLib you'd like to play (from 1 to " + madLibs.Length + "): ");
            }

            string[] brokenStory = madLibs[--selection].Split(' ');
            char[] trimming = { '{', '}' , ',', '.', '?', '!', ' '};
            string prevWord = "";
            foreach (string word in brokenStory)
            {
                if (result != "" && prevWord != "\\n")
                {
                    result += " ";
                }

                if (word == @"\n")
                {
                    result += "\n";
                }

                else if (word.StartsWith("{"))
                {
                    string prompt = word.Trim(trimming).Replace('_', ' ');
                    Console.Write("Enter a " + prompt + ": "); 
                    result += word.Replace("{" + prompt.Replace(' ', '_') + "}", Console.ReadLine());
                }
                else
                {
                    result += word;
                }
                prevWord = word;
            }
            end:
            Console.WriteLine(result);

            
            

        }
    }
}
