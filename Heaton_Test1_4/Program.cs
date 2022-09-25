using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Heaton_Test1_4
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Unit 1 Test Question 4 - impersonate 3questions.exe;
    static internal class Program
    {
        // Timer and answer declarations
        static bool timeOut = false;
        static Timer timeOutTimer;
        static string answer = "";

        // Method: Main
        // Purpose: Prompt the user to choose a question, then make the user answer the question within five seconds.
        // Restrictions: None
        static void Main(string[] args)
        {
            int questionChoice = 0;
            string playAgain = "";
            string question = "";
            string input = "";

        start:
            Console.WriteLine("");
            
            do // Keep prompting user to select a question until recieve valid input
            {
                Console.Write("Choose your question (1-3): ");
            } while (!(int.TryParse(Console.ReadLine(), out questionChoice) && questionChoice >= 1 && questionChoice <= 3));

            switch (questionChoice) // Change the question and answer variables based on selected question
            {
                case 1:
                    question = "What is your favorite color?";
                    answer = "black";
                    break;
                case 2:
                    question = "What is the answer to life, the universe and everything?";
                    answer = "42";
                    break;
                case 3:
                    question = "What is the airspeed velocity of an unladen swallow?";
                    answer = "What do you mean? African or European swallow?";
                    break;
            }

            Console.WriteLine("You have 5 seconds to answer the following question:");
            timeOutTimer = new Timer(5000); // Create 5 second timer
            timeOut = false;
            timeOutTimer.Elapsed += TimesUp; // Connect it to the method for time being up
            timeOutTimer.Start(); // Begin the countdown, will call the method when time is up

            // Ask the question
            Console.WriteLine(question);
            input = Console.ReadLine();

            timeOutTimer.Stop();

            // If correct and time not up
            if (input == answer && !timeOut)
            {
                Console.WriteLine("Well Done!");
            }
            else if (!timeOut) // If wrong and time is not up
            {
                Console.WriteLine("Wrong!\tThe answer is: " + answer);
            }

            // Ask user to play again
        playAgain:
            Console.Write("Play again? ");
            playAgain = Console.ReadLine().ToLower();
            if (playAgain.StartsWith("y"))
            {
                goto start;
            }
            if (!playAgain.StartsWith("n"))
            {
                goto playAgain;
            }

        }

        // Method: TimesUp
        // Purpose: Called when time is up, will set a bool to true and stop the timer.
        // Restrictions: None
        static void TimesUp(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Time's up!");
            Console.WriteLine("The answer is: " + answer); // Tell correct answer
            Console.WriteLine("Please press enter.");
            timeOutTimer.Stop();
            timeOut = true;
        }
    }
}