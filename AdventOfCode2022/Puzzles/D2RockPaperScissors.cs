using System.Text;

namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/2
public static class D2RockPaperScissors
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var score = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD2.txt");

        foreach (var round in input)
        {
            var plays = round.Split();
            var roundScore = 0;

            switch (plays[1])
            {
                case "X":
                    plays[1] = "A";
                    roundScore = 1;
                    break;
                case "Y":
                    plays[1] = "B";
                    roundScore = 2;
                    break;
                case "Z":
                    plays[1] = "C";
                    roundScore = 3;
                    break;
            }

            if (plays[0] == plays[1])
                roundScore += 3;

            if (plays[0] == "A" && plays[1] == "B"
                || plays[0] == "B" && plays[1] == "C"
                || plays[0] == "C" && plays[1] == "A") 
                roundScore+= 6;

            score += roundScore;
        }

        return score;
    }

    public static int SolvePart2(string[]? customInput = null)
    {
        // X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win.
        var score = 0;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD2.txt");

        foreach (var round in input)
        {
            var plays = round.Split();
            var roundScore = 0;

            switch (plays[1])
            {
                case "X": // lose
                    switch (plays[0])
                    {
                        case "A":
                            plays[1] = "C";
                            break; 
                        case "B":
                            plays[1] = "A";
                            break; 
                        case "C":
                            plays[1] = "B";
                            break;
                    }
                    break;
                case "Y": // draw
                    plays[1] = plays[0];
                    break;
                case "Z": // win
                    switch (plays[0])
                    {
                        case "A":
                            plays[1] = "B";
                            break;
                        case "B":
                            plays[1] = "C";
                            break;
                        case "C":
                            plays[1] = "A";
                            break;
                    }
                    break;
            }

            switch (plays[1])
            {
                case "A":
                    roundScore = 1;
                    break;
                case "B":
                    roundScore = 2;
                    break;
                case "C":
                    roundScore = 3;
                    break;
            }

            if (plays[0] == plays[1])
                roundScore += 3;

            if (plays[0] == "A" && plays[1] == "B"
                || plays[0] == "B" && plays[1] == "C"
                || plays[0] == "C" && plays[1] == "A")
                roundScore += 6;

            score += roundScore;
        }

        return score;
    }
}