using System.Text;

namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/3
public static class D3RucksackReorganization
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var res = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD3.txt");

        foreach (var rucksack in input)
        {
            var firstHalf = rucksack[..(rucksack.Length / 2)];
            var secondHalf = rucksack[(rucksack.Length / 2)..];
            var common = firstHalf.Intersect(secondHalf).FirstOrDefault();

            var code = common - 96;
            if (code < 0)
                code = common - 38;

            res += code;
        }

        return res;
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        var res = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD3.txt");

        for (var i = 0; i < input.Length; i += 3)
        {
            var first = input[i];
            var second = input[i+1];
            var third = input[i+2];

            var common = first.Intersect(second).Intersect(third).FirstOrDefault();

            var code = common - 96;
            if (code < 0)
                code = common - 38;

            res += code;
        }

        return res;
    }
}