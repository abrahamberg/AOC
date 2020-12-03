using System;

namespace AdventOfCode.Exceptions
{
    public class InputFileDoesNotExistException : Exception
    {
        public InputFileDoesNotExistException(string path,string file,string message = null, Exception inner =null ):base(message,inner)
        {
            Path = path;
            File = file;
        }

        public string Path { get; }
        public string File { get; }
    }


}