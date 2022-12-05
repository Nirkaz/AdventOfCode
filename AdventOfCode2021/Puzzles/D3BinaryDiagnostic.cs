namespace AdventOfCode2021.Puzzles;

//https://adventofcode.com/2021/day/3
public static class D3BinaryDiagnostic
{
    public static int SolvePart1(string[]? customInput = null)
    {
        var gammaString = string.Empty;
        var epsilonString = string.Empty;
        var inputRaw = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD3.txt");

        var gammaArray = new int[inputRaw.First().Length];
        foreach (var line in inputRaw)
            for (var i = 0; i < line.Length; i++)
                gammaArray[i] += int.Parse(line[i].ToString());

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
        var co2Rating = inputRaw.ToList();
        var tempOxygenGeneratorRating = new List<string>();
        var tempCo2Rating = new List<string>();

        for (var i = 0; i < inputRaw.First().Length; i++)
        {
            if (oxygenGeneratorRating.Count != 1)
            {
                var countOxygen = 0;
                foreach (var line in oxygenGeneratorRating)
                    countOxygen += int.Parse(line[i].ToString());

                var most = (countOxygen > oxygenGeneratorRating.Count / 2) || (countOxygen == (double)oxygenGeneratorRating.Count / 2) ? "1" : "0";

                tempOxygenGeneratorRating.AddRange(oxygenGeneratorRating.Where(w => w[i].ToString() == most));

                oxygenGeneratorRating = new List<string>();
                oxygenGeneratorRating.AddRange(tempOxygenGeneratorRating);
                tempOxygenGeneratorRating.Clear();
            }

            if (co2Rating.Count != 1)
            {
                var countCo2 = 0;
                foreach (var line in co2Rating)
                    countCo2 += int.Parse(line[i].ToString());

                var least = countCo2 <= co2Rating.Count / 2 && countCo2 != (double)co2Rating.Count / 2 ? "1" : "0";

                tempCo2Rating.AddRange(co2Rating.Where(w => w[i].ToString() == least));

                co2Rating = new List<string>();
                co2Rating.AddRange(tempCo2Rating);
                tempCo2Rating.Clear();
            }
        }

        return Convert.ToInt32(oxygenGeneratorRating.FirstOrDefault(), 2) *
               Convert.ToInt32(co2Rating.FirstOrDefault(), 2);
    }
}
