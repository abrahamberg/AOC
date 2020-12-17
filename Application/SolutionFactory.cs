using System;
using System.Collections.Generic;
using AdventOfCode._2020;
using Ardalis.GuardClauses;

namespace AdventOfCode.Application
{
    public static class SolutionFactory
    {
        public static ISolution Create(PuzzleName puzzleName, VersionEnum puzzleVersion)
        {
            Guard.Against.Null(puzzleName, nameof(puzzleName));
            Guard.Against.Null(puzzleVersion, nameof(puzzleVersion));

   
            var className = $@"AdventOfCode._{puzzleName.Year}._{puzzleName.Day}";
            var t = Type.GetType(className);

            if (t is null)
                throw new NotImplementedException($"{className} does not exits");

            return (ISolution) Activator.CreateInstance(t);
        }
    }
}