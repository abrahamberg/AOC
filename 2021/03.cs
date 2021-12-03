using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2021
{
    class _03 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
      
            var length = inputs[0].Length;
            var gamma = "";
            for (int i = 0; i < length; i++)
            {
                var zero=0; var one = 0;
                foreach (var input in inputs)
                {
                    if (input[i] == '0')
                        zero++;
                    else
                        one++;
                }

                gamma += zero > one ? "0" : "1";
            }

            var chRpsilon = gamma.Select(x => x == '0' ? '1' : '0').ToArray();
            var epsilon = new string(chRpsilon);
            int intGmma = Convert.ToInt32(gamma, 2);
            int intepsilon = Convert.ToInt32(epsilon, 2);

            return  (intGmma * intepsilon).ToString();
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
          
            var length = inputs[0].Length;
            var oxygen = inputs.ToList();
            var co2 = inputs.ToList();
            for (int i = 0; i < length; i++)
            {
               var zero = 0; var one = 0;
                foreach (var input in oxygen)
                {
                    if (input[i] == '0')
                        zero++;
                    else
                        one++;
                }

                if (oxygen.Count > 1)
                    oxygen = oxygen.Where(x => x[i] == (zero > one ? '0' : '1')).ToList();
            }
            
            for (int i = 0; i < length; i++)
            {
                var zero = 0; var one = 0;
                foreach (var input in co2)
                {
                    if (input[i] == '0')
                        zero++;
                    else
                        one++;
                }

                if (co2.Count > 1)
                    co2 = co2.Where(x => x[i] == (zero > one ? '1' : '0')).ToList();
            }

        
            int intOxygen = Convert.ToInt32(oxygen.First(), 2);
            int intCo2 = Convert.ToInt32(co2.First(), 2);

            return  (intOxygen * intCo2).ToString();
        }
    }
}
