using AdventOfCode2021.Puzzles;

namespace TestProject;

public class PuzzleTests
{
    private static string[] GeneratePuzzleInput(string input)
    {
        return input.Split(Environment.NewLine);
    }

    [Fact]
    public void D1SonarSweepPart1()
    {
        var input = """
                199
                200
                208
                210
                200
                207
                240
                269
                260
                263
                """;

        Assert.Equal(7, D1SonarSweep.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D1SonarSweepPart2()
    {
        var input = """
                199
                200
                208
                210
                200
                207
                240
                269
                260
                263
                """;

        Assert.Equal(5, D1SonarSweep.SolvePart2(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D2DivePart1()
    {
        var input = """
                forward 5
                down 5
                forward 8
                up 3
                down 8
                forward 2
                """;

        Assert.Equal(150, D2Dive.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D2DivePart2()
    {
        var input = """
                forward 5
                down 5
                forward 8
                up 3
                down 8
                forward 2
                """;

        Assert.Equal(900, D2Dive.SolvePart2(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D3BinaryDiagnosticPart1()
    {
        var input = """
                00100
                11110
                10110
                10111
                10101
                01111
                00111
                11100
                10000
                11001
                00010
                01010
                """;

        Assert.Equal(198, D3BinaryDiagnostic.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D3BinaryDiagnosticPart2()
    {
        var input = """
                00100
                11110
                10110
                10111
                10101
                01111
                00111
                11100
                10000
                11001
                00010
                01010
                """;

        Assert.Equal(230, D3BinaryDiagnostic.SolvePart2(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D4GiantSquidPart1()
    {
        var input = """
                7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

                22 13 17 11  0
                 8  2 23  4 24
                21  9 14 16  7
                 6 10  3 18  5
                 1 12 20 15 19

                 3 15  0  2 22
                 9 18 13 17  5
                19  8  7 25 23
                20 11 10 24  4
                14 21 16 12  6

                14 21 17 24  4
                10 16 15  9 19
                18  8 23 26 20
                22 11 13  6  5
                 2  0 12  3  7
                """;

        Assert.Equal(4512, D4GiantSquid.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D4GiantSquidPart2()
    {
        var input = """
                7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1
                
                22 13 17 11  0
                 8  2 23  4 24
                21  9 14 16  7
                 6 10  3 18  5
                 1 12 20 15 19
                
                 3 15  0  2 22
                 9 18 13 17  5
                19  8  7 25 23
                20 11 10 24  4
                14 21 16 12  6
                
                14 21 17 24  4
                10 16 15  9 19
                18  8 23 26 20
                22 11 13  6  5
                 2  0 12  3  7
                """;

        Assert.Equal(1924, D4GiantSquid.SolvePart2(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D5HydrothermalVenturePart1()
    {
        var input = """
                0,9 -> 5,9
                8,0 -> 0,8
                9,4 -> 3,4
                2,2 -> 2,1
                7,0 -> 7,4
                6,4 -> 2,0
                0,9 -> 2,9
                3,4 -> 1,4
                0,0 -> 8,8
                5,5 -> 8,2
                """;

        Assert.Equal(5, D5HydrothermalVenture.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D5HydrothermalVenturePart2()
    {
        var input = """
                0,9 -> 5,9
                8,0 -> 0,8
                9,4 -> 3,4
                2,2 -> 2,1
                7,0 -> 7,4
                6,4 -> 2,0
                0,9 -> 2,9
                3,4 -> 1,4
                0,0 -> 8,8
                5,5 -> 8,2
                """;

        Assert.Equal(12, D5HydrothermalVenture.SolvePart2(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D6LanternfishPart1()
    {
        var input = """
                3,4,3,1,2
                """;

        Assert.Equal(5934, D6Lanternfish.SolvePart1(input.Split(',')));
    }

    [Fact]
    public void D6LanternfishPart2()
    {
        var input = """
                3,4,3,1,2
                """;

        Assert.Equal(26984457539, D6Lanternfish.SolvePart2(input.Split(',')));
    }

    [Fact]
    public void D7TheTreacheryOfWhalesPart1()
    {
        var input = """
                16,1,2,0,4,2,7,1,2,14
                """;

        Assert.Equal(37, D7TheTreacheryOfWhales.SolvePart1(input.Split(',')));
    }

    [Fact]
    public void D7TheTreacheryOfWhalesPart2()
    {
        var input = """
                16,1,2,0,4,2,7,1,2,14
                """;

        Assert.Equal(168, D7TheTreacheryOfWhales.SolvePart2(input.Split(',')));
    }
}