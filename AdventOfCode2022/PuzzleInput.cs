using System.Diagnostics.Metrics;
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

    public static T[][] GetFromFileAsJaggedArray<T>(string fileName)// where T : IConvertible
    {
        var input = GetFromFileAsStrings(fileName);
        T[][] res = new T[input.Length][];

        for (int i = 0; i < input.Length; i++)
        {
            var line = input[i];
            res[i] = Array.ConvertAll<char, T>(line.ToArray(), s => (T)Convert.ChangeType(s, typeof(T)));
        }

        return res;
    }
}