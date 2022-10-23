using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Unit2TestQ14
{
    // Class Program
    // Author: Colby Heaton & David Schuh
    // Purpose: Unit 2 Test Question 14
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: Create a Friend object, create a shallow copy of the friend, and change the copy's variables without effecting the original.
        // Restrictions: None
        static void Main(string[] args)
        {
            Friend friend;
            Friend enemy;

            // create my friend Charlie Sheen
            friend = new Friend("Charlie Sheen", "Dear Charlie", DateTime.Parse("1967-12-25"), "123 Any Street, NY NY 12202");

            // now he has become my enemy
            enemy = (Friend)friend.Shallowcopy();

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }

    // Class Friend
    // Author: Colby Heaton
    // Purpose: Holds four variables as well as a method to copy itself at a new address.
    // Restrictions: None
    public class Friend
    {
        public string name;
        public string greeting;
        public DateTime birthday;
        public string address;

        public Friend(string name, string greeting, DateTime birthday, string address)
        {
            this.name = name;
            this.greeting = greeting;
            this.birthday = birthday;
            this.address = address;
        }

        // Method: Shallowcopy
        // Purpose: Returns an object with the same variables and values as the invoker
        // Restrictions: None
        public object Shallowcopy()
        {
            return this.MemberwiseClone();
        }
    }
}

/*
using System;

namespace StructToClass
{
    struct Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;
    }

    class Program
    {

        static void Main(string[] args)
        {
            Friend friend;
            Friend enemy;

            // create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            enemy = friend;

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}
*/
