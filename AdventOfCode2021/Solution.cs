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
            /*Count the number of times a depth measurement increases from the previous measurement. 
             * (There is no measurement before the first measurement.)*/
            var count = 0;
            var input = GetPuzzleInput("PuzzleInputD1.txt");
            var prevValue = int.Parse(input[0]);

            for (var i = 1; i < input.Length; i++)
            {
                if (int.Parse(input[i]) > prevValue) count++;
                prevValue = int.Parse(input[i]);
            }

            return count;
        }
    }
}
