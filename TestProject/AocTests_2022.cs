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

    private const string inputD9 = """
        R 4
        U 4
        L 3
        D 1
        R 4
        D 1
        L 5
        R 2
        """;

    private const string inputD9Larger = """
        R 5
        U 8
        L 8
        D 3
        R 17
        D 10
        L 25
        U 20
        """;

    private const string inputD10 = """
        addx 15
        addx -11
        addx 6
        addx -3
        addx 5
        addx -1
        addx -8
        addx 13
        addx 4
        noop
        addx -1
        addx 5
        addx -1
        addx 5
        addx -1
        addx 5
        addx -1
        addx 5
        addx -1
        addx -35
        addx 1
        addx 24
        addx -19
        addx 1
        addx 16
        addx -11
        noop
        noop
        addx 21
        addx -15
        noop
        noop
        addx -3
        addx 9
        addx 1
        addx -3
        addx 8
        addx 1
        addx 5
        noop
        noop
        noop
        noop
        noop
        addx -36
        noop
        addx 1
        addx 7
        noop
        noop
        noop
        addx 2
        addx 6
        noop
        noop
        noop
        noop
        noop
        addx 1
        noop
        noop
        addx 7
        addx 1
        noop
        addx -13
        addx 13
        addx 7
        noop
        addx 1
        addx -33
        noop
        noop
        noop
        addx 2
        noop
        noop
        noop
        addx 8
        noop
        addx -1
        addx 2
        addx 1
        noop
        addx 17
        addx -9
        addx 1
        addx 1
        addx -3
        addx 11
        noop
        noop
        addx 1
        noop
        addx 1
        noop
        noop
        addx -13
        addx -19
        addx 1
        addx 3
        addx 26
        addx -30
        addx 12
        addx -1
        addx 3
        addx 1
        noop
        noop
        noop
        addx -9
        addx 18
        addx 1
        addx 2
        noop
        noop
        addx 9
        noop
        noop
        noop
        addx -1
        addx 2
        addx -37
        addx 1
        addx 3
        noop
        addx 15
        addx -21
        addx 22
        addx -6
        addx 1
        noop
        addx 2
        addx 1
        noop
        addx -10
        noop
        noop
        addx 20
        addx 1
        addx 2
        addx 2
        addx -6
        addx -11
        noop
        noop
        noop
        """;

    private const string expectedOutputD10 = """
        ##..##..##..##..##..##..##..##..##..##..
        ###...###...###...###...###...###...###.
        ####....####....####....####....####....
        #####.....#####.....#####.....#####.....
        ######......######......######......####
        #######.......#######.......#######.....
        """;

    private const string inputD11 = """
        Monkey 0:
          Starting items: 79, 98
          Operation: new = old * 19
          Test: divisible by 23
            If true: throw to monkey 2
            If false: throw to monkey 3

        Monkey 1:
          Starting items: 54, 65, 75, 74
          Operation: new = old + 6
          Test: divisible by 19
            If true: throw to monkey 2
            If false: throw to monkey 0

        Monkey 2:
          Starting items: 79, 60, 97
          Operation: new = old * old
          Test: divisible by 13
            If true: throw to monkey 1
            If false: throw to monkey 3

        Monkey 3:
          Starting items: 74
          Operation: new = old + 3
          Test: divisible by 17
            If true: throw to monkey 0
            If false: throw to monkey 1
        """;

    [Fact]
    public void D1_CalorieCounting_Part1() 
        => Assert.Equal(24000, D1CalorieCounting.SolvePart1(GeneratePuzzleInput(inputD1)));

    [Fact]
    public void D1_CalorieCounting_Part2() 
        => Assert.Equal(45000, D1CalorieCounting.SolvePart2(GeneratePuzzleInput(inputD1)));

    [Fact]
    public void D2_RockPaperScissors_Part1() 
        => Assert.Equal(15, D2RockPaperScissors.SolvePart1(GeneratePuzzleInput(inputD2)));

    [Fact]
    public void D2_RockPaperScissors_Part2() 
        => Assert.Equal(12, D2RockPaperScissors.SolvePart2(GeneratePuzzleInput(inputD2)));

    [Fact]
    public void D3_RucksackReorganization_Part1() 
        => Assert.Equal(157, D3RucksackReorganization.SolvePart1(GeneratePuzzleInput(inputD3)));

    [Fact]
    public void D3_RucksackReorganization_Part2() 
        => Assert.Equal(70, D3RucksackReorganization.SolvePart2(GeneratePuzzleInput(inputD3)));

    [Fact]
    public void D4_CampCleanup_Part1() 
        => Assert.Equal(2, D4CampCleanup.SolvePart1(GeneratePuzzleInput(inputD4)));

    [Fact]
    public void D4_CampCleanup_Part2() 
        => Assert.Equal(4, D4CampCleanup.SolvePart2(GeneratePuzzleInput(inputD4)));

    [Fact]
    public void D5_SupplyStacks_Part1() 
        => Assert.Equal("CMZ", D5SupplyStacks.SolvePart1(GeneratePuzzleInput(inputD5)));

    [Fact]
    public void D5_SupplyStacks_Part2() 
        => Assert.Equal("MCD", D5SupplyStacks.SolvePart2(GeneratePuzzleInput(inputD5)));

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void D6_TuningTrouble_Part1(string input, int expectedOutput) 
        => Assert.Equal(expectedOutput, D6TuningTrouble.SolvePart1(GeneratePuzzleInput(input)));

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void D6_TuningTrouble_Part2(string input, int expectedOutput) 
        => Assert.Equal(expectedOutput, D6TuningTrouble.SolvePart2(GeneratePuzzleInput(input)));

    [Fact]
    public void D7_NoSpaceLeftOnDevice_Part1() 
        => Assert.Equal(95437, D7NoSpaceLeftOnDevice.SolvePart1(GeneratePuzzleInput(inputD7)));

    [Fact]
    public void D7_NoSpaceLeftOnDevice_Part2() 
        => Assert.Equal(24933642, D7NoSpaceLeftOnDevice.SolvePart2(GeneratePuzzleInput(inputD7)));

    [Fact]
    public void D8_TreetopTreeHouse_Part1() 
        => Assert.Equal(21, D8TreetopTreeHouse.SolvePart1(GeneratePuzzleInput(inputD8)));

    [Fact]
    public void D8_TreetopTreeHouse_Part2() 
        => Assert.Equal(8, D8TreetopTreeHouse.SolvePart2(GeneratePuzzleInput(inputD8)));

    [Fact]
    public void D9_RopeBridge_Part1() 
        => Assert.Equal(13, D9RopeBridge.SolvePart1(GeneratePuzzleInput(inputD9)));

    [Theory]
    [InlineData(inputD9, 1)]
    [InlineData(inputD9Larger, 36)]
    public void D9_RopeBridge_Part2(string input, int expectedOutput) 
        => Assert.Equal(expectedOutput, D9RopeBridge.SolvePart2(GeneratePuzzleInput(input)));

    [Fact]
    public void D10_CathodeRayTube_Part1()
        => Assert.Equal(13140, D10CathodeRayTube.SolvePart1(GeneratePuzzleInput(inputD10)));

    [Fact]
    public void D10_CathodeRayTube_Part2()
        => Assert.Equal(expectedOutputD10, D10CathodeRayTube.SolvePart2(GeneratePuzzleInput(inputD10)));

    [Fact]
    public void D11_MonkeyInTheMiddle_Part1()
        => Assert.Equal(10605, D11MonkeyInTheMiddle.SolvePart1(GeneratePuzzleInput(inputD11)));

    [Fact]
    public void D11_MonkeyInTheMiddle_Part2()
        => Assert.Equal(2713310158, D11MonkeyInTheMiddle.SolvePart2(GeneratePuzzleInput(inputD11)));
}
