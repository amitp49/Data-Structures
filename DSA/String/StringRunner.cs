using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    public class StringRunner : IRunner
    {
        public void Run()
        {
            StringAlgos.PrintAllPermutations("ACB");
            Console.ReadKey();
        }
    }
}
