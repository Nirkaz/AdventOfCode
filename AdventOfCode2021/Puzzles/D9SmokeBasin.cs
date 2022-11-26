using System.Diagnostics;

namespace AdventOfCode2021.Puzzles;

//https://adventofcode.com/2021/day/9
public static class D9SmokeBasin
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var risk = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD9.txt");
        var heightmap = new int[input.Length, input[0].Length];
        var height = input.Length - 1;
        var width = input[0].Length - 1;

        for (int i = 0; i <= height; i++)
            for (int j = 0; j <= width; j++)
                heightmap[i, j] = int.Parse(input[i][j].ToString());

        // Corners
        // Top-left
        if (heightmap[0, 0] < heightmap[0, 1] && 
            heightmap[0, 0] < heightmap[1, 0])
            risk += heightmap[0, 0] + 1;
        // Top-right
        if (heightmap[0, width] < heightmap[0, width - 1] && 
            heightmap[0, width] < heightmap[1, width])
            risk += heightmap[0, width] + 1;
        // Bottom-left
        if (heightmap[height, 0] < heightmap[height, 1] &&
            heightmap[height, 0] < heightmap[height - 1, 0])
            risk += heightmap[height, 0] + 1;
        // Bottom-right
        if (heightmap[height, width] < heightmap[height - 1, width] &&
            heightmap[height, width] < heightmap[height, width - 1])
            risk += heightmap[height, width] + 1;

        // Borders
        // Top
        for (int i = 1; i < width; i++)
            if (heightmap[0, i] < heightmap[0, i - 1] && // left
                heightmap[0, i] < heightmap[1, i] && // bottom
                heightmap[0, i] < heightmap[0, i + 1]) // right
                risk += heightmap[0, i] + 1;
        // Left
        for (int i = 1; i < height; i++)
            if (heightmap[i, 0] < heightmap[i - 1, 0] && // top
                heightmap[i, 0] < heightmap[i, 0 + 1] && // right
                heightmap[i, 0] < heightmap[i + 1, 0]) // bottom
                risk += heightmap[i, 0] + 1;
        // Right
        for (int i = 1; i < height; i++)
            if (heightmap[i, width] < heightmap[i - 1, width] && // top
                heightmap[i, width] < heightmap[i, width - 1] && // left
                heightmap[i, width] < heightmap[i + 1, width]) // bottom
                risk += heightmap[i, width] + 1;
        // Bottom
        for (int i = 1; i < width; i++)
            if (heightmap[height, i] < heightmap[height, i - 1] && // left
                heightmap[height, i] < heightmap[height - 1, i] && // top
                heightmap[height, i] < heightmap[height, i + 1]) // right
                risk += heightmap[height, i] + 1;

        // Inner-space
        for (int i = 1; i < height; i++)
            for (int j = 1; j < width; j++)
                if (heightmap[i, j] < heightmap[i - 1, j] &&
                    heightmap[i, j] < heightmap[i + 1, j] &&
                    heightmap[i, j] < heightmap[i, j - 1] &&
                    heightmap[i, j] < heightmap[i, j + 1])
                        risk += heightmap[i, j] + 1;

        return risk;
    }
}
