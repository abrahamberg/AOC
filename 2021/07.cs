using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AdventOfCode.Application;

namespace AdventOfCode._2021
{
    class _07 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var countOfCrabs = CountInitState(inputs);
            (int SequencePosition, int fuel) optmal = (int.MaxValue, int.MaxValue);

            for (int p = 0; p < countOfCrabs.Length; p++)
            {
                var fuel = 0;
                for (int i = 0; i < countOfCrabs.Length; i++)
                {
                    fuel += Math.Abs(i - p)*countOfCrabs[i];
                }

                if (fuel < optmal.fuel)
                    optmal = (p, fuel);
            }
            return optmal.fuel.ToString();
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var countOfCrabs = CountInitState(inputs);
            (int SequencePosition, long fuel) optmal = (int.MaxValue, long.MaxValue);

            for (int p = 0; p < countOfCrabs.Length; p++)
            {
                long fuel = 0;
                for (int i = 0; i < countOfCrabs.Length; i++)
                {
                    fuel +=CountFuel(Math.Abs(i - p)) *countOfCrabs[i];
                }

                if (fuel < optmal.fuel)
                    optmal = (p, fuel);
            }

            return optmal.fuel.ToString();
        }

        private static int[] CountInitState(IReadOnlyList<string> inputs)
        {
            var init = inputs[0].Split(',').Select(x=> int.Parse(x)).ToArray();
            var max = init.Max()+1;
            var timerCountAtDay = new int[max];
            for (int i = 0; i < max; i++)
            {
                timerCountAtDay[i] = init.Count(x => x == i);
            }

            return timerCountAtDay;
        }

        private static long CountFuel(int no)
        {
            var res = 0;
            for (int i = 0; i <= no; i++)
            {
                res += i;
            }
            return res;
        }
    }
}
