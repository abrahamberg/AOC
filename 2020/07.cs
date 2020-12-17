using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _07 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var allRules = inputs.Select(x => new BagType(x)).ToList();
            string[] currentLoopColors = {"shiny gold"};
            var includedColors = new List<string>();
            includedColors.AddRange(currentLoopColors);

            var count = 0;
            while (allRules.Any(all =>
                all.Members.Any(member =>
                    currentLoopColors.Contains(member.Key) && !includedColors.Contains(all.Name))))
            {
                var selectedBagTypes = allRules.Where(all => all.Members.Any(member =>
                    currentLoopColors.Contains(member.Key) && !includedColors.Contains(all.Name))).ToList();

                count += selectedBagTypes.Count;

                currentLoopColors = selectedBagTypes.Select(x => x.Name).ToArray();
                includedColors.AddRange(currentLoopColors);
            }

            return count.ToString();
        }


        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var allRules = inputs.Select(x => new BagType(x)).ToList();

            return CountChildren("shiny gold").ToString();

            //local function 
            int CountChildren(string name)
            {
                var count = 0;
                var bagType = allRules.FirstOrDefault(x => x.Name == name);
                if (bagType == null) return 0; //just a null check not happening though

                foreach (var (key, value) in bagType.Members)
                {
                    var countChildren = CountChildren(key);
                    if (countChildren > 0)
                        count += value * (countChildren + 1);
                    else
                        count += value;
                }
                return count;
            }
        }

        private class BagType
        {
            public BagType(string role)
            {
                var split = role.Replace("bags", "").Replace("bag", "").Split("contain");
                Name = split[0].Trim();
                Members = new List<KeyValuePair<string, int>>();
                foreach (var x in split[1].Replace(".", "").Trim().Split(",").Select(x => x.Trim()))
                {
                    if (x.Contains("no other")) continue;

                    var key = x.Substring(1, x.Length - 1).Trim();
                    var value = int.Parse(x[0].ToString());
                    Members.Add(new KeyValuePair<string, int>(key, value));
                }
            }

            public List<KeyValuePair<string, int>> Members { get; }
            public string Name { get; }
        }
    }
}