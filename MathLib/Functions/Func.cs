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
    public static int GreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
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
    public static void MakeCoprime(ref int a, ref int b)
    {
        var greatestCommonDivisor = GreatestCommonDivisor(a, b);
        a /= greatestCommonDivisor;
        b /= greatestCommonDivisor;
    }
}