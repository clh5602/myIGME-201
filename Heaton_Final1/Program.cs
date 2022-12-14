using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Final1
{
    public class MyStack
    {
        public List<int> myStack = new List<int>();

        public void Push(int i)
        {
            myStack.Add(i);
        }

        public int? Peek()
        {
            if (myStack.Count > 0)
            {
                return myStack[myStack.Count - 1];
            }
            return null;
        }

        public int? Pop()
        {
            if (myStack.Count > 0)
            {
                int? i = myStack[myStack.Count - 1];
                myStack.RemoveAt(myStack.Count - 1);
                return i;
            }
            return null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
