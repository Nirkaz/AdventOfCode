using AdventOfCode2022.Puzzles;

namespace AocTests;

public class AocTests_2022 : AocTests_Base
{
    private const string inputD1 = """
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

    private const string inputD2 = """
        A Y
        B X
        C Z
        """;

    private const string inputD3 = """
        vJrwpWtwJgWrhcsFMMfFFhFp
        jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
        PmmdzqPrVvPwwTWBwg
        wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
        ttgJtRGJQctTZtZT
        CrZsJsPPZsGzwwsLwLmpwMDw
        """;

    private const string inputD4 = """
        2-4,6-8
        2-3,4-5
        5-7,7-9
        2-8,3-7
        6-6,4-6
        2-6,4-8
        """;

    private const string inputD5 = """
            [D]    
        [N] [C]    
        [Z] [M] [P]
            1   2   3 

        move 1 from 2 to 1
        move 3 from 1 to 3
        move 2 from 2 to 1
        move 1 from 1 to 2
        """;

    private const string inputD7 = """
        $ cd /
        $ ls
        dir a
        14848514 b.txt
        8504156 c.dat
        dir d
        $ cd a
        $ ls
        dir e
        29116 f
        2557 g
        62596 h.lst
        $ cd e
        $ ls
        584 i
        $ cd ..
        $ cd ..
        $ cd d
        $ ls
        4060174 j
        8033020 d.log
        5626152 d.ext
        7214296 k
        """;

    private const string inputD8 = """
        30373
        25512
        65332
        33549
        35390
        """;

    [Fact]
    public void D1_CalorieCounting_Part1() => Assert.Equal(24000, D1CalorieCounting.SolvePart1(GeneratePuzzleInput(inputD1)));

    [Fact]
    public void D1_CalorieCounting_Part2() => Assert.Equal(45000, D1CalorieCounting.SolvePart2(GeneratePuzzleInput(inputD1)));

    [Fact]
    public void D2_RockPaperScissors_Part1() => Assert.Equal(15, D2RockPaperScissors.SolvePart1(GeneratePuzzleInput(inputD2)));

    [Fact]
    public void D2_RockPaperScissors_Part2() => Assert.Equal(12, D2RockPaperScissors.SolvePart2(GeneratePuzzleInput(inputD2)));

    [Fact]
    public void D3_RucksackReorganization_Part1() => Assert.Equal(157, D3RucksackReorganization.SolvePart1(GeneratePuzzleInput(inputD3)));

    [Fact]
    public void D3_RucksackReorganization_Part2() => Assert.Equal(70, D3RucksackReorganization.SolvePart2(GeneratePuzzleInput(inputD3)));

    [Fact]
    public void D4_CampCleanup_Part1() => Assert.Equal(2, D4CampCleanup.SolvePart1(GeneratePuzzleInput(inputD4)));

    [Fact]
    public void D4_CampCleanup_Part2() => Assert.Equal(4, D4CampCleanup.SolvePart2(GeneratePuzzleInput(inputD4)));

    [Fact]
    public void D5_SupplyStacks_Part1() => Assert.Equal("CMZ", D5SupplyStacks.SolvePart1(GeneratePuzzleInput(inputD5)));

    [Fact]
    public void D5_SupplyStacks_Part2() => Assert.Equal("MCD", D5SupplyStacks.SolvePart2(GeneratePuzzleInput(inputD5)));

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void D6_TuningTrouble_Part1(string input, int expectedOutput) => Assert.Equal(expectedOutput, D6TuningTrouble.SolvePart1(GeneratePuzzleInput(input)));

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void D6_TuningTrouble_Part2(string input, int expectedOutput) => Assert.Equal(expectedOutput, D6TuningTrouble.SolvePart2(GeneratePuzzleInput(input)));

    [Fact]
    public void D7_NoSpaceLeftOnDevice_Part1() => Assert.Equal(95437, D7NoSpaceLeftOnDevice.SolvePart1(GeneratePuzzleInput(inputD7)));

    [Fact]
    public void D7_NoSpaceLeftOnDevice_Part2() => Assert.Equal(24933642, D7NoSpaceLeftOnDevice.SolvePart2(GeneratePuzzleInput(inputD7)));

    [Fact]
    public void D8_TreetopTreeHouse_Part1() => Assert.Equal(21, D8TreetopTreeHouse.SolvePart1(GeneratePuzzleInput(inputD8)));

    [Fact]
    public void D8_TreetopTreeHouse_Part2() => Assert.Equal(8, D8TreetopTreeHouse.SolvePart2(GeneratePuzzleInput(inputD8)));
}
