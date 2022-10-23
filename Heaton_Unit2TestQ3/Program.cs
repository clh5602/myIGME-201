using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Unit2TestQ3
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Unit 2 Test Question 3
    // Restrictions: None
    internal static class Program
    {
        // Method: Main
        // Purpose: Utilize tuples and a sorted list to store the results of a math formula
        //          using the variables X, Y, and W.
        // Restrictions: None
        static void Main(string[] args)
        {
            double z;
            SortedList<(double, double, double), double> list = new SortedList<(double, double, double), double>();
            
            for (double w = -2; w <= 0; w += 0.2){
                w = Math.Round(w, 1);

                for (double x = 0; x <= 4; x += 0.1)
                {
                    x = Math.Round(x, 1);
                    
                    for (double y = -1; y <= 1; y += 0.1)
                    {
                        y = Math.Round(y, 1);
                        z = Math.Round((4 * Math.Pow(y, 3) + 2 * Math.Pow(x, 2) - 8 * w + 7), 3);
                        
                        list.Add((w, x, y), z);
                    }
                }
            }
            
        }
    }
}
