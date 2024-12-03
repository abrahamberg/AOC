using AdventOfCode.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024;



public class _03 : ISolution
{
    public string Puzzle1(IReadOnlyList<string> inputs)
    {

        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        MatchCollection matches = Regex.Matches(string.Join(' ', inputs), pattern);
        return matches.
            Aggregate(0, (acc, match)
                => acc + int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value))
            .ToString();
    }

    public string Puzzle2(IReadOnlyList<string> inputs)
    {
        var clean = string.Join(' ', inputs).Split("do()").Select(x => x.Split("don't()")[0]).ToArray();
        return Puzzle1(clean);
    }


}
