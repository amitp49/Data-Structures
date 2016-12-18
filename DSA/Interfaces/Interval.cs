using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Interval : IComparable
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval(int start,int end)
        {
            this.Start = start;
            this.End = end;
        }
        public int CompareTo(object obj)
        {
            Interval other = (Interval) obj;
           if(this.Start < other.Start)
           {
               return -1;
           }
           else if(this.Start > other.Start)
           {
               return 1;
           }
           else
           {
               return 0;
           }
        }
    }
}
