using System.Text.RegularExpressions;

namespace SchoolOfDotNet;
public static class Algorithm4
{
    internal static int CountNumber(string number)
    {
        var regex = new Regex(@"\d");
        return regex.Matches(number).Count;
    }
}
