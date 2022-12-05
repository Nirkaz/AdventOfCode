namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/5
public static class D5SupplyStacks
{
    public static string SolvePart1(string[]? customInput = null)
    {
        var res = string.Empty;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD5.txt");

        var emptyIndex = Array.IndexOf(input, string.Empty);
        var stacksDrawing = input[..(emptyIndex - 1)];
        var procedure = input[(emptyIndex + 1)..];

        var numberOfStacks = int.Parse(input[emptyIndex - 1].Trim().Split().Last());
        var stacks = new List<string>[numberOfStacks];
        for (var i = 0; i < numberOfStacks; i++) stacks[i] = new List<string>();

        FillStacksFromDrawing(stacksDrawing, stacks);

        foreach (var row in procedure)
        {
            var words = row.Split();
            var moveAmount = int.Parse(words[1]);
            var crateFrom = int.Parse(words[3]) - 1;
            var crateTo = int.Parse(words[5]) - 1;

            for (var i = 1; i <= moveAmount; i++)
            {
                var tmpCrate = (stacks[crateFrom])[^1];
                stacks[crateFrom].RemoveAt(stacks[crateFrom].Count - 1);
                stacks[crateTo].Add(tmpCrate);
            }
        }

        for (int i = 0; i < numberOfStacks; i++)
            res += stacks[i][^1];

        return res; //WCZTHTMPS
    }

    private static void FillStacksFromDrawing(string[] stacksDrawing, List<string>[] stacks)
    {
        foreach (var row in stacksDrawing)
        {
            var step = 0;
            for (int i = 1; i < row.Length; i += 4)
            {
                step++;
                var crate = row[i].ToString();
                if (string.IsNullOrWhiteSpace(crate)) continue;

                stacks[step - 1].Insert(0, crate);
            }
        }
    }

    public static string SolvePart2(string[]? customInput = null)
    {
        var res = string.Empty;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD5.txt");

        var emptyIndex = Array.IndexOf(input, string.Empty);
        var stacksDrawing = input[..(emptyIndex - 1)];
        var procedure = input[(emptyIndex + 1)..];

        var numberOfStacks = int.Parse(input[emptyIndex - 1].Trim().Split().Last());
        var stacks = new List<string>[numberOfStacks];
        for (var i = 0; i < numberOfStacks; i++) stacks[i] = new List<string>();

        FillStacksFromDrawing(stacksDrawing, stacks);

        foreach (var row in procedure)
        {
            var words = row.Split();
            var moveAmount = int.Parse(words[1]);
            var crateFrom = int.Parse(words[3]) - 1;
            var crateTo = int.Parse(words[5]) - 1;


            var tmpCrates = (stacks[crateFrom]).GetRange(stacks[crateFrom].Count - moveAmount, moveAmount);
            stacks[crateFrom].RemoveRange(stacks[crateFrom].Count - moveAmount, moveAmount);
            stacks[crateTo].AddRange(tmpCrates);
        }

        for (int i = 0; i < numberOfStacks; i++)
            res += stacks[i][^1];

        return res; //BLSGJSDTS
    }
}
