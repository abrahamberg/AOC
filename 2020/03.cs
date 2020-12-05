using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    public class _03 : Solution
    {
        public _03(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            return Slope.CountTrees(inputs.ToList(), 3, 1).ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var paths = new int[5];
            var enumerable = inputs as string[] ?? inputs.ToArray();
            paths[0] = Slope.CountTrees(enumerable.ToList(), 1, 1);
            paths[1] = Slope.CountTrees(enumerable.ToList(), 3, 1);
            paths[2] = Slope.CountTrees(enumerable.ToList(), 5, 1);
            paths[3] = Slope.CountTrees(enumerable.ToList(), 7, 1);
            paths[4] = Slope.CountTrees(enumerable.ToList(), 1, 2);

            return paths.MultiplyMembers().ToString();
        }

        private class Slope
        {
            internal static int CountTrees(IReadOnlyList<string> inputs, int right, int down)
            {
                var xPosition = right * -1;
                var numberOfThrees = 0;
                for (var i = 0; i < inputs.Count(); i++)
                {
                    var isCorrectRow = i % down == 0;
                    if (!isCorrectRow)
                        continue;

                    xPosition += right;
                    var positionWithoutRepeats = xPosition % inputs[i].Length;
                    if (inputs[i][positionWithoutRepeats] == '#')
                        numberOfThrees++;
                }

                return numberOfThrees;
            }
        }
    }
}