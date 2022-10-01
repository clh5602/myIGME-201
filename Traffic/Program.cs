using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Hosts the Main method and a new method, AddPassenger()
    // Restrictions: None
    internal static class Program
    {
        // Method: Main
        // Purpose: None
        // Restrictions: None
        static void Main(string[] args)
        {
            
        }

        // Method: AddPassenger
        // Purpose: Pass in an object that has inherited the IPassengerCarrier interface,
        //          call its LoadPassenger method, and print its ToString to the console.
        //          Using a parameter of a type that does not implement the LoadPassenger method
        //          will result in an error.
        // Restrictions: None
        public static void AddPassenger(IPassengerCarrier transit)
        {
            transit.LoadPassenger();
            Console.WriteLine(transit.ToString());
        }
    }
}
