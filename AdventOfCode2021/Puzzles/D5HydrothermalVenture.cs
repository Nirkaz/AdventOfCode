using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles
{
    //https://adventofcode.com/2021/day/5
    public class D5HydrothermalVenture
    {
        public static int SolvePart1(string[]? customInput = null)
        {
            var inputRaw = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD5.txt");
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
                if (fromList[i].Item1 == toList[i].Item1) // vertical = 2
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

                if (fromList[i].Item2 == toList[i].Item2) // horizontal = 4
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
            }

            for (var i = 0; i < maxX + 1; i++)
            {
                for (var j = 0; j < maxY + 1; j++)
                {
                    if (grid[i, j] >= 2) overlapingPoints++;
                }
            }

            return overlapingPoints; // 5, 12
        }

        public static int SolvePart2(string[]? customInput = null)
        {
            var inputRaw = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD5.txt");
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
    }
}
