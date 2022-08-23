using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_HelloWorld
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Hosts the Main method
    // Restrictions: None
    static internal class Program
    {
        // Method: Main
        // Purpose: Test int / string interactions, operate the "FizzBuzz" loop,
        //          reduce a number with a while loop, and print my name to the console.
        // Restrictions: type casting seems to work strangely
        static void Main(string[] args)
        {
            // Make some variables of different types
            string name = "Colby";
            string twelve = "12";
            int five = 5;

            //Console.WriteLine(((int)twelve)); // Failed string -> int
            //Console.WriteLine((string)five); // Failed int -> string

            // Messing around with + operator, strings, and ints
            Console.WriteLine("Messing around with Strings and ints");

            Console.WriteLine(twelve + five);
            Console.WriteLine(7 + five);
            Console.WriteLine((7 + five));
            Console.WriteLine((7 + twelve));

            Console.WriteLine();


            /*
             * Famous FizzBuzz Programming Test!
             * Loop through a handfull of numbers.
             * If the number is divisible by 3, output "Fizz"
             * If the number is divisible by 5, output "Buzz"
             * If the number is divisible by both 3 and 5, output "FizzBuzz"
             * If neither of the previous cases, output the number.
             */
            Console.WriteLine("FizzBuzz test from 1-100");
            for (int i = 1; i <= 100; i++)
            {
                string output = ""; // reset the output

                if (i % 3 == 0)
                {
                    output += "Fizz";
                }

                if (i % 5 == 0)
                {
                    output += "Buzz";
                }

                if (output == "")
                {
                    Console.WriteLine(i);
                } else
                {
                    Console.WriteLine(output);
                }

            }
            Console.WriteLine();

            // Testing While loop
            Console.WriteLine("Reduce the number 300 down to 30 using strange math");
            int reduceMe = 300;
            while (reduceMe > 30)
            {
                reduceMe -= reduceMe / 9;
                Console.WriteLine(reduceMe);
            }
            Console.WriteLine();

            // Print my name
            name += " Heaton";
            Console.WriteLine("My name is " + name);
        }
    }
}
