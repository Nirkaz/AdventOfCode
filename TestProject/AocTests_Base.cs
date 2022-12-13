namespace AocTests;

public class AocTests_Base
{
    internal static string[] GeneratePuzzleInput(string input)
    {
        return input.Split(Environment.NewLine);
    }

    internal static int[] GeneratePuzzleInputInts(string input)
    {
        return Array.ConvertAll(GeneratePuzzleInput(input), int.Parse);
    }

    internal static T[][] GeneratePuzzleInputAsJaggedArray<T>(string rawInput)// where T : IConvertible
    {
        var input = GeneratePuzzleInput(rawInput);
        T[][] res = new T[input.Length][];

        for (int i = 0; i < input.Length; i++)
        {
            var line = input[i];
            res[i] = Array.ConvertAll<char, T>(line.ToArray(), s => (T)Convert.ChangeType(s, typeof(T)));
        }

        return res;
    }
}