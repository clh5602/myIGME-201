using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE6
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Guessing game exercise
    // Restrictions: None
    internal static class Program
    {
        // Method: Main
        // Purpose: Generate a random number between 1 and 100 inclusive.
        //          Give the user 8 attempts to guess the number, giving feedback
        //          after every attempt on if the real value is higher or lower than the guess.
        // Restrictions: None
        struct order
        {
            public string itemName;
            public int unitCount;
            public double unitCost;


            public double orderPrice()
            {
                return unitCount * unitCost;
            }

            public string orderReceipt()
            {
                return String.Format("{0} {1} items at ${2} each, total cost ${3}", unitCount, itemName, unitCost, orderPrice());
            }

        }

        static void Main(string[] args)
        {
            order ex = new order();
            ex.itemName = "Joe";
            ex.unitCount = 4;
            ex.unitCost = 1.25;
            
            Console.WriteLine(ex.orderReceipt());  

    }
    }
}
