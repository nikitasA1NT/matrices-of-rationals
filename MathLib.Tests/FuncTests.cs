using MathLib.Functions;

namespace MathLib.Tests;

public class FuncTests
{
    [Test]
    public void GreatestCommonDivisor()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Func.GreatestCommonDivisor(1, 1), Is.EqualTo(1));
            Assert.That(Func.GreatestCommonDivisor(1, 2), Is.EqualTo(1));
            Assert.That(Func.GreatestCommonDivisor(2, 1), Is.EqualTo(1));
            Assert.That(Func.GreatestCommonDivisor(2, 2), Is.EqualTo(2));
            Assert.That(Func.GreatestCommonDivisor(3, 2), Is.EqualTo(1));
            Assert.That(Func.GreatestCommonDivisor(2, 3), Is.EqualTo(1));
            Assert.That(Func.GreatestCommonDivisor(4, 2), Is.EqualTo(2));
            Assert.That(Func.GreatestCommonDivisor(2, 4), Is.EqualTo(2));
            Assert.That(Func.GreatestCommonDivisor(6, 2), Is.EqualTo(2));
            Assert.That(Func.GreatestCommonDivisor(6, 4), Is.EqualTo(2));
            Assert.That(Func.GreatestCommonDivisor(2, 6), Is.EqualTo(2));
            Assert.That(Func.GreatestCommonDivisor(4, 6), Is.EqualTo(2));
            Assert.That(Func.GreatestCommonDivisor(9, 6), Is.EqualTo(3));
            Assert.That(Func.GreatestCommonDivisor(6, 9), Is.EqualTo(3));
            Assert.That(Func.GreatestCommonDivisor(9, 3), Is.EqualTo(3));
            Assert.That(Func.GreatestCommonDivisor(3, 9), Is.EqualTo(3));
            Assert.That(Func.GreatestCommonDivisor(9, 12), Is.EqualTo(3));
            Assert.That(Func.GreatestCommonDivisor(12, 9), Is.EqualTo(3));
            Assert.That(Func.GreatestCommonDivisor(12, 8), Is.EqualTo(4));
            Assert.That(Func.GreatestCommonDivisor(8, 12), Is.EqualTo(4));
            Assert.That(Func.GreatestCommonDivisor(10, 5), Is.EqualTo(5));
            Assert.That(Func.GreatestCommonDivisor(5, 10), Is.EqualTo(5));
            Assert.That(Func.GreatestCommonDivisor(12, 6), Is.EqualTo(6));
            Assert.That(Func.GreatestCommonDivisor(6, 12), Is.EqualTo(6));
            Assert.That(Func.GreatestCommonDivisor(7, 14), Is.EqualTo(7));
            Assert.That(Func.GreatestCommonDivisor(14, 7), Is.EqualTo(7));
            Assert.That(Func.GreatestCommonDivisor(8, 16), Is.EqualTo(8));
        });
    }

    [Test]
    public void MakeCoprime()
    {
        var a1 = 1;
        var b1 = 1;
        Func.MakeCoprime(ref a1, ref b1);
        Assert.Multiple(() =>
        {
            Assert.That(a1, Is.EqualTo(1));
            Assert.That(b1, Is.EqualTo(1));
        });
        
        var a2 = 1;
        var b2 = 2;
        Func.MakeCoprime(ref a2, ref b2);
        Assert.Multiple(() =>
        {
            Assert.That(a2, Is.EqualTo(1));
            Assert.That(b2, Is.EqualTo(2));
        });
        
        var a3 = 2;
        var b3 = 1;
        Func.MakeCoprime(ref a3, ref b3);
        Assert.Multiple(() =>
        {
            Assert.That(a3, Is.EqualTo(2));
            Assert.That(b3, Is.EqualTo(1));
        });
        
        var a4 = 2;
        var b4 = 2;
        Func.MakeCoprime(ref a4, ref b4);
        Assert.Multiple(() =>
        {
            Assert.That(a4, Is.EqualTo(1));
            Assert.That(b4, Is.EqualTo(1));
        });
        
        var a5 = 3;
        var b5 = 2;
        Func.MakeCoprime(ref a5, ref b5);
        Assert.Multiple(() =>
        {
            Assert.That(a5, Is.EqualTo(3));
            Assert.That(b5, Is.EqualTo(2));
        });
        
        var a6 = 2;
        var b6 = 3;
        Func.MakeCoprime(ref a6, ref b6);
        Assert.Multiple(() =>
        {
            Assert.That(a6, Is.EqualTo(2));
            Assert.That(b6, Is.EqualTo(3));
        });
        
        var a7 = 4;
        var b7 = 2;
        Func.MakeCoprime(ref a7, ref b7);
        Assert.Multiple(() =>
        {
            Assert.That(a7, Is.EqualTo(2));
            Assert.That(b7, Is.EqualTo(1));
        });
        
        var a8 = 2;
        var b8 = 4;
        Func.MakeCoprime(ref a8, ref b8);
        Assert.Multiple(() =>
        {
            Assert.That(a8, Is.EqualTo(1));
            Assert.That(b8, Is.EqualTo(2));
        });
        
        var a9 = 6;
        var b9 = 2;
        Func.MakeCoprime(ref a9, ref b9);
        Assert.Multiple(() =>
        {
            Assert.That(a9, Is.EqualTo(3));
            Assert.That(b9, Is.EqualTo(1));
        });
    }
}