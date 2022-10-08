using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE14
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: PE_14 Question 3 - create an instance two classes with the same interface, and call the interface method using a function 
    internal class Program
    {
        static void Main(string[] args)
        {
            // create objects
            Class1 class1 = new Class1();
            Class2 class2 = new Class2();
            
            // call MyMethod
            MyMethod(class1);
            MyMethod(class2);
        }

        public static void MyMethod(object myObject)
        {
            // cast parameter as interface 
            Facey obj = (Facey)myObject;
            // call the Method method
            obj.Method();
        }
    }

    // Interface Facey
    // Author: Colby Heaton
    // Purpose: Used by Class1 and Class2, forces them to have a Method method
    interface Facey
    {
        void Method();
    }

    // Class Class1
    // Author: Colby Heaton
    // Purpose: Implements the method defined in Facey
    public class Class1 : Facey
    {
        public void Method()
        {
            Console.WriteLine("From Class1 with love");
        }
    }

    // Class Class2
    // Author: Colby Heaton
    // Purpose: Implements the Facey method, unique from Class1
    public class Class2 : Facey
    {
        public void Method()
        {
            Console.WriteLine("From Class2 with love");
        }
    }

}
