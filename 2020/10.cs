using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _10 : Solution
    {
        public _10(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            var all = inputs.Select(int.Parse).ToList();
            all.Sort();

            var ones = 0;
            var threes = 1;
            var current = 0;

            foreach (var no in all)
            {
                if (no == current + 1)
                    ++ones;
                else if (no == current + 3)
                    ++threes;

                current = no;
            }

            return (ones * threes).ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var all = inputs.Select(int.Parse).ToList();
            all.Sort();
            all.Add(all[^1] + 3); // add last Item
            var size = all.Count;
            var atIndex = new long[size];
            for (var i = 0; i < size; ++i)
            {
                atIndex[i] = 0;
                var current = all[i];
                if (current <= 3) atIndex[i] = 1;
                for (var j = 0; j < i; j++)
                    if (all[j] >= current - 3) atIndex[i] += atIndex[j];
            }

            return atIndex[^1].ToString();
        }
    }
}