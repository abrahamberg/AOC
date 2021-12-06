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
            var countDays = new int[9];
            var init = inputs[0].Split(',');
            for (int i = 0; i <= 8; i++)
            {
               countDays[i]= init.Count(x =>  x == i.ToString());
               
            }
            for (int day = 1; day <= 80; day++)
            {
                var newBorn =  0;
                for (int i = 0 ;i <= 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            newBorn = countDays[0];
                            break;
                        case 7:// add to day 6
                            countDays[i-1] = countDays[i]+newBorn;
                            break;
                        case 8:
                            countDays[i - 1] = countDays[i];
                            countDays[i] = newBorn;
                            break;
                        default:
                            countDays[i - 1] = countDays[i];
                            break;
                    }
                }
            }

            var count = 0;
            for (int i = 0; i <= 8; i++)
            {
                count = count+ countDays[i];
            }
        
            
            return count.ToString();

        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {

            var countDays = new BigInteger[9];
            var init = inputs[0].Split(',');
            for (int i = 0; i <= 8; i++)
            {
                countDays[i]= init.Count(x =>  x == i.ToString());
               
            }
            for (int day = 1; day <= 256; day++)
            {
                BigInteger newBorn =  0;
                for (int i = 0 ;i <= 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            newBorn = countDays[0];
                            break;
                        case 7: // add to day 6
                            countDays[i-1] = countDays[i]+newBorn;
                            break;
                        case 8:
                            countDays[i - 1] = countDays[i];
                            countDays[i] = newBorn;
                            break;
                        default:
                            countDays[i - 1] = countDays[i];
                            break;
                    }
                }
            }
            BigInteger count = 0;
            for (int i = 0; i <= 8; i++)
            {
                count = count+ countDays[i];
            }
        
            
            return count.ToString();

        }


       
    }
}
