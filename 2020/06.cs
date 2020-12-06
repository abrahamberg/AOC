using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _06 : Solution
    {
        public _06(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        { }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            return Looper.Loop(inputs).Select(x
                    => x.Distinct().Count())
                .Aggregate((current, member) => current + member).ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var count = 0;

            foreach (var members in Looper.Loop2(inputs).Select(x => x.Split(",")))
                if (members.Length == 1)
                {
                    count += members[0].Length;
                }
                else
                {
                    var common = members[0].Intersect(members[1]);
                    for (var i = 2; i < members.Length; i++) common = common.Intersect(members[i]);

                    count += common.Count();
                }

            return count.ToString();
        }


        private static class Looper
        {
            internal static IEnumerable<string> Loop(IEnumerable<string> inputs)
            {
                return string.Join("",
                        inputs.Select(x => string.IsNullOrWhiteSpace(x) ? "\n" : x))
                    .Split("\n");
            }

            internal static IEnumerable<string> Loop2(IEnumerable<string> inputs)
            {
                return string.Join(",",
                        inputs.Select(x => string.IsNullOrWhiteSpace(x) ? "\n" : x))
                    .Split("\n")
                    .Select(x => x[0] == ',' ? x.Remove(0, 1) : x)
                    .Select(x => x[^1] == ',' ? x.Remove(x.Length - 1, 1) : x);
            }
        }
    }
}