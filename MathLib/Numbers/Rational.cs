using System.Globalization;
using System.Numerics;
using MathLib.Functions;

namespace MathLib.Numbers;

/// <summary>
/// Represents a rational number.
/// </summary>
public readonly struct Rational<T> : INumber<Rational<T>> where T : IBinaryInteger<T>
{
    /// <summary>
    /// Defines the zero value.
    /// </summary>
    public Rational()
    {
        Numerator = T.Zero;
        Denominator = T.One;
    }

    /// <summary>
    /// Create a rational number from a numerator and a denominator.
    /// </summary>
    /// <param name="numerator">Numerator.</param>
    /// <param name="denominator">Denominator.</param>
    public Rational(T numerator, T denominator)
    {
        Func.MakeCoprime(ref numerator, ref denominator);

        if (T.IsNegative(denominator))
        {
            numerator *= -T.One;
            denominator *= -T.One;
        }
        
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
    
    public static bool operator ==(Rational<T> left, Rational<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Rational<T> left, Rational<T> right)
    {
        return !(left == right);
    }

    public static bool operator >(Rational<T> left, Rational<T> right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(Rational<T> left, Rational<T> right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator <(Rational<T> left, Rational<T> right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(Rational<T> left, Rational<T> right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static Rational<T> operator /(Rational<T> left, Rational<T> right)
    {
        var a = left.Numerator * right.Denominator;
        var b = left.Denominator * right.Numerator;
        return new Rational<T>(a, b);
    }
    public static Rational<T> operator *(Rational<T> left, Rational<T> right)
    {
        var a = left.Numerator * right.Numerator;
        var b = left.Denominator * right.Denominator;
        return new Rational<T>(a, b);
    }

    public static Rational<T> operator -(Rational<T> left, Rational<T> right)
    {
        var a = left.Numerator * right.Denominator;
        var b = right.Numerator * left.Denominator;
        var c = left.Denominator * right.Denominator;
        return new Rational<T>(a - b, c);
    }

    public static Rational<T> operator +(Rational<T> left, Rational<T> right)
    {
        var a = left.Numerator * right.Denominator;
        var b = right.Numerator * left.Denominator;
        var c = left.Denominator * right.Denominator;
        return new Rational<T>(a + b, c);
    }

    public static Rational<T> operator %(Rational<T> left, Rational<T> right)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> operator --(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> operator ++(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> operator -(Rational<T> value)
    {
        return new Rational<T>(-value.Numerator, value.Denominator);
    }

    public static Rational<T> operator +(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> Zero => new(T.Zero, T.One);

    public static Rational<T> One => new(T.One, T.One);

    public static int Radix => throw new NotImplementedException();

    public static Rational<T> AdditiveIdentity => Zero;

    public static Rational<T> MultiplicativeIdentity => One;
    
    public static Rational<T> Abs(Rational<T> value)
    {
        if (IsNegative(value))
            return -value;
        return value;
    }

    public static bool IsCanonical(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Rational<T> value)
    {
        return value < Zero;
    }

    public static bool IsNegativeInfinity(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Rational<T> value)
    {
        return value > Zero;
    }

    public static bool IsPositiveInfinity(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Rational<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Rational<T> value)
    {
        return value == Zero;
    }

    public static Rational<T> MaxMagnitude(Rational<T> x, Rational<T> y)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> MaxMagnitudeNumber(Rational<T> x, Rational<T> y)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> MinMagnitude(Rational<T> x, Rational<T> y)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> MinMagnitudeNumber(Rational<T> x, Rational<T> y)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Rational<T> other)
    {
        var a = Numerator * other.Denominator;
        var b = other.Numerator * Denominator;
        return a.CompareTo(b);
    }

    public int CompareTo(object? obj)
    {
        if (obj is Rational<T> other)
        {
            return CompareTo(other);
        }
        throw new ArgumentException("Object is not a Rational.");
    }

    public bool Equals(Rational<T> other)
    {
        return Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator);
    }
    
    public override bool Equals(object? obj)
    {
        return obj is Rational<T> rational && Equals(rational);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    public override string ToString() => $"{Numerator}/{Denominator}";

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return $"{Numerator.ToString(format, formatProvider)}/{Denominator.ToString(format, formatProvider)}";
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        // TODO: Implement this. Now it's just a stub.
        charsWritten = 0;
        return false;
    }

    public static Rational<T> Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out Rational<T> result)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Rational<T> result)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Rational<T> Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Rational<T> result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out Rational<T> result)
    {
        throw new NotImplementedException();
    }

    public static bool TryConvertFromChecked<TOther>(TOther value, out Rational<T> result) where TOther : INumberBase<TOther>
    {
        throw new NotImplementedException();
    }

    public static bool TryConvertFromSaturating<TOther>(TOther value, out Rational<T> result) where TOther : INumberBase<TOther>
    {
        throw new NotImplementedException();
    }

    public static bool TryConvertFromTruncating<TOther>(TOther value, out Rational<T> result) where TOther : INumberBase<TOther>
    {
        throw new NotImplementedException();
    }

    public static bool TryConvertToChecked<TOther>(Rational<T> value, out TOther result) where TOther : INumberBase<TOther>
    {
        throw new NotImplementedException();
    }

    public static bool TryConvertToSaturating<TOther>(Rational<T> value, out TOther result) where TOther : INumberBase<TOther>
    {
        throw new NotImplementedException();
    }

    public static bool TryConvertToTruncating<TOther>(Rational<T> value, out TOther result) where TOther : INumberBase<TOther>
    {
        throw new NotImplementedException();
    }
}