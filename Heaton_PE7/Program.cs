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
        // Purpose: Read a txt file to load various MadLibs stories 
        //          Ask the user which story they'd like to play
        //          Seperate each story into individual words
        //          Step through each word and add it to the final result
        //          If a word requires input from the user, prompt the user to submit a certain word
        //          Once every word has been added to the story, print it out.
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare our variables
            const string templatePath = @"..\..\MadLibsTemplate.txt"; // Change this for the correct file path
            int selection = -1;
            string[] madLibs;
            string result = "";

            // Attempt to read the txt file and split each line into a different entry in an array
            try
            {
                madLibs = File.ReadAllLines(templatePath);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                goto end;
            }

            // If the txt document was empty, can't play.
            if (madLibs.Length == 0)
            {
                result = "txt document empty.";
                goto end;
            }

            // Ask the user if they would like to play
            Console.Write("Hello! Would you like to play MadLibs? :");
            result = Console.ReadLine().ToLower();
            while (result != "yes" && result != "no") // Wait for a valid response
            {
                Console.Write("Sorry, I didn't quite get that. Would you like to play MadLibs? :");
                result = Console.ReadLine().ToLower();
            }
            if (result == "no") // if no, jump to end of code
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

            // Break the selection down to individual words
            string[] brokenStory = madLibs[--selection].Split(' ');
            char[] trimming = { '{', '}', ',', '.', '?', '!', ' ' }; // List of characters to trim from prompt
            string prevWord = ""; // Store the previous word, used for not adding extra spaces

            foreach (string word in brokenStory)
            {
                if (result != "" && prevWord != "\\n") // Add a space as long as it's not at the beginning or after a new line
                {
                    result += " ";
                }

                if (word == @"\n") // replace \n with the next line command
                {
                    result += "\n";
                }

                else if (word.StartsWith("{")) // Check if requires prompt
                {
                    string prompt = word.Trim(trimming).Replace('_', ' '); // Get rid of brackets and other nonsense
                    Console.Write("Enter a " + prompt + ": "); // Ask in english
                    result += word.Replace("{" + prompt.Replace(' ', '_') + "}", Console.ReadLine()); // re-add commas and the like to the user's input before adding to result
                }
                else // For normal words
                {
                    result += word;
                }
                prevWord = word;
            }
            end:
                Console.WriteLine(result); // Either print the complete story or an error message
        }
    }
}
