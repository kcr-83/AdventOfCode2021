namespace AdventOfCode2021;
public class Day02
{
    const string InputPuzzle = @".\Items\Puzzle_day02.txt";
    enum Direction
    {
        forward,
        down,
        up
    }
    record Step
    {
        public Direction Direction;
        public int Value;
    }
    public static int FirstChallenge()
    {
        var steps = File.ReadAllLines(InputPuzzle).Select(s => new Step() { Direction = Enum.Parse<Direction>(s.Split(' ')[0], true), Value = int.Parse(s.Split(' ')[1]) });
        var horizontalPosition = 0;
        var depthPosition = 0;
        var stepsGroup = steps.GroupBy(d => d.Direction, (direction, step) => new
        {
            Direction = direction,
            Value = step.Sum(s => s.Value)
        });
        horizontalPosition = stepsGroup.First(s => s.Direction == Direction.forward).Value;
        depthPosition = stepsGroup.First(s => s.Direction == Direction.down).Value - stepsGroup.First(s => s.Direction == Direction.up).Value;
        return horizontalPosition * depthPosition;
    }
    public static int SecondChallenge()
    {
        var steps = File.ReadAllLines(InputPuzzle).Select(s => new Step() { Direction = Enum.Parse<Direction>(s.Split(' ')[0], true), Value = int.Parse(s.Split(' ')[1]) });
        var horizontalPosition = 0;
        var depthPosition = 0;
        var aim = 0;
        var location = (horizontalPosition,depthPosition,aim);
        foreach (var step in steps)
        {
            location = IncresDirection(step,location);
        }
        return location.horizontalPosition * location.depthPosition;
    }
    static (int, int, int) IncresDirection(Step step, (int horizontal, int depth, int aim) location) => step.Direction switch
    {
        Direction.forward => (location.horizontal + step.Value,location.depth + (location.aim  * step.Value),location.aim),
        Direction.up => (location.horizontal,location.depth,location.aim - step.Value),
        Direction.down => (location.horizontal,location.depth,location.aim + step.Value),
        _ => (location.horizontal,location.depth,location.aim)
    };


}