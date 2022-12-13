using System.Collections.Generic;

namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/12
public static class D12HillClimbingAlgorithm
{
    public static int SolvePart1(char[][]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsJaggedArray<char>("PuzzleInputD12.txt");
        GenerateGraph(input, out Dictionary<string, HashSet<Hill>> graphs, out Hill start, out _);

        return SearchBFS(graphs, start);
    }

    public static int SolvePart2(char[][]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsJaggedArray<char>("PuzzleInputD12.txt");
        GenerateGraph(input, out Dictionary<string, HashSet<Hill>> graphs, out Hill start, out List<Hill> possibleStarts);

        return possibleStarts.Select(s => SearchBFS(graphs, s)).Min();
    }

    private static void GenerateGraph(char[][] input, out Dictionary<string, HashSet<Hill>> graphs, out Hill start, out List<Hill> hills)
    {
        graphs = new Dictionary<string, HashSet<Hill>>();
        start = new Hill();
        hills = new List<Hill>();

        for (int x = 0; x < input.Length; x++)
        {
            for (int y = 0; y < input[x].Length; y++)
            {
                var hill = input[x][y];
                var key = $"({x},{y}): {hill}";

                if (hill == 'S')
                    start.Body = key;

                if (hill == 'S' || hill == 'a')
                    hills.Add(new Hill(key));

                var neighbors = new List<Hill>();
                var height = 1;

                //top
                if (y - 1 >= 0 &&
                    CanTraverse(hill, input[x][y - 1], height))
                {
                    var top = new Hill($"({x},{y - 1}): {input[x][y - 1]}");
                    neighbors.Add(top);
                }
                //right
                if (x + 1 < input.Length &&
                    CanTraverse(hill, input[x + 1][y], height))
                {
                    var right = new Hill($"({x + 1},{y}): {input[x + 1][y]}");
                    neighbors.Add(right);
                }
                //bottom
                if (y + 1 < input[x].Length &&
                    CanTraverse(hill, input[x][y + 1], height))
                {
                    var bottom = new Hill($"({x},{y + 1}): {input[x][y + 1]}");
                    neighbors.Add(bottom);
                }
                //left
                if (x - 1 >= 0 &&
                    CanTraverse(hill, input[x - 1][y], height))
                {
                    var left = new Hill($"({x - 1},{y}): {input[x - 1][y]}");
                    neighbors.Add(left);
                }

                graphs.Add(key, new HashSet<Hill>(neighbors));
            }
        }
    }

    private static bool CanTraverse(char from, char to, int height)
    {
        if (from == to) return true;
        if (from == 'E') return true;
        var iTo = (to == 'E') ? 'z' : to;
        var iFrom = (from == 'S') ? 'a' : from;

        return (iTo - iFrom) <= height;
    }

    internal class Hill
    {
        internal string? Body;
        internal Hill? Parent;

        public Hill() { }
        public Hill(string body)
        {
            Body = body;
        }
    }

    private static int SearchBFS(Dictionary<string, HashSet<Hill>> graph, Hill start)
    {
        var end = new Hill();

        Queue<Hill> searchQueue = new();
        Queue<string> searched = new();

        searchQueue.Enqueue(start);

        while (searchQueue.Count > 0)
        {
            var hill = searchQueue.Dequeue();
            if (!searched.Contains(hill.Body))
            {
                if (hill.Body.Contains('E'))
                {
                    end = hill;
                    searched.Enqueue(hill.Body);
                    break;
                }
                else
                {
                    searched.Enqueue(hill.Body);
                    var items = graph[hill.Body].ToList();
                    foreach (var item in items)
                    {
                        item.Parent = hill;
                        searchQueue.Enqueue(item);
                    }
                }
            }
        }

        if (end?.Parent == null) return int.MaxValue;

        var tmp = end.Parent; 
        var count = 1;

        while (tmp.Parent != null)
        {
            tmp = tmp.Parent;
            count++;
        }

        return count;
    }
}
