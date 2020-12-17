using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _11 : ISolution
    {
    
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var start = inputs.ToArray();
            var current = new char[start.Length, start[0].Length];
            for (var i = 0; i < start.Length; i++)
            for (var j = 0; j < start[0].Length; j++)
                current[i, j] = start[i][j];

            while (true)
            {
                var next = new char[start.Length, start.First().Length];
                //  change = false;
                for (var i = 0; i < current.GetLength(0); ++i)
                for (var j = 0; j < current.GetLength(1); ++j)
                    if (start[i][j] == '.')
                    {
                        next[i, j] = '.';
                    }
                    else
                    {
                        var count = CountAdjacent(i, j);
                        next[i, j] = current[i, j] switch
                        {
                            'L' when count == 0 => '#',
                            '#' when count >= 4 => 'L',
                            _ => current[i, j]
                        };
                    }

                var equal = current.Cast<char>().SequenceEqual(next.Cast<char>());
                if (equal)
                    return current.Cast<char>().Count(node => node == '#').ToString();

                current = next;
            }


            int CountAdjacent(int y, int x)
            {
                var count = 0;
                for (var i = -1; i <= 1; ++i)
                for (var j = -1; j <= 1; ++j)
                {
                    if (i == 0 && j == 0) continue;
                    if (y + i >= 0
                        && y + i < current.GetLength(0)
                        && x + j >= 0 && x + j < current.GetLength(1)
                        && current[y + i, x + j] == '#') count++;
                }

                return count;
            }
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var start = inputs.ToArray();
            var current = new char[start.Length, start[0].Length];
            for (var i = 0; i < start.Length; i++)
            for (var j = 0; j < start[0].Length; j++)
                current[i, j] = start[i][j];

            while (true)
            {
                var next = new char[start.Length, start.First().Length];
                //  change = false;
                for (var i = 0; i < current.GetLength(0); ++i)
                for (var j = 0; j < current.GetLength(1); ++j)
                    if (start[i][j] == '.')
                    {
                        next[i, j] = '.';
                    }
                    else
                    {
                        var count = CountVisible(i, j);
                        next[i, j] = current[i, j] switch
                        {
                            'L' when count == 0 => '#',
                            '#' when count >= 5 => 'L',
                            _ => current[i, j]
                        };
                    }

                var equal = current.Cast<char>().SequenceEqual(next.Cast<char>());
                if (equal)
                    return current.Cast<char>().Count(node => node == '#').ToString();

                current = next;
            }

            int CountVisible(int y, int x)
            {
                var count = 0;
                if (CrawlerFindsTaken(-1, 0)) count++; //top
                if (CrawlerFindsTaken(-1, 1)) count++;
                if (CrawlerFindsTaken(0, 1)) count++; //right
                if (CrawlerFindsTaken(1, 1)) count++;
                if (CrawlerFindsTaken(1, 0)) count++; // down
                if (CrawlerFindsTaken(1, -1)) count++;
                if (CrawlerFindsTaken(0, -1)) count++; //left
                if (CrawlerFindsTaken(-1, -1)) count++;

                return count;

                //Move to directions by -1 , 0 ,and 1
                bool CrawlerFindsTaken(int crawlY, int crawlX) 
                {
                    var movingX = x + crawlX;
                    var movingY = y + crawlY;
                    while (movingX >= 0 && movingX < current.GetLength(1)
                                        && movingY >= 0 && movingY < current.GetLength(0))
                    {
                        switch (current[movingY, movingX])
                        {
                            case 'L': return false;
                            case '#': return true;
                        }

                        movingX += crawlX;
                        movingY += crawlY;
                    }
                    return false;
                }
            }
        }
    }
}