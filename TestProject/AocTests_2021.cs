using AdventOfCode2021.Puzzles;

namespace AocTests;

public class AocTests_2021 : AocTests_Base
{
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

    [Fact]
    public void D8SevenSegmentSearchPart1()
    {
        var input = """
                be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
                edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
                fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
                fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
                aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
                fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
                dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
                bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
                egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
                gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce
                """;

        Assert.Equal(26, D8SevenSegmentSearch.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D8SevenSegmentSearchPart2()
    {
        var input = """
                be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
                edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
                fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
                fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
                aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
                fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
                dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
                bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
                egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
                gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce
                """;

        Assert.Equal(61229, D8SevenSegmentSearch.SolvePart2(GeneratePuzzleInput(input)));
    }

    [Theory]
    [InlineData("bcdf")] [InlineData("bdfc")] [InlineData("bfcd")]
    [InlineData("cdfb")] [InlineData("cfbd")] [InlineData("cbdf")]
    [InlineData("dfbc")] [InlineData("dbcf")] [InlineData("dcfb")]
    [InlineData("fbcd")] [InlineData("fcdb")] [InlineData("fdbc")]
    public void D8SevenSegmentSearch_TestFour_True(string? input)
    {
        Assert.True(D8SevenSegmentSearch.TestFour(input));
    }

    [Theory]
    [InlineData(null)] [InlineData("")]
    [InlineData("c")] [InlineData("f")]
    [InlineData("cc")] [InlineData("ff")]
    [InlineData("aa")] [InlineData("  ")]
    [InlineData("fcc")] [InlineData("cfc")] [InlineData("ccf")]
    [InlineData("bcdff")] [InlineData("bbcdf")]
    [InlineData("abc")] [InlineData("acf")]
    [InlineData("abcdefg")] [InlineData("\n")]
    public void D8SevenSegmentSearch_TestFour_False(string? input)
    {
        Assert.False(D8SevenSegmentSearch.TestFour(input));
    }

    [Theory]
    [InlineData("cf")] [InlineData("fc")]
    public void D8SevenSegmentSearch_TestOne_True(string? input)
    {
        Assert.True(D8SevenSegmentSearch.TestOne(input));
    }

    [Theory]
    [InlineData(null)] [InlineData("")]
    [InlineData("c")] [InlineData("f")]
    [InlineData("fcc")] [InlineData("cfc")] [InlineData("ccf")]
    [InlineData("cfcf")] [InlineData("fcfc")]
    [InlineData("abc")] [InlineData("acf")]
    [InlineData("abcdefg")] [InlineData("-123")]
    [InlineData("\n")]
    public void D8SevenSegmentSearch_TestOne_False(string? input)
    {
        Assert.False(D8SevenSegmentSearch.TestOne(input));
    }

    [Fact]
    public void D9SmokeBasinPart1()
    {
        var input = """
            2199943210
            3987894921
            9856789892
            8767896789
            9899965678
            """;

        Assert.Equal(15, D9SmokeBasin.SolvePart1(GeneratePuzzleInput(input)));
    }

    [Fact]
    public void D9SmokeBasinPart2()
    {
        var input = """
            2199943210
            3987894921
            9856789892
            8767896789
            9899965678
            """;

        Assert.Equal(1134, D9SmokeBasin.SolvePart2(GeneratePuzzleInput(input)));
    }
}