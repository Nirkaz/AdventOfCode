using System.Reflection;

namespace AdventOfCode2022;

public static class PuzzleInput
{
    public static string[] GetFromFileAsStrings(string fileName)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @$"Input\{fileName}");
        return File.ReadAllLines(path);
    }

    public static int[] GetFromFileAsInts(string fileName)
    {
        return Array.ConvertAll(GetFromFileAsStrings(fileName), int.Parse);
    }
}