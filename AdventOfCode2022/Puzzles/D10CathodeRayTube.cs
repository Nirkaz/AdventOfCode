using System.Text;

namespace AdventOfCode2022.Puzzles;

//https://adventofcode.com/2022/day/10
public static class D10CathodeRayTube
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD10.txt");

        var n20 = CalculateSignalStrength(input, 20);
        var n60 = CalculateSignalStrength(input, 60);
        var n100 = CalculateSignalStrength(input, 100);
        var n140 = CalculateSignalStrength(input, 140);
        var n180 = CalculateSignalStrength(input, 180);
        var n220 = CalculateSignalStrength(input, 220);

        return n20 + n60 + n100 + n140 + n180 + n220;
    }

    private static int CalculateSignalStrength(string[] input, int cycles)
    {
        var currentCycle = 1;
        var strength = 1;

        foreach (string instruction in input)
        {
            if (currentCycle == cycles) break;

            switch (instruction)
            {
                case "noop":
                    currentCycle++;
                    break;
                default:
                    currentCycle++;
                    if (currentCycle == cycles) break;
                    currentCycle++;
                    strength += int.Parse(instruction.Split()[1]);
                    break;
            }
        }

        return currentCycle * strength;
    }

    public static string SolvePart2(string[]? customInput = null)
    {
        var res = string.Empty;
        var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD10.txt");

        var maxWidth = 40;
        var pixelCRT = 0;
        var xReg = 1;
        var spritePos = new int[] { xReg - 1, xReg, xReg + 1 };

        foreach (var instruction in input)
        {
            switch (instruction)
            {
                case "noop":
                    res += spritePos.Contains(pixelCRT) ? "#" : ".";
                    pixelCRT++;
                    break;
                default:
                    res += spritePos.Contains(pixelCRT) ? "#" : ".";
                    pixelCRT++;
                    if (pixelCRT == maxWidth) pixelCRT = 0;
                    res += spritePos.Contains(pixelCRT) ? "#" : ".";
                    pixelCRT++;
                    xReg += int.Parse(instruction.Split()[1]);
                    spritePos = new int[] { xReg - 1, xReg, xReg + 1 };
                    break;
            }

            if (pixelCRT == maxWidth) pixelCRT = 0;
        }

        return DisplayImage(res, 40);
    }

    private static string DisplayImage(string rowCRT, int pixelWidth)
    {
        var splited = Enumerable.Range(0, rowCRT.Length / pixelWidth)
            .Select(i => rowCRT.Substring(i * pixelWidth, pixelWidth));
        return string.Join(Environment.NewLine, splited);
    }
}
