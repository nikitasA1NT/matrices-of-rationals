using MathLib.Numbers;

namespace MathLib.Tests;

public class RationalTests
{
    [Test]
    public void Reduce()
    {
        var expected = new Rational<int>(1, 2);
        var actual = new Rational<int>(2, 4);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Multiply()
    {
        var expected = new Rational<int>(1, 6);
        var a = new Rational<int>(1, 2);
        var b = new Rational<int>(1, 3);
        var actual = a * b;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Divide()
    {
        var expected = new Rational<int>(2, 1);
        var a = new Rational<int>(1, 3);
        var b = new Rational<int>(1, 6);
        var actual = a / b;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Add()
    {
        var expected = new Rational<int>(1, 1);
        var a = new Rational<int>(1, 2);
        var b = new Rational<int>(1, 2);
        var actual = a + b;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Subtract()
    {
        var expected = new Rational<int>(1, 2);
        var a = new Rational<int>(2, 2);
        var b = new Rational<int>(1, 2);
        var actual = a - b;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Compare()
    {
        var a = new Rational<int>(1, 2);
        var b = new Rational<int>(1, 3);
        Assert.IsTrue(a > b);
        Assert.IsTrue(a >= b);
        Assert.IsTrue(b < a);
        Assert.IsTrue(b <= a);
        Assert.IsFalse(a == b);
        Assert.IsTrue(a != b);
    }
    
    [Test]
    public void CompareTo()
    {
        var a = new Rational<int>(1, 2);
        var b = new Rational<int>(1, 3);
        Assert.AreEqual(1, a.CompareTo(b));
        Assert.AreEqual(-1, b.CompareTo(a));
        Assert.AreEqual(0, a.CompareTo(a));
    }
}