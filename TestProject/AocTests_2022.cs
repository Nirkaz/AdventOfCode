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

    [Fact]
    public void D2_RockPaperScissors_Part1()
    {
        var input = """
                A Y
                B X
                C Z
                """;

        Assert.Equal(15, D2RockPaperScissors.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D2_RockPaperScissors_Part2()
    {
        var input = """
                A Y
                B X
                C Z
                """;

        Assert.Equal(12, D2RockPaperScissors.SolvePart2(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D3_RucksackReorganization_Part1()
    {
        var input = """
                vJrwpWtwJgWrhcsFMMfFFhFp
                jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                PmmdzqPrVvPwwTWBwg
                wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                ttgJtRGJQctTZtZT
                CrZsJsPPZsGzwwsLwLmpwMDw
                """;

        Assert.Equal(157, D3RucksackReorganization.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D3_RucksackReorganization_Part2()
    {
        var input = """
                vJrwpWtwJgWrhcsFMMfFFhFp
                jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                PmmdzqPrVvPwwTWBwg
                wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                ttgJtRGJQctTZtZT
                CrZsJsPPZsGzwwsLwLmpwMDw
                """;

        Assert.Equal(70, D3RucksackReorganization.SolvePart2(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D4_CampCleanup_Part1()
    {
        var input = """
                2-4,6-8
                2-3,4-5
                5-7,7-9
                2-8,3-7
                6-6,4-6
                2-6,4-8
                """;

        Assert.Equal(2, D4CampCleanup.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D4_CampCleanup_Part2()
    {
        var input = """
                2-4,6-8
                2-3,4-5
                5-7,7-9
                2-8,3-7
                6-6,4-6
                2-6,4-8
                """;

        Assert.Equal(4, D4CampCleanup.SolvePart2(GeneratePuzzleInput(input)));
    }
}
