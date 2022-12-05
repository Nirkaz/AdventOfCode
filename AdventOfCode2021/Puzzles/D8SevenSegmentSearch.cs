using System.Diagnostics;

namespace AdventOfCode2021.Puzzles;

//https://adventofcode.com/2021/day/8#part2
public static class D8SevenSegmentSearch
{
    public static bool TestOne(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        return input.Length == 2;
    }

    public static bool TestFour(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        return input.Length == 4;
    }

    public static bool TestSeven(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        return input.Length == 3;
    }

    public static bool TestEight(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        return input.Length == 7;
    }

    public static bool IsDigit(string? input)
    {
        return TestOne(input) || TestFour(input) || TestSeven(input) || TestEight(input);
    }

    public static int SolvePart1(string[]? customInput = null)
    {
        var count = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD8.txt");

        foreach (var item in input)
        {
            Debug.WriteLine($"Item: {item}");
            foreach (var segment in item.Split('|')[1].Trim().Split())
            {
                Debug.WriteLine($"Segment: {segment}");
                if (IsDigit(segment)) count++;
            }
        }

        return count;
    }

    /*
         aaaa 
        b    c
        b    c
         dddd 
        e    f
        e    f
         gggg 
    */

    public static int SolvePart2(string[]? customInput = null)
    {
        var segments = new string[7];
        var count = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD8.txt");

        foreach (var item in input)
        {
            Debug.WriteLine($"Item: {item}");
            var output = item.Split('|')[0].Trim().Split().OrderBy(s => s.Length).ToArray();

            foreach (var segment in output)
            {
                Debug.WriteLine($"Segment: {segment}");
                if (IsDigit(segment)) count++;
            }
        }

        return count;
    }
}
