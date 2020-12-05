using System;
using System.Collections.Generic;
using AdventOfCode._2020;
using Ardalis.GuardClauses;

namespace AdventOfCode.Application
{
    public static class SolutionFactory
    {
        public static Solution Create(PuzzleName puzzleName, VersionEnum puzzleVersion, IEnumerable<string> inputs)
        {
            Guard.Against.Null(puzzleName, nameof(puzzleName));
            Guard.Against.Null(puzzleVersion, nameof(puzzleVersion));

   
            var className = $@"AdventOfCode._{puzzleName.Year}._{puzzleName.Day}";
            var t = Type.GetType(className);

            if (t is null)
                throw new NotImplementedException($"{className} does not exits");

            return (Solution) Activator.CreateInstance(t, inputs, puzzleVersion);
        }
    }
}