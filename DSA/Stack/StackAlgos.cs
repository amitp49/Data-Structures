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
    }
}
