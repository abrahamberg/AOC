using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2021
{
    class _02 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            int x=0, y = 0;
            var list = inputs.Select(x => x.Split(' ')).ToArray();
            foreach (var d in list)
            {
                switch (d[0])
                {
                    case "forward":
                        x = int.Parse(d[1]) + x;
                        break;
                    case "down":
                        y -= int.Parse(d[1]);
                        break;
                    case "up":
                        y += int.Parse(d[1]) ;
                        break;
                }
            }

            return x + "," + y +"="+(x*y);
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            int x=0, y = 0, a=0;
            var list = inputs.Select(x => x.Split(' ')).ToArray();
            foreach (var d in list)
            {
                switch (d[0])
                {
                    case "forward":
                        x =   x + int.Parse(d[1]);
                        y = y + (int.Parse(d[1]) * a);
                        break;
                    case "down":
                        a = a + int.Parse(d[1]);
                        break;
                    case "up":
                        a = a -int.Parse(d[1]) ;
                        break;
                }
            }

            return x + "," + y +"="+(x*y);
        }
    }
}
