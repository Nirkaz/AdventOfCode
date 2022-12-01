namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/1
public static class D1CalorieCounting
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var maxCalories = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD1.txt");

        var currentCount = 0;
        foreach (var item in input)
        {
            if (string.IsNullOrEmpty(item))
            {
                if (currentCount > maxCalories)
                    maxCalories= currentCount;

                currentCount = 0;
                continue; 
            }

            currentCount += int.Parse(item);
        }

        return maxCalories;
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD1.txt");
        var calloriesList = new List<int>();
        var currentCount = 0;

        foreach (var item in input)
        {
            if (string.IsNullOrEmpty(item))
            {
                calloriesList.Add(currentCount);
                currentCount = 0;
                continue;
            }

            currentCount += int.Parse(item);
        }

        calloriesList.Add(currentCount);

        return calloriesList.OrderByDescending(s => s).Take(3).Sum();
    }
}