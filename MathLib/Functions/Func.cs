using System.Numerics;

namespace MathLib.Functions;

/// <summary>
/// Implements various functions and actions.
/// </summary>
public static class Func
{
    /// <summary>
    /// Find the greatest common divisor of two numbers.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>The greatest common divisor.</returns>
    public static T GreatestCommonDivisor<T>(T a, T b) where T : IBinaryInteger<T>
    {
        while (b != T.Zero)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    
    /// <summary>
    /// Make two numbers coprime.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    public static void MakeCoprime<T>(ref T a, ref T b) where T : IBinaryInteger<T>
    {
        var greatestCommonDivisor = GreatestCommonDivisor(a, b);
        a /= greatestCommonDivisor;
        b /= greatestCommonDivisor;
    }
}