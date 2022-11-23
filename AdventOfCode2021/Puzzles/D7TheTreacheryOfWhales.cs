using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles
{
    //https://adventofcode.com/2021/day/7
    public class D7TheTreacheryOfWhales
    {
        public static int SolvePart1(string[]? customInput = null)
        {
            var positions = Array.ConvertAll(customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD7.txt").First().Split(','), int.Parse).ToList();
            var fuel = int.MaxValue;

            for (var i = positions.Min(); i <= positions.Max(); i++)
            {
                var count = 0;

                foreach (var crab in positions)
                {
                    count += Math.Abs(crab - i);
                }

                if (count < fuel)
                    fuel = count;
            }

            return fuel;
        }

        public static int SolvePart2(string[]? customInput = null)
        {
            var positions = Array.ConvertAll(customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD7.txt").First().Split(','), int.Parse).ToList();
            var fuel = int.MaxValue;

            for (var i = positions.Min(); i <= positions.Max(); i++)
            {
                var count = 0;

                foreach (var crab in positions)
                {
                    var steps = Math.Abs(crab - i);
                    count += (1 + steps) * steps / 2;
                }

                if (count < fuel)
                    fuel = count;
            }

            return fuel;
        }
    }
}
