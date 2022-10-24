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
            var inputRaw = GetPuzzleInput("PuzzleInputD3.txt");
            var oxygenGeneratorRating = inputRaw.ToList();
            var CO2Rating = inputRaw.ToList();
            var tempOxygenGeneratorRating = new List<string>();
            var tempCO2Rating = new List<string>();

            for (int i = 0; i < inputRaw.FirstOrDefault().Length; i++)
            {
                if (oxygenGeneratorRating.Count != 1)
                {
                    var countOxygen = 0;
                    foreach (var line in oxygenGeneratorRating)
                        countOxygen += int.Parse(line[i].ToString());

                    var most = (countOxygen > oxygenGeneratorRating.Count / 2) || (countOxygen == (double)oxygenGeneratorRating.Count / 2) ? "1" : "0";

                    foreach (var line in oxygenGeneratorRating.Where(w => w[i].ToString() == most))
                        tempOxygenGeneratorRating.Add(line);

                    oxygenGeneratorRating = new List<string>();
                    oxygenGeneratorRating.AddRange(tempOxygenGeneratorRating);
                    tempOxygenGeneratorRating.Clear();
                }

                if (CO2Rating.Count != 1)
                {
                    var countCO2 = 0;
                    foreach (var line in CO2Rating)
                        countCO2 += int.Parse(line[i].ToString());

                    var least = (countCO2 <= CO2Rating.Count / 2) && (countCO2 != (double)CO2Rating.Count / 2) ? "1" : "0";

                    foreach (var line in CO2Rating.Where(w => w[i].ToString() == least))
                        tempCO2Rating.Add(line);

                    CO2Rating = new List<string>();
                    CO2Rating.AddRange(tempCO2Rating);
                    tempCO2Rating.Clear();
                }
            }

            return Convert.ToInt32(oxygenGeneratorRating.FirstOrDefault(), 2) * Convert.ToInt32(CO2Rating.FirstOrDefault(), 2);
        }
    }
}
