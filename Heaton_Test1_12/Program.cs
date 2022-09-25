using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Test1_12
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Unit 1 Test Question 12 - Incorporate a function with a ref parameter
    static internal class Program
    {
        // Method: Main
        // Purpose: Prompt the user for their name, and call the GiveRaise function.
        // Restrictions: None
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;
            Console.Write("Enter your name: ");
            sName = Console.ReadLine();

            if (GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine($"Congratulations {sName}! Your new salary is ${dSalary}!");
            }
        }
        // Method: GiveRaise
        // Purpose: If the user's name is "Colby", increase the salary param by 19999.99
        // Restrictions: None
        static bool GiveRaise( string name, ref double salary)
        {
            if (name == "Colby")
            {
                salary += 19999.99;
                return true;
            }
            return false;
        }
    }
}
