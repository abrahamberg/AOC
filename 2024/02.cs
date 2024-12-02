using AdventOfCode.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2024;



public class _02 : ISolution
{
    public string Puzzle1(IReadOnlyList<string> inputs)
    {
        var lines = inputs.Select(inp => inp.Split(' ')).ToArray();
        return lines.Count(line =>
                {
                    var numbers = line.Select(int.Parse).ToArray();
                    return IsSafe(numbers);
                })
                .ToString();
    }

    public string Puzzle2(IReadOnlyList<string> inputs)
    {
        var lines = inputs.Select(inp => inp.Split(' ')).ToArray();
        return lines.Count(line =>
                {
                    var numbers = line.Select(int.Parse).ToArray();
                    return IsSafe(numbers) || SecondChase(numbers);
                })
                .ToString();
    }


    private static bool IsSafe(int[] numbers)
    {

        bool ascending = numbers[1] - numbers[0] > 0;
        var sorted = ascending ?
            numbers.OrderBy(x => x).ToArray() :
            numbers.OrderByDescending(x => x).ToArray();
        var correctOrder = sorted.SequenceEqual(numbers);

        for (int i = 1; i < numbers.Length; i++)
        {
            var diff = Math.Abs(numbers[i] - numbers[i - 1]);
            if (diff > 3 || diff == 0) return false;
        }
        return correctOrder;
    }


    private static bool SecondChase(int[] numbers)
    {
        return Enumerable.Range(0, numbers.Length)
                 .Select(i => numbers.Where((_, index) => index != i).ToArray()) // remove one number
                 .Any(shorten => IsSafe(shorten));
    }
}
