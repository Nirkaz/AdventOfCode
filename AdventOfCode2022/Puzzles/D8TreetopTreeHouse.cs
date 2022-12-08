namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/8
public static class D8TreetopTreeHouse
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD8.txt");
        var width = input.FirstOrDefault().Length;
        var height = input.Length;
        var treesVisible = 2 * width + 2 * (height - 2);
        int[][] rows = new int[height][];
        int[][] columns = new int[width][];

        FillRows(input, height, rows);
        FillColumns(width, height, rows, columns);

        for (var i = 1; i < height - 1; i++)
        {
            for (var j = 1; j < width - 1; j++)
            {
                if (TreeIsVisible(rows[i][j], i, j, rows[i], columns[j]))
                    treesVisible++;
            }
        }

        return treesVisible;
    }

    private static void FillColumns(int width, int height, int[][] rows, int[][] columns)
    {
        for (int j = 0; j < width; j++)
        {
            var column = new List<int>();
            for (int i = 0; i < height; i++)
            {
                column.Add(rows[i][j]);
            }
            columns[j] = column.ToArray();
        }
    }

    private static void FillRows(string[] input, int height, int[][] rows)
    {
        for (var i = 0; i < height; i++)
        {
            rows[i] = Array.ConvertAll(input[i].ToArray(), s => int.Parse(s.ToString()));
        }
    }

    private static bool TreeIsVisible(int tree, int i, int j, int[] row, int[] column)
    {
        //top
        if (column[..i].All(s => s < tree)) 
            return true;
        //bottom
        if (column[(i + 1)..].All(s => s < tree))
            return true;
        //left
        if (row[..j].All(s => s < tree))
            return true;
        //right
        if (row[(j + 1)..].All(s => s < tree))
            return true;

        return false;
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD8.txt");
        var width = input.FirstOrDefault().Length;
        var height = input.Length;
        var maxScenicScore = 0;
        int[][] rows = new int[height][];
        int[][] columns = new int[width][];

        FillRows(input, height, rows);
        FillColumns(width, height, rows, columns);

        //scenic score
        for (var i = 1; i < height - 1; i++)
        {
            for (var j = 1; j < width - 1; j++)
            {
                var treeScore = CalcTreeScenicScore(rows[i][j], i, j, rows[i], columns[j]);
                if (treeScore > maxScenicScore) maxScenicScore = treeScore;
            }
        }

        return maxScenicScore;
    }

    private static int CalcTreeScenicScore(int tree, int i, int j, int[] row, int[] column)
    {
        var top = 0;
        for (var t = i - 1; t >= 0; t--)
        {
            top++;
            if (column[t] >= tree) break;
        }

        var bottom = 0;
        for (var t = i + 1; t < column.Length; t++)
        {
            bottom++;
            if (column[t] >= tree) break;
        }

        var left = 0;
        for (var t = j - 1; t >= 0; t--)
        {
            left++;
            if (row[t] >= tree) break;
        }

        var right = 0;
        for (var t = j + 1; t < row.Length; t++)
        {
            right++;
            if (row[t] >= tree) break;
        }

        return top * bottom * left * right;
    }
}