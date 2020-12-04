using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions._2020
{
    public class _03_A : Solution
    {
        public _03_A(IEnumerable<string> inputs) : base(inputs)
        {
        }

        protected override string Solver()
        {
            return Slope.CountTrees(Inputs.ToList(), 3, 1).ToString();
        }
    }

    public class _03_B : Solution
    {
        public _03_B(IEnumerable<string> inputs) : base(inputs)
        { }

        protected override string Solver()
        {
            var paths = new int[5];
            paths[0] = Slope.CountTrees(Inputs.ToList(), 1, 1);
            paths[1] = Slope.CountTrees(Inputs.ToList(), 3, 1);
            paths[2] = Slope.CountTrees(Inputs.ToList(), 5, 1);
            paths[3] = Slope.CountTrees(Inputs.ToList(), 7, 1);
            paths[4] = Slope.CountTrees(Inputs.ToList(), 1, 2);

           return paths.MultiplyMembers().ToString();
        }
    }


    internal class Slope
    {
        internal static int CountTrees(IReadOnlyList<string> inputs, int right, int down)
        {
            var xPosition = right * -1;
            var numberOfThrees = 0;
            for (var i = 0; i < inputs.Count(); i++)
            {
                var isCorrectRow =  i % down == 0;
                if (! isCorrectRow)
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