using System.Numerics;
using MathLib.Functions;

namespace MathLib.Numbers;

/// <summary>
/// Represents a rational number.
/// </summary>
public struct Rational<T> where T : IBinaryInteger<T>
{
    /// <summary>
    /// Create a rational number from a numerator and a denominator.
    /// </summary>
    /// <param name="numerator">Numerator.</param>
    /// <param name="denominator">Denominator.</param>
    public Rational(T numerator, T denominator)
    {
        Func.MakeCoprime(ref numerator, ref denominator);
        Numerator = numerator;
        Denominator = denominator;
    }

    /// <summary>
    /// Numerator.
    /// </summary>
    public T Numerator { get; }

    /// <summary>
    /// Denominator.
    /// </summary>
    public T Denominator { get; }

    /// <summary>
    /// Convert a rational number to a string.
    /// </summary>
    /// <returns>String representation of a rational number.</returns>
    public override string ToString() => $"{Numerator}/{Denominator}";
}