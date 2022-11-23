using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles
{
    //https://adventofcode.com/2021/day/4
    public class D4GiantSquid
    {
        public static int SolvePart1(string[]? customInput = null)
        {
            var inputRaw = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD4.txt");
            var drawNumbers = Array.ConvertAll(inputRaw[0].Split(','), int.Parse);
            var boards = new List<int[,]>();

            for (var i = 2; i < inputRaw.Length; i += 6)
            {
                var board = new int[6, 6];
                var sum = 0;

                for (var j = 0; j < 5; j++)
                {
                    var line = Array.ConvertAll(inputRaw[i + j].Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray(), int.Parse);

                    for (var k = 0; k < 5; k++)
                    {
                        board[j + 1, k + 1] = line[k];
                        sum -= line[k];
                    }
                }

                board[0, 0] = sum;
                boards.Add(board);
            }

            var winner = false;
            var winnerIndex = -1;
            var lastDraw = -1;

            foreach (var draw in drawNumbers)
            {
                if (winner) break;
                lastDraw = draw;

                foreach (var board in boards)
                {
                    if (winner) break;

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
                            winner = true;
                            winnerIndex = boards.IndexOf(board);
                        }
                    }
                }
            }

            return lastDraw * -boards[winnerIndex][0, 0]; // 87456
        }

        public static int SolvePart2(string[]? customInput = null)
        {
            var inputRaw = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD4.txt");
            var drawNumbers = Array.ConvertAll(inputRaw[0].Split(','), int.Parse);
            var boards = new List<int[,]>();

            for (var i = 2; i < inputRaw.Length; i += 6)
            {
                var board = new int[6, 6];
                var sum = 0;

                for (var j = 0; j < 5; j++)
                {
                    var line = Array.ConvertAll(inputRaw[i + j].Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray(), int.Parse);

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

            return lastDraw * -boards[winnerIndex][0, 0];
        }
    }
}
