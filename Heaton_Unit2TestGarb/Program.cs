using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Unit2TestGarb
{
    /*Console.WriteLine(); for each list element.
SortedList<string,DateTime> friendBirthdays = new SortedList<string,DateTime>();
	where string = friend's name and DateTime = their birthdate (use the format string "MM/dd/yyyy" in your output)
(refer to https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings for how to output custom date formats)
*/


    static class Program
    {
        static void Main()
        {

            foreach (KeyValuePair<string, DateTime> birthday in friendBirthdays)
            {
                Console.WriteLine(birthday.Key + "\'s birthday is: {0:MM/dd/yy}", birthday.Value);
            }

        public class MyClass
        {
            public object Shallowcopy()
            {
                return this.MemberwiseClone();
            }
        }
        Company c2 = (Company)c1.DeepCopy();
        object2 = (myClass)object1.Shallowcopy();
        }
    }

}
