using MathLib.Matrices;
using MathLib.Numbers;

namespace MathLib.Tests;

public class SquareMatrixOfRationalTests
{
    private SquareMatrix<Rational<int>> _sourceMatrix = null!;
    
    [SetUp]
    public void Setup()
    {
        var arrForMatrix = new[,]
        {
            {
                new Rational<int>(1, 2),
                new Rational<int>(1, 3),
                new Rational<int>(1, 4)
            },
            {
                new Rational<int>(2, 3),
                new Rational<int>(2, 4),
                new Rational<int>(2, 5)
            },
            {
                new Rational<int>(3, 4),
                new Rational<int>(3, 5),
                new Rational<int>(3, 6)
            }
        };

        _sourceMatrix = new SquareMatrix<Rational<int>>(arrForMatrix);
    }
    
    [Test]
    public void DeterminantTest()
    {
        var expected = new Rational<int>(1, 7200);
        var actual = _sourceMatrix.Determinant();
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void InverseTest()
    {
        var expectedArr = new[,]
        {
            {
                new Rational<int>(72),
                new Rational<int>(-120),
                new Rational<int>(60)
            },
            {
                new Rational<int>(-240),
                new Rational<int>(450),
                new Rational<int>(-240)
            },
            {
                new Rational<int>(180),
                new Rational<int>(-360),
                new Rational<int>(200)
            }
        };
        var expected = new SquareMatrix<Rational<int>>(expectedArr);
        var actual = _sourceMatrix.Inverse();
        Assert.That(actual.MatrixArray, Is.EqualTo(expected.MatrixArray));
    }
}