using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _14 : ISolution
    {

        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            
            var memory = new Dictionary<long, long>();
            var msk = "".PadLeft(36, 'X');

            foreach (var input in inputs)
            {
                if (input.Contains("mask"))
                {
                    msk = input.Split('=')[1].Trim();
                    continue;
                }

                var split = input.Split('=');

                var key = int.Parse(split[0].Replace("mem[", "").Replace("]", ""));
                var v = long.Parse(split[1].Trim());
                var b = Convert.ToString(v, 2);
                var b36 = b.PadLeft(36, '0');
                var filtered = new char[36];
                for (var i = 0; i < b36.Length; i++) filtered[i] = msk[i] == 'X' ? b36[i] : msk[i];


                long u = 0;
                foreach (var c in filtered)
                {
                    u *= 2;
                    u += c - '0';
                }

                memory[key] = u;
                
            }

            return memory.Values.Sum().ToString();
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var memory = new Dictionary<long, long>();
            var msk = "".PadLeft(36, 'X');

            foreach (var input in inputs)
            {
                if (input.Contains("mask"))
                {
                    msk = input.Split('=')[1].Trim();
                    continue;
                }

                var split = input.Split('=');
                var key = int.Parse(split[0].Replace("mem[", "").Replace("]", ""));
                var value = long.Parse(split[1].Trim());

                foreach (var address in MemoryAddresses(msk.ToCharArray(), key)) memory[address] = value;
            }

            return memory.Values.Sum().ToString();
        }


        public static IEnumerable<long> MemoryAddresses(char[] mask, long address)
        {
            var tails = mask[^1] switch
            {
                'X' => new[] {0L, 1},
                '0' => new[] {address & 1},
                _ => new[] {1L}
            };
           Console.WriteLine($"char:{ mask[^1]} \t tails:{tails.Select(x=>x.ToString()).Aggregate((x,y)=> x+= ","+y)} \t{Convert.ToString(address,2)}  {address}  \t {new string(mask)}");
            return mask.Length == 1 ? tails
                : tails.SelectMany(tail => 
                        MemoryAddresses(mask[..^1], address >> 1)
                         .Select(head => (head << 1) | tail));


           
        }
    }
}