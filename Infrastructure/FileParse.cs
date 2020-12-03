using System.Collections.Generic;
using System.IO;
using AdventOfCode.Exceptions;

namespace AdventOfCode.Infrastructure
{
    public static class FileParse
    {
        public static IEnumerable<string> GetRows(string basePath, string fileName)
        {
            var results = new List<string>();
            var fullPath = Path.GetFullPath(basePath);
            if( ! Directory.Exists(fullPath))
                throw  new InputPathDoesNotExistException(fullPath);

            var filePath = Path.Combine(basePath, fileName);
            if (!File.Exists(filePath))
                throw new InputFileDoesNotExistException(fullPath, fileName);

            var file = new StreamReader(filePath);
            string line;
            while ((line = file.ReadLine()) != null) results.Add(line);
            file.Close();

            return results;
        }
    }
}