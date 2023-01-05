using MathLib.Matrices;
using MathLib.Numbers;

namespace MathLib.Tests;

public class MatrixOfRationalTests
{
    private Matrix<Rational<int>> _sourceMatrix = null!;
    
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
            }
        };

        _sourceMatrix = new Matrix<Rational<int>>(arrForMatrix);
    }
    
    [Test]
    public void AddMatrices()
    {
        var matrix = new Matrix<Rational<int>>(_sourceMatrix.MatrixArray);

        var result = _sourceMatrix + matrix;
        Assert.Multiple(() =>
        {
            Assert.That(result.MatrixArray[0, 0], Is.EqualTo(new Rational<int>(1, 1)));
            Assert.That(result.MatrixArray[0, 1], Is.EqualTo(new Rational<int>(2, 3)));
            Assert.That(result.MatrixArray[0, 2], Is.EqualTo(new Rational<int>(1, 2)));
            Assert.That(result.MatrixArray[1, 0], Is.EqualTo(new Rational<int>(4, 3)));
            Assert.That(result.MatrixArray[1, 1], Is.EqualTo(new Rational<int>(1, 1)));
            Assert.That(result.MatrixArray[1, 2], Is.EqualTo(new Rational<int>(4, 5)));
        });
    }
    
    [Test]
    public void SubtractMatrices()
    {
        var matrix = new Matrix<Rational<int>>(_sourceMatrix.MatrixArray);

        var result = _sourceMatrix - matrix;
        Assert.Multiple(() =>
        {
            Assert.That(result.MatrixArray[0, 0], Is.EqualTo(new Rational<int>(0, 1)));
            Assert.That(result.MatrixArray[0, 1], Is.EqualTo(new Rational<int>(0, 1)));
            Assert.That(result.MatrixArray[0, 2], Is.EqualTo(new Rational<int>(0, 1)));
            Assert.That(result.MatrixArray[1, 0], Is.EqualTo(new Rational<int>(0, 1)));
            Assert.That(result.MatrixArray[1, 1], Is.EqualTo(new Rational<int>(0, 1)));
            Assert.That(result.MatrixArray[1, 2], Is.EqualTo(new Rational<int>(0, 1)));
        });
    }
    
    [Test]
    public void MultiplyMatrices()
    {
        var matrix = _sourceMatrix.Transpose();

        var result = _sourceMatrix * matrix;
        Assert.Multiple(() =>
        {
            Assert.That(result.MatrixArray[0, 0], Is.EqualTo(new Rational<int>(61, 144)));
            Assert.That(result.MatrixArray[0, 1], Is.EqualTo(new Rational<int>(3, 5)));
            Assert.That(result.MatrixArray[1, 0], Is.EqualTo(new Rational<int>(3, 5)));
            Assert.That(result.MatrixArray[1, 1], Is.EqualTo(new Rational<int>(769, 900)));
        });
    }
    
    [Test]
    public void MultiplyMatrixByNumber()
    {
        var result = _sourceMatrix * new Rational<int>(1, 2);
        Assert.Multiple(() =>
        {
            Assert.That(result.MatrixArray[0, 0], Is.EqualTo(new Rational<int>(1, 4)));
            Assert.That(result.MatrixArray[0, 1], Is.EqualTo(new Rational<int>(1, 6)));
            Assert.That(result.MatrixArray[0, 2], Is.EqualTo(new Rational<int>(1, 8)));
            Assert.That(result.MatrixArray[1, 0], Is.EqualTo(new Rational<int>(1, 3)));
            Assert.That(result.MatrixArray[1, 1], Is.EqualTo(new Rational<int>(1, 4)));
            Assert.That(result.MatrixArray[1, 2], Is.EqualTo(new Rational<int>(1, 5)));
        });
    }
}