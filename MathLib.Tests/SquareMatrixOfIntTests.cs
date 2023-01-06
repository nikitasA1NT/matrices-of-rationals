using MathLib.Matrices;

namespace MathLib.Tests;

public class SquareMatrixOfIntTests
{
    private SquareMatrix<int> _sourceMatrix = null!;

    [SetUp]
    public void Setup()
    {
        var arrForMatrix = new[,]
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        _sourceMatrix = new SquareMatrix<int>(arrForMatrix);
    }

    [Test]
    public void DeterminantOfMatrix()
    {
        const int expected = 0;
        var actual = _sourceMatrix.Determinant();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void InvertibleMatrix()
    {
        _sourceMatrix.MatrixArray[0, 0] = 2;
        
        var arrForExpected = new[,]
        {
            {1, -2, 1},
            {-2, 1, 0},
            {1, 0, 0}
        };
        
        var expected = new SquareMatrix<int>(arrForExpected);
        
        var actual = _sourceMatrix.Inverse();
        
        Assert.That(actual.MatrixArray, Is.EqualTo(expected.MatrixArray));
    }
}