using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _08 : Solution
    {
        public _08(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            var currentValue = 0;

            var all = inputs.Select(x => new Model(x)).ToArray();
            var i = 0;
            while (true)
            {
                if (all[i].value.HasValue) 
                    return currentValue.ToString();

                switch (all[i].Instrucrion)
                {
                    case "acc":
                        currentValue += all[i].no;
                        all[i].value = currentValue;
                        i = i + 1;
                        continue;
                    case "jmp":
                        all[i].value = currentValue;
                        i = i + all[i].no;
                        continue;
                    case "nop":
                        all[i].value = currentValue;
                        i = i + 1;
                        continue;
                    default:
                        throw new Exception();
                }

            }
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var org = inputs.Select(x => new Model(x));
            var all = org.ToArray();

            for (var i = 0; i < all.Length; i++)
                switch (all[i].Instrucrion)
                {
                    case "acc":
                        break;
                    case "jmp":
                        var newAll = org.ToArray();
                        newAll[i].Instrucrion = "nop";
                        if (CanFinish(newAll, out var val))
                            return val.ToString();
                        break;
                    case "nop":
                        var newAll2 = org.ToArray();
                        newAll2[i].Instrucrion = "jmp";
                        if (CanFinish(newAll2, out var val2))
                            return val2.ToString();
                        break;
                    default:
                        throw new Exception();
                }

            return "NON";
        }

        private static bool CanFinish(Model[] models, out int finishVal)
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
                if (models[i].value.HasValue)
                {
                    finishVal = currentValue;
                    return false;
                }

                switch (models[i].Instrucrion)
                {
                    case "acc":
                        currentValue += models[i].no;
                        models[i].value = currentValue;
                        i = i + 1;
                        continue;
                    case "jmp":
                        models[i].value = currentValue;
                        i = i + models[i].no;
                        continue;
                    case "nop":
                        models[i].value = currentValue;
                        i = i + 1;
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
                Instrucrion = input.Substring(0, 3);
                no = int.Parse(input.Substring(3, input.Length - 3));
                value = null;
            }

            public string Instrucrion { get; set; }
            public int no { get; }

            public int? value { get; set; }
        }
    }
}