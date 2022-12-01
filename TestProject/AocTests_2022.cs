using AdventOfCode2022.Puzzles;

namespace AocTests;

public class AocTests_2022 : AocTests_Base
{
    [Fact]
    public void D1_CalorieCounting_Part1()
    {
        var input = """
                1000
                2000
                3000

                4000

                5000
                6000

                7000
                8000
                9000

                10000
                """;

        Assert.Equal(24000, D1CalorieCounting.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D1_CalorieCounting_Part2()
    {
        var input = """
                1000
                2000
                3000

                4000

                5000
                6000

                7000
                8000
                9000

                10000
                """;

        Assert.Equal(45000, D1CalorieCounting.SolvePart2(GeneratePuzzleInput(input)));
    }
}
