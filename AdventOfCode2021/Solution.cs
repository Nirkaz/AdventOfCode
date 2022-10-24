using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal static class Solution
    {
        private static string[] GetPuzzleInput(string fileName)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"Input\{fileName}");
            return File.ReadAllLines(path);
        }

        //https://adventofcode.com/2021/day/1
        public static int D1SonarSweep()
        {
            var count = 0;
            var inputRaw = Array.ConvertAll(GetPuzzleInput("PuzzleInputD1.txt"), s => int.Parse(s));
            var prevValue = int.MaxValue;

            for (var i = 0; i < inputRaw.Length - 2; i++)
            {
                var sum = inputRaw[i] + inputRaw[i+1] + inputRaw[i+2];
                if (sum > prevValue) count++;
                prevValue = sum;
            }

            return count; // 514
        }

        //https://adventofcode.com/2021/day/2
        public static int D2Dive()
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;
            var input = GetPuzzleInput("PuzzleInputD2.txt");

            foreach (var line in input)
            {
                var command = line.Split()[0];
                var value = int.Parse(line.Split()[1]);

                switch (command)
                {
                    case "forward":
                        horizontalPosition += value;
                        depth += aim * value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    default:
                        break;
                }
            }

            return horizontalPosition * depth;
        }

        //https://adventofcode.com/2021/day/3
        public static int D3BinaryDiagnostic()
        {
            var gammaString = string.Empty;
            var epsilonString = string.Empty;
            var inputRaw = GetPuzzleInput("PuzzleInputD3.txt");

            var gammaArray = new int[inputRaw.FirstOrDefault().Length];
            foreach (var line in inputRaw)
            {
                for (var i = 0; i < line.Length; i++)
                {
                    gammaArray[i] += int.Parse(line[i].ToString());
                }
            }

            for (var i = 0; i < gammaArray.Length; i++)
            {
                gammaString += gammaArray[i] > inputRaw.Length / 2 ? "1" : "0";
                epsilonString += gammaArray[i] > inputRaw.Length / 2 ? "0" : "1";
            }

            return Convert.ToInt32(gammaString, 2) * Convert.ToInt32(epsilonString, 2); // 198
        }
    }
}
