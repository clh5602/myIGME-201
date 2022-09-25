using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Test1_12
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Unit 1 Test Question 13 - Rewrite #12 using a struct
    static internal class Program
    {
        struct employee
        {
            public string sName;
            public double dSalary;
        }
        
        // Method: Main
        // Purpose: Prompt the user for their name, and call the GiveRaise function.
        // Restrictions: None
        static void Main(string[] args)
        {
            employee programmer = new employee();
            
            Console.Write("Enter your name: ");
            programmer.sName = Console.ReadLine();
            programmer.dSalary = 30000;

            if (GiveRaise(ref programmer))
            {
                Console.WriteLine($"Congratulations {programmer.sName}! Your new salary is ${programmer.dSalary}!");
            }
        }
        // Method: GiveRaise
        // Purpose: If the user's name is "Colby", increase the salary param by 19999.99
        // Restrictions: None
        static bool GiveRaise(ref employee worker)
        {
            if (worker.sName == "Colby")
            {
                worker.dSalary += 19999.99;
                return true;
            }
            return false;
        }
    }
}
