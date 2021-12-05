using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2021
{
    class _05 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var lines = ParsLines(inputs);
            var buffer = 1000;
            int[,] points = new int[buffer, buffer];

            foreach (var line in lines)
            {
                if (line[0] == line[2])
                {
                    var start = line[1] < line[3] ? line[1] : line[3];
                    var end = line[1] > line[3] ? line[1] : line[3];

                    for (int i = start; i <= end; i++)
                    {
                        CountThePoint(line[0], i);
                    }
                }
                else if (line[1] == line[3])
                {
                    var start = line[0] < line[2] ? line[0] : line[2];
                    var end = line[0] > line[2] ? line[0] : line[2];

                    for (int i = start; i <= end; i++)
                    {
                        CountThePoint(i, line[1]);
                    }
                }

                void CountThePoint(int x, int y)
                {
                    points[x, y]++;
                }
            }

            int count = 0;
            for (int i = 0; i < buffer; i++)
                for (int j = 0; j < buffer; j++)
                {
                    if (points[i, j] >= 2) count++;
                }
            return count.ToString();

        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {

            var lines = ParsLines(inputs);
            var buffer = 1000;
            int[,] points = new int[buffer, buffer];

            foreach (var line in lines)
            {

                if (line[0] == line[2])
                {
                    var start = line[1] < line[3] ? line[1] : line[3];
                    var end = line[1] > line[3] ? line[1] : line[3];

                    for (int i = start; i <= end; i++)
                    {
                        CountThePoint(line[0], i);
                    }
                }
                else if (line[1] == line[3])
                {
                    var start = line[0] < line[2] ? line[0] : line[2];
                    var end = line[0] > line[2] ? line[0] : line[2];

                    for (int i = start; i <= end; i++)
                    {
                        CountThePoint(i, line[1]);
                    }
                }
                else if (
                    Math.Abs(line[0] - line[1]) == Math.Abs(line[2] - line[3])
                    || Math.Abs(line[0] - line[3]) == Math.Abs(line[1] - line[2])
                    )
                {
                    bool isStartSmallerX = line[0] <= line[2];
                    bool isStartSmallerY = line[1] <= line[3];


                    var previusPouint = new int[2] { -1, -1 };
                    while (!(previusPouint[0] == line[2] && previusPouint[1] == line[3]))
                    {
                        int[] currentPoint = new int[2];
                        if (previusPouint[0] == -1)
                        {
                            currentPoint[0] = line[0];
                            currentPoint[1] = line[1];
                        }
                        else
                        {
                            var x = isStartSmallerX ? previusPouint[0] + 1 : previusPouint[0] - 1;
                            var y = isStartSmallerY ? previusPouint[1] + 1 : previusPouint[1] - 1;
                            currentPoint[0] = x;
                            currentPoint[1] = y;

                        }
                        CountThePoint(currentPoint[0], currentPoint[1]);
                        previusPouint = currentPoint;
                    }
                }



                void CountThePoint(int x, int y)
                {
                    points[x, y]++;
                }
            }

            int count = 0;
            for (int i = 0; i < buffer; i++)
                for (int j = 0; j < buffer; j++)
                {
                    if (points[i, j] >= 2) count++;
                }
            return count.ToString();
        }


        private List<int[]> ParsLines(IReadOnlyList<string> inputs)
        {
            List<int[]> lines = new();
            foreach (var inp in inputs.Select(x => x.Split(" -> ")))
            {
                var start = inp[0].Split(',');
                var end = inp[1].Split(',');

                int[] item = new int[4];
                item[0] = int.Parse(start[0]);
                item[1] = int.Parse(start[1]);
                item[2] = int.Parse(end[0]);
                item[3] = int.Parse(end[1]);
                lines.Add(item);

            }
            return lines;
        }



    }
}
