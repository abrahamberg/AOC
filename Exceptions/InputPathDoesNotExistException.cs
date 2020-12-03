using System;

namespace AdventOfCode.Exceptions
{
    public class InputPathDoesNotExistException : Exception
    {
        public InputPathDoesNotExistException(string path,string message = null, Exception inner =null ):base(message,inner)
        {
            Path = path;
        }

        public string Path { get; }
    }


}