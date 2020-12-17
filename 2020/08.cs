using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _08 : ISolution
    {
   

        // Puzzle  1
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var currentValue = 0;

            var all = inputs.Select(x => new Model(x)).ToArray();
            var i = 0;
            while (true)
            {
                if (all[i].Value.HasValue)
                    return currentValue.ToString();

                switch (all[i].Instruction)
                {
                    case "acc":
                        currentValue += all[i].Number;
                        all[i].Value = currentValue;
                        i++;
                        continue;
                    case "jmp":
                        all[i].Value = currentValue;
                        i += all[i].Number;
                        continue;
                    case "nop":
                        all[i].Value = currentValue;
                        i++;
                        continue;
                    default:
                        throw new Exception();
                }
            }
        }


        // Puzzle  2
        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var enumerable = inputs.Select(x => new Model(x));
            var all = enumerable.ToArray();

            for (var i = 0; i < all.Length; i++)
                switch (all[i].Instruction)
                {
                    case "acc":
                        break;
                    case "jmp":
                        var newAll = enumerable.ToArray(); //Make a fresh clone of IEnumerable 
                        newAll[i].Instruction = "nop";
                        if (IsCompetePath(newAll, out var val))
                            return val.ToString();
                        break;
                    case "nop":
                        var newAll2 = enumerable.ToArray();
                        newAll2[i].Instruction = "jmp";
                        if (IsCompetePath(newAll2, out var val2))
                            return val2.ToString();
                        break;
                    default:
                        throw new Exception();
                }

            return "NON";
        }

        private static bool IsCompetePath(Model[] models, out int finishVal)
        {
            var currentValue = 0;
            var i = 0;
            while (true)
            {
                if (i > models.Length - 1) //You finished it
                {
                    finishVal = currentValue;
                    return true;
                }

                if (models[i].Value.HasValue)
                {
                    finishVal = currentValue;
                    return false;
                }

                switch (models[i].Instruction)
                {
                    case "acc":
                        currentValue += models[i].Number;
                        models[i].Value = currentValue;
                        i++;
                        continue;
                    case "jmp":
                        models[i].Value = currentValue;
                        i += models[i].Number;
                        continue;
                    case "nop":
                        models[i].Value = currentValue;
                        i++;
                        continue;
                    default:
                        throw new Exception();
                }
            }
        }

        private class Model
        {
            public Model(string input)
            {
                Instruction = input.Substring(0, 3);
                Number = int.Parse(input.Substring(3, input.Length - 3));
                Value = null;
            }

            public string Instruction { get; set; }
            public int Number { get; }

            public int? Value { get; set; }  //We can actually implement it with a boolean as it only check if we ever been here.
        }
    }
}