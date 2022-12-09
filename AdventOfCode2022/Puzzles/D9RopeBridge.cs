namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/9
public static class D9RopeBridge
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD9.txt");
        var head = new Knot();
        var tail = new Knot(head);

        ExecuteCommands(input, head);

        return tail.path.Distinct().Count();
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD9.txt");

        var head = new Knot();
        var tmpKnot = new Knot(head);

        for (var i = 0; i < 7; i++)
        {
            var knot = new Knot(tmpKnot);
            tmpKnot = knot;
        }

        var tail = new Knot(tmpKnot);

        ExecuteCommands(input, head);

        return tail.path.Distinct().Count();
    }

    private static void ExecuteCommands(string[] input, Knot head)
    {
        foreach (var command in input)
        {
            var direction = command.Split()[0];
            var length = int.Parse(command.Split()[1]);
            Action? headMove = null;

            switch (direction)
            {
                case "U":
                    headMove = head.GoUp;
                    break;
                case "R":
                    headMove = head.GoRight;
                    break;
                case "D":
                    headMove = head.GoDown;
                    break;
                case "L":
                    headMove = head.GoLeft;
                    break;
            }

            for (int i = 0; i < length; i++)
            {
                headMove?.Invoke();
            }
        }
    }
}

internal class Knot
{
    internal int x = 0;
    internal int y = 0;
    internal Knot? Head { get; private set; }
    internal List<string> path;

    internal delegate void MovementHandler(int x, int y);
    public event MovementHandler? HeadMoved;

    public Knot()
    {
        path = new() { $"{x},{y}" };
    }

    internal Knot(Knot head)
    {
        Head = head;
        Head.HeadMoved += OnHeadMoved;
        path = new() { $"{x},{y}" };
    }

    internal void GoUp() => HeadMoved?.Invoke(x, ++y);
    internal void GoRight() => HeadMoved?.Invoke(++x, y);
    internal void GoDown() => HeadMoved?.Invoke(x, --y);
    internal void GoLeft() => HeadMoved?.Invoke(--x, y);

    internal bool TouchingHead(int x, int y)
    {
        if (Head == null) throw new ArgumentNullException(nameof(Head));
        return !(Math.Abs(Head.x - x) >= 2 ||
            Math.Abs(Head.y - y) >= 2);
    }

    internal void OnHeadMoved(int xHead, int yHead)
    {
        if (TouchingHead(x, y))
        {
            HeadMoved?.Invoke(this.x, this.y);
            return;
        }

        // on y axis
        if (x == xHead)
        {
            path.Add($"{x},{((yHead - y > 0) ? ++y : --y)}");
            HeadMoved?.Invoke(this.x, this.y);
            return;
        }

        // x axis
        if (y == yHead)
        {
            path.Add($"{((xHead - x > 0) ? ++x : --x)},{y}");
            HeadMoved?.Invoke(this.x, this.y);
            return;
        }

        // somewhere diagonal
        // "the tail always moves one step diagonally to keep up"
        if (TouchingHead(x + 1, y + 1))
        {
            path.Add($"{++x},{++y}");
            HeadMoved?.Invoke(this.x, this.y);
            return;
        }
        if (TouchingHead(x + 1, y - 1))
        {
            path.Add($"{++x},{--y}");
            HeadMoved?.Invoke(this.x, this.y);
            return;
        }
        if (TouchingHead(x - 1, y - 1))
        {
            path.Add($"{--x},{--y}");
            HeadMoved?.Invoke(this.x, this.y);
            return;
        }
        if (TouchingHead(x - 1, y + 1))
        {
            path.Add($"{--x},{++y}");
            HeadMoved?.Invoke(this.x, this.y);
            return;
        }
    }
}