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
    }
}
