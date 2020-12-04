namespace AdventOfCode
{
    public static class CheckValidNumberInRangeExtenstion
    {
        public static bool CheckValidNumberInRange(this int i, int start, int end)
        {
            return i >= start && i <= end;
        }
        public static bool CheckValidNumberInRange(this string s, int start, int end)
        {
            return int.TryParse(s, out var i) && i.CheckValidNumberInRange(start, end);
        }

        /// <summary>
        /// Tries to convert anything with ToString to a int and evaluates if it id in renege  
        /// </summary>
        public static bool CheckValidNumberInRange<T>(this T t, int start, int end) 
        {
            return int.TryParse(t.ToString(), out var i) && i.CheckValidNumberInRange(start, end);
        }
    }
}