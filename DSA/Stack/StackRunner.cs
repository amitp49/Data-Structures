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

            Console.WriteLine("---------");
            SllStack<int> sllStack = new SllStack<int>(); //no need of any capacity
            sllStack.Push(2);
            sllStack.Push(5);
            sllStack.Push(1);
            sllStack.Push(6);

            foreach (var item in sllStack)
            {
                Console.WriteLine("Item:" + item);
            }

            Console.WriteLine("---------");
            DllStack<int> dllStack = new DllStack<int>(); //no need of any capacity
            dllStack.Push(1);
            Console.WriteLine("Middle:"+dllStack.GetMiddleNodeData());
            dllStack.Push(2);
            Console.WriteLine("Middle:" + dllStack.GetMiddleNodeData());
            dllStack.Push(3);
            Console.WriteLine("Middle:" + dllStack.GetMiddleNodeData());
            dllStack.Push(4);
            Console.WriteLine("Middle:" + dllStack.GetMiddleNodeData());

            foreach (var item in dllStack)
            {
                Console.WriteLine("Item:" + item);
            }
            Console.WriteLine("---------");

            SpecialStack<int> specialStack = new SpecialStack<int>(); //no need of any capacity
            specialStack.Push(2);
            specialStack.Push(5);
            specialStack.Push(1);
            specialStack.Push(6);

            while (!specialStack.IsEmpty())
            {
                Console.WriteLine("Item:"+specialStack.Peek() + ", min:" + specialStack.GetMin() + ", max:" + specialStack.GetMax());
                specialStack.Pop();
            }
            Console.WriteLine("---------");

            Console.WriteLine("Balanced: "  + StackAlgos.AreParenthesisBalanced("[(1*2)+{5+6}"));
            Console.WriteLine("---------");

            StackAlgos.ReverseStackUsingStackOperationsOnly(arrayStack);
            Console.WriteLine("After reverse");
            foreach (var item in arrayStack)
            {
                Console.WriteLine("Item:" + item);
            }
            Console.WriteLine("---------");

            StackAlgos.PrintNextGreaterElementInRightSideForAll(new int[] {10, 4, 5, 90, 120, 80 });
            Console.WriteLine("---------");

            StackAlgos.PrintStockSpan(new int[] { 10, 4, 5, 90, 120, 80 });

            Console.WriteLine("---------");

            StackAlgos.MaxAreaRectangleFromHistogram(new int[] { 6, 2, 5, 4, 5, 1, 6 });
            Console.WriteLine("---------");

            Console.ReadKey();
        }
    }
}
