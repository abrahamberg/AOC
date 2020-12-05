using System.Collections.Generic;

namespace AdventOfCode.Application
{
    public abstract class Solution
    {
        public string  Results { get;  }
        protected Solution(IEnumerable<string> inputs, VersionEnum version)
        {
            Results = version == VersionEnum.A? SolverA(inputs) : SolverB(inputs);
        }

        protected abstract string SolverA(IEnumerable<string> inputs);
        protected abstract string SolverB(IEnumerable<string> inputs);
    }
}