using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PE3question6
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Hosts the Main method
    // Restrictions: None
    static internal class Program
    {
        // Method: Main
        // Purpose: Prompt the user to input four integers, then output their combined product.
        // Restrictions: This program is not equipped to handle what would happen if the user
        //                 did not enter an integer. This could be fixed with while loops and the tryParse method.
        static void Main(string[] args)
        {
            int numOne = Convert.ToInt32(Console.ReadLine());
            Console.Write(numOne);
            Console.Write("Please enter another integer: ");
            int numTwo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter a third integer: ");
            int numThree = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter the final integer: ");
            int numFour = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The product of those four integers is: " + (numOne * numTwo * numThree * numFour));
        }
    }
}
