using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles
{
    public class D6Lanternfish
    {
        public static long SolvePart1(string[]? customInput = null)
        {
            var fishes = Array.ConvertAll(customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD6.txt").First().Split(','), int.Parse).ToList();
            var days = 80;

            while (days > 0)
            {
                var born = 0;

                for (var i = 0; i < fishes.Count; i++)
                {
                    if (fishes[i] == 0)
                    {
                        born++;
                        fishes[i] = 6;
                        continue;
                    }

                    fishes[i]--;
                }

                for (var i = 0; i < born; i++)
                    fishes.Add(8);

                days--;
            }

            return fishes.Count;
        }

        //https://adventofcode.com/2021/day/6
        public static long SolvePart2(string[]? customInput = null)
        {
            var fishes = Array.ConvertAll(customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD6.txt").First().Split(','), int.Parse).ToList();
            var days = 256;

            long countZero = fishes.Count(s => s == 0); // 0 -> 6 + countEight = countZero
            long countOne = fishes.Count(s => s == 1); // 1 -> 0
            long countTwo = fishes.Count(s => s == 2); // 2 -> 1
            long countThree = fishes.Count(s => s == 3); // 3 -> 2
            long countFour = fishes.Count(s => s == 4); // 4 -> 3
            long countFive = fishes.Count(s => s == 5); // 5 -> 4
            long countSix = fishes.Count(s => s == 6); // 6 -> 5
            long countSeven = fishes.Count(s => s == 7); // 7 -> 6
            long countEight = fishes.Count(s => s == 8); // 8 -> 7

            while (days > 0)
            {
                var newBorn = countZero;

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
