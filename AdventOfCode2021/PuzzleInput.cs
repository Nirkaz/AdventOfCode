using System.Reflection;

namespace AdventOfCode2021
{
    public static class PuzzleInput
    {
        public static string[] GetFromFileAsStrings(string fileName)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @$"Input\{fileName}");
            return File.ReadAllLines(path);
        }
    }
}
