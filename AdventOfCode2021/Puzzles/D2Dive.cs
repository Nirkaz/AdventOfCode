namespace AdventOfCode2021.Puzzles;

//https://adventofcode.com/2021/day/2
public static class D2Dive
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var horizontalPosition = 0;
        var depth = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD2.txt");

        foreach (var line in input)
        {
            var command = line.Split()[0];
            var value = int.Parse(line.Split()[1]);

            switch (command)
            {
                case "forward":
                    horizontalPosition += value;
                    break;
                case "down":
                    depth += value;
                    break;
                case "up":
                    depth -= value;
                    break;
            }
        }

        return horizontalPosition * depth;
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        var horizontalPosition = 0;
        var depth = 0;
        var aim = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD2.txt");

        foreach (var line in input)
        {
            var command = line.Split()[0];
            var value = int.Parse(line.Split()[1]);

            switch (command)
            {
                case "forward":
                    horizontalPosition += value;
                    depth += aim * value;
                    break;
                case "down":
                    aim += value;
                    break;
                case "up":
                    aim -= value;
                    break;
            }
        }

        return horizontalPosition * depth;
    }
}
