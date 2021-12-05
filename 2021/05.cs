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
            var log = 0;
            var lines = ParsLines(inputs);
            List<Point> recoredPoints = new();
            foreach (var line in lines)
            {
                log++;
                Console.WriteLine(log);

                if (line.Start.X == line.End.X)
                {
                    var start = line.Start.Y < line.End.Y ? line.Start.Y : line.End.Y;
                    var end = line.Start.Y > line.End.Y ? line.Start.Y : line.End.Y;

                    for (int i = start; i <= end; i++)
                    {
                        var currentPoint = new Point(line.Start.X, i);
                        CountThePoint(currentPoint);
                    }
                }
                else
                {
                    if (line.Start.Y == line.End.Y)
                    {
                        var start = line.Start.X < line.End.X ? line.Start.X : line.End.X;
                        var end = line.Start.X > line.End.X ? line.Start.X : line.End.X;

                        for (int i = start; i <= end; i++)
                        {
                            var currentPoint = new Point(i, line.Start.Y);
                            CountThePoint(currentPoint);
                        }
                    }
                }

                void CountThePoint(Point currentPoint)
                {
                    if (recoredPoints.Any(p => p == currentPoint))
                        recoredPoints.First(p => p == currentPoint).AddCount();
                    else
                        recoredPoints.Add(currentPoint);
                }
            }





            return (recoredPoints.Count(x => x.Count >= 2)).ToString();
        }




        public string Puzzle2(IReadOnlyList<string> inputs)
        {

            var log = 0;
            var lines = ParsLines(inputs);
            List<Point> recoredPoints = new();
            foreach (var line in lines)
            {
                log++;
                Console.WriteLine(log);

                if (line.Start.X == line.End.X)
                {
                    var start = line.Start.Y < line.End.Y ? line.Start.Y : line.End.Y;
                    var end = line.Start.Y > line.End.Y ? line.Start.Y : line.End.Y;

                    for (int i = start; i <= end; i++)
                    {
                        var currentPoint = new Point(line.Start.X, i);
                        CountThePoint(currentPoint);
                    }
                }
                else if (line.Start.Y == line.End.Y)
                {
                    var start = line.Start.X < line.End.X ? line.Start.X : line.End.X;
                    var end = line.Start.X > line.End.X ? line.Start.X : line.End.X;

                    for (int i = start; i <= end; i++)
                    {
                        var currentPoint = new Point(i, line.Start.Y);
                        CountThePoint(currentPoint);
                    }
                }
                else if (
                    Math.Abs( line.Start.X - line.Start.Y) == Math.Abs (line.End.X - line.End.Y)
                    || Math.Abs(line.Start.X - line.End.Y) == Math.Abs(line.Start.Y - line.End.X)
                    )
                {
                    bool isStartSmallerX = line.Start.X <= line.End.X;
                    bool isStartSmallerY = line.Start.Y <= line.End.Y;


                    Point previusPouint = null;
                    while (previusPouint != line.End)
                    {
                        Point currentPoint;
                        if (previusPouint == null)
                            currentPoint = line.Start;
                        else
                        {
                            var x = isStartSmallerX ? previusPouint.X + 1 : previusPouint.X - 1;
                            var y = isStartSmallerY ? previusPouint.Y + 1 : previusPouint.Y - 1;
                            Console.WriteLine(x + "," + y);
                            currentPoint = new(x, y);

                        }
                       
                        CountThePoint(currentPoint);
                        previusPouint = currentPoint;
                    }
                }
                

                void CountThePoint(Point currentPoint)
                {
                    if (recoredPoints.Any(p => p == currentPoint))
                        recoredPoints.First(p => p == currentPoint).AddCount();
                    else
                        recoredPoints.Add(currentPoint);
                }
            }

            //Render
            //var maxX = recoredPoints.Max(x => x.X);
            //var maxY = recoredPoints.Max(y => y.Y);
            //for (int j = 0; j <= maxY; j++)
            //{
            //    for (int i   = 0; i <= maxX; i++)
            //    {
            //        if (recoredPoints.Any(x => x.X == i && x.Y == j))
            //            Console.Write(recoredPoints.First(x => x.X == i && x.Y == j).Count+$"[{i},{j}]");
            //        else
            //            Console.Write("." + $"[{i},{j}]");
            //    }
            //    Console.WriteLine();


            //}

            return (recoredPoints.Count(x => x.Count >= 2)).ToString();
        }


        private List<(Point Start, Point End)> ParsLines(IReadOnlyList<string> inputs)
        {
            List<(Point Start, Point End)> lines = new();
            foreach (var inp in inputs.Select(x => x.Split(" -> ")))
            {
                var start = inp[0].Split(',');
                var end = inp[1].Split(',');

                Point startPoint = new(int.Parse(start[0]), int.Parse(start[1]));
                Point endPoint = new(int.Parse(end[0]), int.Parse(end[1]));
                var line = (startPoint, endPoint);
                lines.Add(line);
            }
            return lines;
        }


        class Point
        {
            public int Count { get; private set; }
            public readonly int X;
            public readonly int Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
                Count = 1;
            }
            public void AddCount()
            {
                Count++;
            }
            public bool Equals(Point otherPoint)
            {
                if (otherPoint is null)
                {
                    if (this is null)
                    {
                        return true;
                    }

                    // Only the left side is null.
                    return false;
                }
                return otherPoint.X == X && otherPoint.Y == Y;
            }

            public override int GetHashCode() => (X, Y).GetHashCode();
            public static bool operator ==(Point lp, Point rp)
            {
                if (lp is null)
                {
                    if (rp is null)
                    {
                        return true;
                    }

                    // Only the left side is null.
                    return false;
                }
                // Equals handles case of null on right side.
                return lp.Equals(rp);
            }
            public static bool operator !=(Point lp, Point rp)
            {
                if (lp is null)
                {
                    if (rp is null)
                    {
                        return false;
                    }

                    // Only the left side is null.
                    return true;
                }
                // Equals handles case of null on right side.
                return !lp.Equals(rp);
            }
        }
    }
}
