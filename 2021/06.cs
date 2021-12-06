using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AdventOfCode.Application;

namespace AdventOfCode._2021
{
    class _06 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var timerCountAtDay = CountInitState(inputs);
            var count = LoopThtoughDays(timerCountAtDay,80);
            return count.ToString();
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var timerCountAtDay = CountInitState(inputs);
            var count = LoopThtoughDays(timerCountAtDay,256);
            return count.ToString();
        }

        private static BigInteger[] CountInitState(IReadOnlyList<string> inputs)
        {
            var timerCountAtDay = new BigInteger[9];
            var init = inputs[0].Split(',');
            for (int i = 0; i <= 8; i++)
            {
                timerCountAtDay[i] = init.Count(x => x == i.ToString());
            }

            return timerCountAtDay;
        }

        private static BigInteger LoopThtoughDays(BigInteger[] timerCountAtDay,int days)
        {
            for (int day = 1; day <= days; day++)
            {
                BigInteger newBorn = 0;
                for (int i = 0; i <= 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            newBorn = timerCountAtDay[0];
                            break;
                        case 7: // add to day 6
                            timerCountAtDay[i - 1] = timerCountAtDay[i] + newBorn;
                            break;
                        case 8:
                            timerCountAtDay[i - 1] = timerCountAtDay[i];
                            timerCountAtDay[i] = newBorn;
                            break;
                        default:
                            timerCountAtDay[i - 1] = timerCountAtDay[i];
                            break;
                    }
                }
            }

            BigInteger count = 0;
            for (int i = 0; i <= 8; i++)
            {
                count += timerCountAtDay[i];
            }

            return count;
        }
    }
}
