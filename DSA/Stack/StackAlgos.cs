using Interfaces;
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

        /// <summary>
        /// Min number of reversal needed to make exp valid
        /// </summary>
        /// <param name="exp"></param>
        /// <returns>Exp contains only '{' or '}'</returns>
        public static int MinNumberOfReversalNeededToMakeExpressionValid(string exp)
        {
            int count = 0;

            //remove already valid part from exp
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (stack.Count == 0 || 
                    exp[i].Equals('{') || 
                    (exp[i].Equals('}') && stack.Peek().Equals('}')) )
                {
                    stack.Push(exp[i]);
                } 
                else //if(exp[i].Equals('}') && stack.Peek().Equals('{'))
                {
                    stack.Pop(); //discard matching start and current I
                }
            }

            //stack would cotain starting and ending breackets only in order
            int startingBracketAtEnd = 0;
            while (stack.Count!=0 && stack.Peek().Equals('{'))
            {
                startingBracketAtEnd++;
                stack.Pop();
            }

            int endingBracketAtEnd = 0;
            while (stack.Count != 0 && stack.Peek().Equals('}'))
            {
                endingBracketAtEnd++;
                stack.Pop();
            }

            count = (int) (Math.Ceiling(startingBracketAtEnd / 2.0) + 
                Math.Ceiling(endingBracketAtEnd/2.0));
            return count;
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
        /// This prints greater element distance on left side. If no grater found, then Ith index is its span
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

        /// <summary>
        /// This gives max area of rectangle from histogram by maintaining left min and right min for each value bar
        /// </summary>
        /// <param name="arr"></param>
        public static void MaxAreaRectangleFromHistogram(int[] arr)
        {
            if (arr == null)
                return;

            int runningMaxArea = 0;
            Stack<int> stack = new Stack<int>();
            int i = 0;

            while( i < arr.Length ) //This is while, not for, because we dont want to increment in else part
            {
                if(stack.Count==0 || arr[i] >= arr[stack.Peek()] )
                {
                    stack.Push(i); //pushing index (not element) if its greater than what is on top
                    i++;
                }
                else
                {
                    //Current element 'I' is its(top of the stacks) right min
                    int maxAreaForTopStackBar = CalculateAreaForBarOnTop(arr, stack, i);

                    //update running max if required
                    if (runningMaxArea < maxAreaForTopStackBar)
                    {
                        runningMaxArea = maxAreaForTopStackBar;
                    }
                }
            }

            //For remainng element on stack
            while (stack.Count>0)
            {
                int maxAreaForTopStackBar = CalculateAreaForBarOnTop(arr, stack, arr.Length);
                //update running max if required
                if (runningMaxArea < maxAreaForTopStackBar)
                {
                    runningMaxArea = maxAreaForTopStackBar;
                }
            }

            Console.WriteLine("Max area:" + runningMaxArea);
        }

        private static int CalculateAreaForBarOnTop(int[] arr, Stack<int> stack, int rightMinIndex)
        {
            int stackTopIndex = stack.Peek();
            int stackTopData = arr[stackTopIndex];
            stack.Pop(); // removing bar for which we are calculating area

            int maxAreaForTopStackBar = 0;
            if (stack.Count != 0)
            {
                int leftMinIndex = stack.Peek(); //Critical, previous element would be its left min
                maxAreaForTopStackBar = stackTopData * (rightMinIndex - leftMinIndex - 1);
            }
            else
            {
                maxAreaForTopStackBar = stackTopData * (rightMinIndex);
            }

            return maxAreaForTopStackBar;
        }
    }
}
