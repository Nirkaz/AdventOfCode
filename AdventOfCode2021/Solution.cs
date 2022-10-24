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
    }
}
