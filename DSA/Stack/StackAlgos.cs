using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class StackAlgos
    {
        public static bool AreParenthesisBalanced(String str)
        {
            MyStack<char> myStack = new SllStack<char>();
            List<Char> startingParenthsis = new List<char>() {'[','{','('};
            List<Char> endingParenthsis = new List<char>() {']','}',')'};
            Dictionary<char, char> dictionary = new Dictionary<char, char>();
            dictionary.Add(']', '[');
            dictionary.Add('}', '{');
            dictionary.Add(')', '(');


            foreach (var ch in str)
            {
                if(startingParenthsis.Contains(ch))
                {
                    myStack.Push(ch);
                }
                else if(endingParenthsis.Contains(ch))
                {
                    if (!myStack.IsEmpty() && dictionary[ch].CompareTo(myStack.Peek()) == 0)
                    {
                        myStack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //discard other characters
                }
            }

            //at the end nothing should be left out on stack
            return (myStack.Count == 0);
        }

        public static void ReverseStackUsingStackOperationsOnly(MyStack<int> myStack)
        {
            RecursiveReverseInternalUtil(myStack);
        }

        private static void AddDataAtBottom(MyStack<int> myStack, int data)
        {
            if(myStack.IsEmpty())
            {
                myStack.Push(data);
            }
            else
            {
                int otherData = myStack.Pop();
                AddDataAtBottom(myStack,data);
                myStack.Push(otherData);
            }
        }

        private static void RecursiveReverseInternalUtil(MyStack<int> myStack)
        {
            if(!myStack.IsEmpty())
            {
                int data = myStack.Pop();
                RecursiveReverseInternalUtil(myStack);
                AddDataAtBottom(myStack, data);
            }
        }

        public static void PrintNextGreaterElementInRightSideForAll(int[] arr)
        {
            if (arr.Length == 0)
                return;

            MyStack<int> myStack = new ArrayStack<int>(arr.Length);
            myStack.Push(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                int currentItem = arr[i];
                if(!myStack.IsEmpty())
                {
                    int peekedItem = myStack.Peek();
                    while(currentItem > peekedItem) //we found greater for some item
                    {
                        Console.WriteLine("For item " + peekedItem + ", next greater is: "+ currentItem);
                        myStack.Pop(); //Remove that processed item

                        if (!myStack.IsEmpty())
                            peekedItem = myStack.Peek(); //there can be many small than current item in stack
                        else
                            break;
                    }
                }
                //Add current item to stack
                myStack.Push(currentItem);
            }

            //Once we are done with this, all items in stack doesn't have greater on right.
            while (!myStack.IsEmpty())
            {
                Console.WriteLine("For item " + myStack.Pop() + ", next greater is: " + "NOT-FOUND");
            }
        }

        /// <summary>
        /// This prints greater element on left side. If no grater found, then Ith index is its span
        /// </summary>
        public static void PrintStockSpan(int[] arr)
        {
            if (arr.Length == 0)
                return;

            MyStack<int> myStack = new SllStack<int>();
            myStack.Push(arr.Length-1); // Pushing index, not the element
            for (int i = arr.Length-2; i >=0; i--)
            {
                int currentItem = arr[i];
                if (!myStack.IsEmpty())
                {
                    int peekedItem = arr[myStack.Peek()];
                    while (currentItem > peekedItem) //we found greter on left for some item
                    {
                        Console.WriteLine("For item " + peekedItem + ", stock span is: " + (myStack.Peek() - i));
                        myStack.Pop(); //Remove that processed item

                        if (!myStack.IsEmpty())
                            peekedItem = arr[myStack.Peek()]; //there can be many small than current item in stack
                        else
                            break;
                    }
                }
                //Add current item index to stack
                myStack.Push(i);
            }

            //Once we are done with this, all items in stack doesn't have greater on right.
            while (!myStack.IsEmpty())
            {
                Console.WriteLine("For item " + arr[myStack.Peek()] + ", stock span last is: " + (myStack.Peek()+1));
                myStack.Pop();
            }
        }
    }
}
