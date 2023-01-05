using MathLib.Matrices;

namespace MathLib.Tests;

public class MatrixOfIntTests
{
    private Matrix<int> _sourceMatrix = null!;

    [SetUp]
    public void Setup()
    {
        var arrForMatrix = new[,]
        {
            {1, 2, 3},
            {4, 5, 6}
        };

        _sourceMatrix = new Matrix<int>(arrForMatrix);
    }

    [Test]
    public void AddMatrices()
    {
        var arrForMatrix = new[,]
        {
            {1, 2, 3},
            {4, 5, 6}
        };

        var matrix = new Matrix<int>(arrForMatrix);

        var result = _sourceMatrix + matrix;
        Assert.Multiple(() =>
        {
            Assert.That(result.MatrixArray[0, 0], Is.EqualTo(2));
            Assert.That(result.MatrixArray[0, 1], Is.EqualTo(4));
            Assert.That(result.MatrixArray[0, 2], Is.EqualTo(6));
            Assert.That(result.MatrixArray[1, 0], Is.EqualTo(8));
            Assert.That(result.MatrixArray[1, 1], Is.EqualTo(10));
            Assert.That(result.MatrixArray[1, 2], Is.EqualTo(12));
        });
    }

    [Test]
    public void SubMatrices()
    {
        var arrForMatrix = new[,]
        {
            {1, 2, 3},
            {4, 5, 6}
        };

        var matrix = new Matrix<int>(arrForMatrix);

        var result = _sourceMatrix - matrix;
        Assert.Multiple(() =>
        {
            Assert.That(result.MatrixArray[0, 0], Is.EqualTo(0));
            Assert.That(result.MatrixArray[0, 1], Is.EqualTo(0));
            Assert.That(result.MatrixArray[0, 2], Is.EqualTo(0));
            Assert.That(result.MatrixArray[1, 0], Is.EqualTo(0));
            Assert.That(result.MatrixArray[1, 1], Is.EqualTo(0));
            Assert.That(result.MatrixArray[1, 2], Is.EqualTo(0));
        });
    }

    [Test]
    public void MultiplyMatrices()
    {
        var arrForMatrix = new[,]
        {
            {1, 2},
            {3, 4},
            {5, 6}
        };

        var matrix = new Matrix<int>(arrForMatrix);

        var result = _sourceMatrix * matrix;
        Assert.Multiple(() =>
        {
            Assert.That(result.MatrixArray[0, 0], Is.EqualTo(22));
            Assert.That(result.MatrixArray[0, 1], Is.EqualTo(28));
            Assert.That(result.MatrixArray[1, 0], Is.EqualTo(49));
            Assert.That(result.MatrixArray[1, 1], Is.EqualTo(64));
        });
    }

    [Test]
    public void MultiplyMatrixByNumber()
    {
        var result = _sourceMatrix * 2;
        Assert.Multiple(() =>
        {
            Assert.That(result.MatrixArray[0, 0], Is.EqualTo(2));
            Assert.That(result.MatrixArray[0, 1], Is.EqualTo(4));
            Assert.That(result.MatrixArray[0, 2], Is.EqualTo(6));
            Assert.That(result.MatrixArray[1, 0], Is.EqualTo(8));
            Assert.That(result.MatrixArray[1, 1], Is.EqualTo(10));
            Assert.That(result.MatrixArray[1, 2], Is.EqualTo(12));
        });
    }

    [Test]
    public void Transpose()
    {
        var expectedArr = new[,]
        {
            {1, 4},
            {2, 5},
            {3, 6}
        };
        var expected = new Matrix<int>(expectedArr);
        var actual = _sourceMatrix.Transpose();
        Assert.Multiple(() =>
        {
            Assert.That(actual.MatrixArray[0, 0], Is.EqualTo(expected.MatrixArray[0, 0]));
            Assert.That(actual.MatrixArray[0, 1], Is.EqualTo(expected.MatrixArray[0, 1]));
            Assert.That(actual.MatrixArray[1, 0], Is.EqualTo(expected.MatrixArray[1, 0]));
            Assert.That(actual.MatrixArray[1, 1], Is.EqualTo(expected.MatrixArray[1, 1]));
            Assert.That(actual.MatrixArray[2, 0], Is.EqualTo(expected.MatrixArray[2, 0]));
            Assert.That(actual.MatrixArray[2, 1], Is.EqualTo(expected.MatrixArray[2, 1]));
        });
    }
}