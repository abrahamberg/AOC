using System.Collections.Generic;

namespace AdventOfCode.Solutions
{
    public abstract class Solution
    {
        public string  Results { get;  }
        protected IEnumerable<string> Inputs;

        protected Solution(IEnumerable<string> inputs)
        {
            Inputs = inputs;
            Results = Solver();
        }

        protected abstract string Solver();
    }
}