using AdventOfCode2022.Puzzles;
using AocTests;

public class AocTests_2022_Control : AocTests_Base
{
    // RBPARAGF
    private const string expectedOutputD10 = """
        ###..###..###...##..###...##...##..####.
        #..#.#..#.#..#.#..#.#..#.#..#.#..#.#....
        #..#.###..#..#.#..#.#..#.#..#.#....###..
        ###..#..#.###..####.###..####.#.##.#....
        #.#..#..#.#....#..#.#.#..#..#.#..#.#....
        #..#.###..#....#..#.#..#.#..#..###.#....
        """;

    [Fact]
    public void D1_CalorieCounting_Part1() => Assert.Equal(69501, D1CalorieCounting.SolvePart1());

    [Fact]
    public void D1_CalorieCounting_Part2() => Assert.Equal(202346, D1CalorieCounting.SolvePart2());

    [Fact]
    public void D2_RockPaperScissors_Part1() => Assert.Equal(10718, D2RockPaperScissors.SolvePart1());

    [Fact]
    public void D2_RockPaperScissors_Part2() => Assert.Equal(14652, D2RockPaperScissors.SolvePart2());

    [Fact]
    public void D3_RucksackReorganization_Part1() => Assert.Equal(7553, D3RucksackReorganization.SolvePart1());

    [Fact]
    public void D3_RucksackReorganization_Part2() => Assert.Equal(2758, D3RucksackReorganization.SolvePart2());

    [Fact]
    public void D4_CampCleanup_Part1() => Assert.Equal(528, D4CampCleanup.SolvePart1());

    [Fact]
    public void D4_CampCleanup_Part2() => Assert.Equal(881, D4CampCleanup.SolvePart2());

    [Fact]
    public void D5_SupplyStacks_Part1() => Assert.Equal("WCZTHTMPS", D5SupplyStacks.SolvePart1());

    [Fact]
    public void D5_SupplyStacks_Part2() => Assert.Equal("BLSGJSDTS", D5SupplyStacks.SolvePart2());

    [Fact]
    public void D6_TuningTrouble_Part1() => Assert.Equal(1647, D6TuningTrouble.SolvePart1());

    [Fact]
    public void D6_TuningTrouble_Part2() => Assert.Equal(2447, D6TuningTrouble.SolvePart2());

    [Fact]
    public void D7_NoSpaceLeftOnDevice_Part1() => Assert.Equal(1350966, D7NoSpaceLeftOnDevice.SolvePart1());

    [Fact]
    public void D7_NoSpaceLeftOnDevice_Part2() => Assert.Equal(6296435, D7NoSpaceLeftOnDevice.SolvePart2());

    [Fact]
    public void D8_TreetopTreeHouse_Part1() => Assert.Equal(1713, D8TreetopTreeHouse.SolvePart1());

    [Fact]
    public void D8_TreetopTreeHouse_Part2() => Assert.Equal(268464, D8TreetopTreeHouse.SolvePart2());

    [Fact]
    public void D9_RopeBridge_Part1() => Assert.Equal(6357, D9RopeBridge.SolvePart1());

    [Fact]
    public void D9_RopeBridge_Part2() => Assert.Equal(2627, D9RopeBridge.SolvePart2());

    [Fact]
    public void D10_CathodeRayTube_Part1() => Assert.Equal(12740, D10CathodeRayTube.SolvePart1());

    [Fact]
    public void D10_CathodeRayTube_Part2() => Assert.Equal(expectedOutputD10, D10CathodeRayTube.SolvePart2());
}
