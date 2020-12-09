using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _09 : Solution
    {
        public _09(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            const int preamble = 25;
            var all = inputs.Select(long.Parse).ToArray();
            for (var i = 0; i < all.Length; i++)
            {
                var current = new List<long>();
                for (var j = 0; j < preamble; j++) current.Add(all[i + j]);

                var nextInd = i + preamble;
                if (!current.Any(x => current.Any(y => x + y == all[nextInd] && x != y)))
                    return all[nextInd].ToString();
            }

            return "Not Found";
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var number = long.Parse(SolverA(inputs));
            var all = inputs.Select(long.Parse).ToArray();
            for (var i = 0; i < all.Length; ++i)
            {
                long sum = 0;
                var min = long.MaxValue;
                var max = long.MinValue;
                for (var j = i;; ++j)
                {
                    var v = all[j];
                    min = Math.Min(min, v);
                    max = Math.Max(max, v);
                    sum += v;
                    if (sum == number) return (min + max).ToString();
                    if (sum > number) break;
                }
            }


            return "Not Found";
        }

    }
}