namespace AdventOfCode2021;
public class Day02
{
    const string InputPuzzle = @".\Puzzle_day02.txt";
    enum Direction
    {
        forward,
        down,
        up
    }
    record Step
    {
        public Direction Direction { get; set; }
        public int Value { get; set; }
    }
    public static int FirstChallenge()
    {
        var steps = File.ReadAllLines(InputPuzzle).Select(s => s.Split(' '));
        return 0;
    }
    
}   