using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;

namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/11
public static class D11MonkeyInTheMiddle
{
    public static long SolvePart1(string[]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD11.txt");
        var playground = new Playground(20, true);

        SetupGame(input, playground);
        playground.PlayTheGame();

        return playground.MonkeyBusiness;
    }

    public static long SolvePart2(string[]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD11.txt");
        var playground = new Playground(10000, false);

        SetupGame(input, playground);
        playground.PlayTheGame();

        return playground.MonkeyBusiness;
    }

    private static void SetupGame(string[] input, Playground playground)
    {
        var sb = new StringBuilder();

        foreach (var item in input)
        {
            if (string.IsNullOrEmpty(item))
            {
                playground.AddMonkey(sb.ToString().Split(Environment.NewLine));
                sb.Clear();
            }
            else
            {
                sb.AppendLine(item);
            }
        }
        playground.AddMonkey(sb.ToString().Split(Environment.NewLine));
    }
}

internal class Playground
{
    private readonly int _rounds;

    internal bool CanRelief { get; private set; }
    internal long Multiplier { get; private set; }
    internal long MonkeyBusiness { get; private set; }
    internal List<Monkey> Monkeys { get; private set; } = new();

    public Playground(int rouds, bool canRelief)
    {
        _rounds = rouds;
        CanRelief = canRelief;
    }

    internal void AddMonkey(string[] description)
    {
        var monkeyNumber = int.Parse(description[0].Split()[1].TrimEnd(':'));
        var items = Array.ConvertAll(description[1].Split(':').Last().Trim().Split(','), long.Parse).ToList();
        var operation = description[2].Split(':').Last().Trim();
        var test = description[3].Split(':').Last().Trim();
        var trueClause = description[4].Split(':').Last().Trim();
        var falseClause = description[5].Split(':').Last().Trim();

        var monkey = new Monkey(this, monkeyNumber, items, operation, test, trueClause, falseClause);

        Monkeys.Add(monkey);
    }

    internal void PlayTheGame()
    {
        Multiplier = Monkeys.Aggregate(1, (long a, Monkey x) => a * x.TestDivisor);

        for (var i = 1; i <= _rounds; i++)
        {
            foreach (var monkey in Monkeys)
            {
                monkey.MakeDecisions();
            }

            if (i == 1 || i == 20 || i == 1000 || 
                i == 2000 || i == 3000 || i == 4000 || 
                i == 5000 || i == 6000 || i == 7000 || 
                i == 8000 || i == 9000 || i == 10000) 
                MakeSnapshot(i);
        }

        var topScores = Monkeys.Select(s => s.ItemsInspected).OrderDescending().Take(2).ToList();
        MonkeyBusiness = topScores[0] * topScores[1];
    }

    private void MakeSnapshot(int round)
    {
        Debug.WriteLine($"== After round {round} ==");
        foreach (var monkey in Monkeys)
        {
            Debug.WriteLine($"Monkey {monkey.Number} inspected items {monkey.ItemsInspected} times.");
        }
        Debug.WriteLine(Environment.NewLine);
    }

    internal void ThrowItem(int from, int to)
    {
        Monkeys[to].Items.Add(Monkeys[from].CurrentItem);
    }
}

internal class Monkey
{
    private readonly Playground _playground;
    private readonly string _operation;
    private readonly int _monkeyToThrowIfTrue;
    private readonly int _monkeyToThrowIfFalse;

    internal int Number { get; set; }
    internal List<long> Items { get; set; }
    internal long CurrentItem { get; private set; }
    internal long ItemsInspected { get; private set; }
    internal long TestDivisor { get; private set; }

    public Monkey(Playground playground, int number, List<long> items, string operation, string test, string trueClause, string falseClause)
    {
        _playground = playground;
        Number = number;
        Items = items;
        _operation = operation;
        TestDivisor = long.Parse(test.Split().Last());
        _monkeyToThrowIfTrue = int.Parse(trueClause.Split().Last());
        _monkeyToThrowIfFalse = int.Parse(falseClause.Split().Last());
    }

    internal void MakeDecisions()
    {
        foreach (var item in Items)
        {
            CurrentItem = item;
            CurrentItem = Operation(CurrentItem);

            if (_playground.CanRelief)
                Relief();
            else
                CurrentItem %= _playground.Multiplier;

            if (Test())
                TrueClause();
            else
                FalseClause();

            ItemsInspected++;
        }

        Items.Clear();
    }

    private long Operation(long oldValue)
    {
        long newValue = 0;

        var logic = _operation.Split('=').Last().Trim().Split();
        newValue = logic[1] switch
        {
            "+" => oldValue + long.Parse(logic[2]),
            "*" => oldValue * (logic[2] == "old" ? oldValue : long.Parse(logic[2])),
            _ => throw new NotImplementedException(),
        };
        return newValue;
    }

    internal void Relief() => CurrentItem = (long)Math.Floor(CurrentItem / 3d);

    private bool Test() => CurrentItem % TestDivisor == 0;

    private void TrueClause() => _playground.ThrowItem(Number, _monkeyToThrowIfTrue);

    private void FalseClause() => _playground.ThrowItem(Number, _monkeyToThrowIfFalse);
}
