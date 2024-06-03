using System.Drawing;

namespace EasyGoal.Backend.Application.Extensions;
public static class ColorExtensions
{
    public static string ToHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";
}
