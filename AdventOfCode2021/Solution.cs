﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        //https://adventofcode.com/2021/day/4
        public static int D4GiantSquid()
        {
            var inputRaw = GetPuzzleInput("PuzzleInputD4.txt");
            var drawNumbers = Array.ConvertAll(inputRaw[0].Split(','), r => int.Parse(r));
            var boards = new List<int[,]>();

            for (var i = 2; i < inputRaw.Length; i += 6)
            {
                var board = new int[6, 6];
                var sum = 0;

                for (var j = 0; j < 5; j++)
                {
                    var line = Array.ConvertAll(inputRaw[i+j].Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray(), s => int.Parse(s));

                    for (var k = 0; k < 5; k++)
                    {
                        board[j + 1, k + 1] = line[k];
                        sum -= line[k];
                    }
                }

                board[0, 0] = sum;
                boards.Add(board);
            }

            var winnerIndex = -1;
            var lastDraw = -1;
            var winnerIndexes = new List<int>();

            foreach (var draw in drawNumbers)
            {
                if (winnerIndexes.Count == boards.Count) break;
                lastDraw = draw;

                foreach (var board in boards)
                {
                    if (winnerIndexes.Contains(boards.IndexOf(board))) continue;

                    var column = -1;
                    var row = -1;

                    for (var i = 1; i < 6; i++)
                    {
                        for (var j = 1; j < 6; j++)
                        {
                            if (board[i, j] == lastDraw)
                            {
                                column = i;
                                row = j;
                                board[0, 0] += lastDraw;
                            }
                        }
                    }

                    if (column != -1 && row != -1)
                    {
                        board[0, column]++;
                        board[row, 0]++;
                        if (board[0, column] == 5 || board[row, 0] == 5)
                        {
                            winnerIndex = boards.IndexOf(board);
                            winnerIndexes.Add(winnerIndex);
                        }
                    }
                }
            }

            return lastDraw * -boards[winnerIndex][0,0];
        }

        //https://adventofcode.com/2021/day/5
        public static int D5HydrothermalVenture()
        {
            var inputRaw = GetPuzzleInput("PuzzleInputD5.txt");
            var overlapingPoints = 0; // >= 2
            var maxX = 0;
            var maxY = 0;
            var fromList = new List<Tuple<int, int>>();
            var toList = new List<Tuple<int, int>>();

            foreach (var line in inputRaw)
            {
                var parse = line.Split();
                var fromX = int.Parse(parse[0].Split(',')[0]);
                var fromY = int.Parse(parse[0].Split(',')[1]);
                var from = new Tuple<int, int>(fromX, fromY);
                fromList.Add(from);

                var toX = int.Parse(parse[2].Split(',')[0]);
                var toY = int.Parse(parse[2].Split(',')[1]);
                var to = new Tuple<int, int>(toX, toY);
                toList.Add(to);

                if (fromX > maxX) maxX = fromX;
                if (fromY > maxY) maxY = fromY;
                if (toX > maxX) maxX = toX;
                if (toY > maxY) maxY = toY;
            }

            var grid = new int[maxX + 1, maxY + 1];

            for (var i = 0; i < inputRaw.Length; i++)
            {
                if (fromList[i].Item1 == toList[i].Item1) // Vertical
                {
                    if (fromList[i].Item2 < toList[i].Item2)
                    {
                        for (var j = fromList[i].Item2; j <= toList[i].Item2; j++)
                        {
                            grid[fromList[i].Item1, j]++;
                        }
                    }
                    else
                    {
                        for (var j = fromList[i].Item2; j >= toList[i].Item2; j--)
                        {
                            grid[fromList[i].Item1, j]++;
                        }
                    }
                    continue;
                }

                if (fromList[i].Item2 == toList[i].Item2) // Horizontal
                {
                    if (fromList[i].Item1 < toList[i].Item1)
                    {
                        for (var j = fromList[i].Item1; j <= toList[i].Item1; j++)
                        {
                            grid[j, fromList[i].Item2]++;
                        }
                    }
                    else
                    {
                        for (var j = fromList[i].Item1; j >= toList[i].Item1; j--)
                        {
                            grid[j, fromList[i].Item2]++;
                        }
                    }
                    continue;
                }

                if (Math.Abs(fromList[i].Item1 - toList[i].Item1) == Math.Abs(fromList[i].Item2 - toList[i].Item2)) // Diagonal
                {
                    if (fromList[i].Item1 < toList[i].Item1)
                    {
                        if (fromList[i].Item2 < toList[i].Item2)
                        {
                            for (int x = fromList[i].Item1, y = fromList[i].Item2; x <= toList[i].Item1 && y <= toList[i].Item2; x++, y++)
                            {
                                grid[x, y]++;
                            }
                        }
                        else
                        {
                            for (int x = fromList[i].Item1, y = fromList[i].Item2; x <= toList[i].Item1 && y >= toList[i].Item2; x++, y--)
                            {
                                grid[x, y]++;
                            }
                        }
                    }
                    else
                    {
                        if (fromList[i].Item2 < toList[i].Item2)
                        {
                            for (int x = fromList[i].Item1, y = fromList[i].Item2; x >= toList[i].Item1 && y <= toList[i].Item2; x--, y++)
                            {
                                grid[x, y]++;
                            }
                        }
                        else
                        {
                            for (int x = fromList[i].Item1, y = fromList[i].Item2; x >= toList[i].Item1 && y >= toList[i].Item2; x--, y--)
                            {
                                grid[x, y]++;
                            }
                        }
                    }
                }
            }

            for (var i = 0; i < maxX + 1; i++)
            {
                for (var j = 0; j < maxY + 1; j++)
                {
                    if (grid[i, j] >= 2) overlapingPoints++;
                }
            }

            return overlapingPoints;
        }

        //https://adventofcode.com/2021/day/6
        public static long D6Lanternfish()
        {
            var fishes = Array.ConvertAll(GetPuzzleInput("PuzzleInputD6.txt").FirstOrDefault().Split(','), s => int.Parse(s)).ToList();
            var days = 256;

            long countZero   =   fishes.Where(s => s == 0).Count(); // 0 -> 6 + countEight = countZero
            long countOne    =   fishes.Where(s => s == 1).Count(); // 1 -> 0
            long countTwo    =   fishes.Where(s => s == 2).Count(); // 2 -> 1
            long countThree  =   fishes.Where(s => s == 3).Count(); // 3 -> 2
            long countFour   =   fishes.Where(s => s == 4).Count(); // 4 -> 3
            long countFive   =   fishes.Where(s => s == 5).Count(); // 5 -> 4
            long countSix    =   fishes.Where(s => s == 6).Count(); // 6 -> 5
            long countSeven  =   fishes.Where(s => s == 7).Count(); // 7 -> 6
            long countEight  =   fishes.Where(s => s == 8).Count(); // 8 -> 7

            while (days > 0)
            {
                long newBorn = countZero;

                countZero = countOne;
                countOne = countTwo;
                countTwo = countThree;
                countThree = countFour;
                countFour = countFive;
                countFive = countSix;
                countSix = countSeven + newBorn;
                countSeven = countEight;
                countEight = newBorn;

                days--;
            }

            return countZero + countOne + countTwo + countThree + countFour + countFive + countSix + countSeven + countEight;
        }
    }
}
