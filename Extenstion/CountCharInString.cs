namespace AdventOfCode
{
    public static class CountCharInStringExtenstion
    {
        public static int CountChars(this string input, char c)
        {
            return input.Split(c).Length - 1;
        }
    }
}