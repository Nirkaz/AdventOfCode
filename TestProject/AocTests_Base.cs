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
}