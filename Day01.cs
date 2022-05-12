namespace AdventOfCode2021;
public static class Day01
{
    const string InputFilePath = @".\Items\Day01_v1.txt";
    public static int SecondChallenge()
    {
        var measurements = File.ReadAllLines(InputFilePath).Select(int.Parse).ToArray();
        var count = measurements.Count();
        var largerMeasurementCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (i + 1 < count && i + 2 < count && i + 3 < count)
                largerMeasurementCount = largerMeasurementCount + IsLargerThenParent((measurements[i +1] + measurements[i + 2] + measurements[i + 3]), (measurements[i]+ measurements[i + 1]+ measurements[i + 2]));
        }
        return largerMeasurementCount;
    }
    public static int FirstChallenge()
    {
        var measurements = File.ReadAllLines(InputFilePath).Select(int.Parse).ToArray();
        var largerMeasurementCount = 0;
        for (int i = 0; i < measurements.Count(); i++)
        {
            if (i + 1 < measurements.Count())
                largerMeasurementCount = largerMeasurementCount + IsLargerThenParent(measurements[i + 1], measurements[i]);
        }
        return largerMeasurementCount;
    }
    static int IsLargerThenParent(int child, int? parent) => (parent.HasValue) switch
    {
        true => child > parent ? 1 : 0,
        _ => 0
    };

}