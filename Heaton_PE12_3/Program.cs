using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE12_3
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: PE_12 Question 3 - create an instance of a derived class and call its "GetString" method.
    internal static class Program
    {
        // Method: Main
        // Purpose: Create an instance of a derived class and call its "GetString" method.
        // Restrictions: None
        static void Main(string[] args)
        {
            MyDerivedClass example = new MyDerivedClass();
            Console.WriteLine(example.GetString());
        }
    }


    // Class MyClass
    // Author: Colby Heaton
    // Purpose: Creates a private string property, and creates a virtual method to get said value.
    public class MyClass
    {
        private string myString;

        public string MyString
        {
            set
            {
                this.myString = value;
            }
        }

        // Method: GetString
        // Purpose: will return the value of myString
        // Restrictions: None
        public virtual string GetString()
        {
            return this.myString;
        }
    }


    // Class MyDerivedClass
    // Author: Colby Heaton
    // Purpose: inherits from MyClass, overrides the GetString method to append a string to the result.
    public class MyDerivedClass : MyClass
    {
        // Method: Main
        // Purpose: Prompt the user for input using the new delegate method
        // Restrictions: None
        override public string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }
    }
}
