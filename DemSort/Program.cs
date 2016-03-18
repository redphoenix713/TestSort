using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DemSort
{
    public static class Program
    {
        public static IEnumerable<string> SortedContents { get; set; }

        private static void Main(string[] args)
        {
            if (args[0] == null) return;
            var contents = ReadFile(args[0]);
            if(contents == null || !contents.Any()) return;
            if (Sort(contents))
            {
                WriteToFile(Path.Combine(Path.GetDirectoryName(args[0]), "sorted_score.txt"), SortedContents);
            }
            else
            {
                Console.WriteLine("Error: Incorrect input format !");
            }
        }

        private static IEnumerable<string> ReadFile(string inputFilePath)
        {
            var lines = new List<string>();
            if (File.Exists(inputFilePath))
            {
                using (var sr = new StreamReader(inputFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }                
            }
            else
            {
                Console.WriteLine("Error: The file {0} doesn't exist\n", inputFilePath);                
            }
            return lines;
        }

        public static bool Sort(IEnumerable<string> contents)
        {
            var delimiter = new[] { ',' };            
            try
            {                
                SortedContents = contents.Select(x => x.Trim().Split(delimiter).ToArray())
                .OrderByDescending(x => x[2])
                .ThenBy(x => x[0])
                .ThenBy(x => x[1])
                .Select(x => string.Join(",", x)).ToList();
                return true;
            }
            catch (IndexOutOfRangeException)
            {                
                return false;
            }                                         
        }

        private static void WriteToFile(string outputFilePath, IEnumerable<string> contents)
        {
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }
            using (var sw = new StreamWriter(outputFilePath))
            {
                foreach (var content in contents)
                {
                    sw.WriteLine(content);
                }
            }
            Console.WriteLine("Finished: Created {0}", outputFilePath);
        }
    }
}
