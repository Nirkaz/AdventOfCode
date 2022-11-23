namespace AdventOfCode2021.Puzzles;

//https://adventofcode.com/2021/day/1
public static class D1SonarSweep
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var count = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD1.txt");
        var prevValue = int.Parse(input[0]);

        for (var i = 1; i < input.Length; i++)
        {
            if (int.Parse(input[i]) > prevValue) count++;
            prevValue = int.Parse(input[i]);
        }

        return count;
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        var count = 0;
        var inputRaw =
            Array.ConvertAll(customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD1.txt"), int.Parse);
        var prevValue = int.MaxValue;

        for (var i = 0; i < inputRaw.Length - 2; i++)
        {
            var sum = inputRaw[i] + inputRaw[i + 1] + inputRaw[i + 2];
            if (sum > prevValue) count++;
            prevValue = sum;
        }

        return count; // 514
    }
}