using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class StackRunner : IRunner
    {
        public void Run()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>(10);
            arrayStack.Push(2);
            arrayStack.Push(5);
            arrayStack.Push(1);
            arrayStack.Push(6);

            foreach (var item in arrayStack)
            {
                Console.WriteLine("Item:" + item);
            }

            Console.ReadKey();
        }
    }
}
