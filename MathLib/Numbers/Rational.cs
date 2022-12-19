namespace MathLib.Numbers;

/// <summary>
/// Represents a rational number.
/// </summary>
public struct Rational
{
    /// <summary>
    /// Creates a rational number from a numerator and a denominator.
    /// </summary>
    /// <param name="numerator">Numerator.</param>
    /// <param name="denominator">Denominator.</param>
    public Rational(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    /// <summary>
    /// Numerator.
    /// </summary>
    public int Numerator { get; }

    /// <summary>
    /// Denominator.
    /// </summary>
    public int Denominator { get; }
}