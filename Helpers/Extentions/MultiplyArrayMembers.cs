using System.Linq;
using System.Numerics;

namespace AdventOfCode
{
    public static class MultiplyArrayMembersExtenstion
    {
        public static BigInteger MultiplyMembers(this int[] array)
        {
            return array.Aggregate<int, BigInteger>(1, (current, member) => current * member);
        }
    }
}