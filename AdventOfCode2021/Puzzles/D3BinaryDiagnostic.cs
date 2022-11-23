using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles
{
    //https://adventofcode.com/2021/day/3
    public class D3BinaryDiagnostic
    {
        public static int SolvePart1(string[]? customInput = null)
        {
            var gammaString = string.Empty;
            var epsilonString = string.Empty;
            var inputRaw = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD3.txt");

            var gammaArray = new int[inputRaw.First().Length];
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

        public static int SolvePart2(string[]? customInput = null)
        {
            var inputRaw = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD3.txt");
            var oxygenGeneratorRating = inputRaw.ToList();
            var CO2Rating = inputRaw.ToList();
            var tempOxygenGeneratorRating = new List<string>();
            var tempCO2Rating = new List<string>();

            for (int i = 0; i < inputRaw.First().Length; i++)
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
