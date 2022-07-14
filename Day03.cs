namespace AdventOfCode2021;
public class Day03 {
    const string InputPuzzle = @".\Items\Puzzle_day03.txt";
    enum LogicType {
        oxygen,
        co2
    }
    public static int SecondChallenge () {
        var items = File.ReadAllLines (InputPuzzle).Select (s => ConvertToIntTable (s));
        var oxygen = DoOxygenLogic (items, 0, LogicType.oxygen);
        var co2 = DoOxygenLogic (items, 0, LogicType.co2);
        return 1;
    }

    static IEnumerable<short[]> DoOxygenLogic (IEnumerable<short[]> oxygenItems, int j, LogicType type) {
        if (j >= oxygenItems.First ().Length)
            return oxygenItems;
        var oneCount = oxygenItems.Where (o => o[j] == 1);
        var zeroCount = oxygenItems.Where (o => o[j] == 0);
        if (type == LogicType.oxygen) {
            return zeroCount.Count () > oneCount.Count () ? DoOxygenLogic (new List<short[]> (zeroCount), ++j, LogicType.oxygen) : DoOxygenLogic (new List<short[]> (oneCount), ++j, LogicType.oxygen);
        } else {
            return zeroCount.Count () < oneCount.Count () ? DoOxygenLogic (new List<short[]> (zeroCount), ++j, LogicType.co2) : DoOxygenLogic (new List<short[]> (oneCount), ++j, LogicType.co2);
        }
    }

    public static int FirstChallenge () {
        var items = File.ReadAllLines (InputPuzzle).Select (s => ConvertToIntTable (s));
        var gammaRateString = "";
        var elipsonRateString = "";
        for (var i = 0; i < items.First ().Length; i++) {
            var zeroCount = 0;
            var oneCount = 0;
            foreach (var item in items) {
                if (item[i] == 0) {
                    zeroCount++;
                } else {
                    oneCount++;
                }
            }
            if (zeroCount > oneCount) {
                gammaRateString += "0";
            } else {
                gammaRateString += "1";
            }
        }
        foreach (var item in ConvertToIntTable (gammaRateString)) {
            if (item == 0) {
                elipsonRateString += "1";
            } else {
                elipsonRateString += "0";
            }
        }
        return Convert.ToInt16 (gammaRateString, 2) * Convert.ToInt32 (elipsonRateString, 2);
    }
    static short[] ConvertToIntTable (string s) => Array.ConvertAll (s.ToArray (), i => Convert.ToInt16 (Char.GetNumericValue (i)));
}