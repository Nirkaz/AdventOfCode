namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/4
public static class D4CampCleanup

{
    public static int SolvePart1(string[]? customInput = null)
    {
        var res = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD4.txt");

        foreach (var assignments in input)
        {
            var pair = assignments.Split(',');
            var first = pair[0].Split('-');
            var second = pair[1].Split('-');

            var firstLeft = int.Parse(first[0]);
            var firstRight = int.Parse(first[1]);
            var secondLeft = int.Parse(second[0]);
            var secondRight = int.Parse(second[1]);

            if (firstLeft >= secondLeft && firstRight <= secondRight
                || secondLeft >= firstLeft && secondRight <= firstRight)
                res++;
        }

        return res;
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        var res = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD4.txt");

        foreach (var assignments in input)
        {
            var pair = assignments.Split(',');
            var first = pair[0].Split('-');
            var second = pair[1].Split('-');

            var firstLeft = int.Parse(first[0]);
            var firstRight = int.Parse(first[1]);
            var secondLeft = int.Parse(second[0]);
            var secondRight = int.Parse(second[1]);

            if (firstLeft >= secondLeft && firstRight <= secondRight
                || secondLeft >= firstLeft && secondRight <= firstRight
                || firstRight >= secondLeft && firstLeft < secondLeft
                || firstLeft <= secondRight && firstRight > secondRight
                || secondRight >= firstLeft && secondLeft < firstLeft
                || secondLeft <= firstRight && secondRight > firstRight)
                res++;
        }

        return res;
    }
}
