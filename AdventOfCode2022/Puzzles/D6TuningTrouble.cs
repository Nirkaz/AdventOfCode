namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/6
public static class D6TuningTrouble
{
    public static int SolvePart1(string[]? customInput = null)
    {
        int res;
        var markerSize = 4;
        var input = customInput?.FirstOrDefault() ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD6.txt").FirstOrDefault();

        if (input == null) throw new ArgumentNullException(nameof(input));

        var marker = input[..markerSize];
        if (MarkerCheck(marker, markerSize)) return markerSize;

        for (res = markerSize + 1;  res <= input.Length; res++)
        {
            marker = input[(res - markerSize)..res];
            if (MarkerCheck(marker, markerSize)) break;
        }

        return res;
    }

    private static bool MarkerCheck(string marker, int markerSize)
    {
        if (string.IsNullOrWhiteSpace(marker)) 
            throw new ArgumentNullException(nameof(marker));

        if (marker.Length != markerSize) 
            throw new ArgumentOutOfRangeException(nameof(marker));

        var one = string.Empty;
        var two = string.Empty;

        for (int i = 0; i < marker.Length; i++)
        {
            one = marker.Substring(i, 1);
            for (int j = 0; j < marker.Length; j++)
            {
                two = marker.Substring(j, 1);
                if ((one == two) && (i != j))
                    return false;
            }
        }

        return true;
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        int res;
        var markerSize = 14;
        var input = customInput?.FirstOrDefault() ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD6.txt").FirstOrDefault();

        if (input == null) throw new ArgumentNullException(nameof(input));

        var marker = input[..markerSize];
        if (MarkerCheck(marker, markerSize)) return markerSize;

        for (res = markerSize + 1; res <= input.Length; res++)
        {
            marker = input[(res - markerSize)..res];
            if (MarkerCheck(marker, markerSize)) break;
        }

        return res;
    }
}
