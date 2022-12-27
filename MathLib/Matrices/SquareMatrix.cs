using System.Numerics;

namespace MathLib.Matrices;

/// <summary>
/// Represents a square matrix.
/// </summary>
/// <typeparam name="T">Matrix from this type.</typeparam>
public class SquareMatrix<T> : Matrix<T> where T : struct, INumber<T>
{
    /// <summary>
    /// Creates a square matrix from a 2D array.
    /// </summary>
    /// <param name="matrixArray">2D array to create a matrix.</param>
    public SquareMatrix(T[,] matrixArray) : base(matrixArray)
    {
        if (matrixArray.GetLength(0) != matrixArray.GetLength(1))
        {
            throw new ArgumentException("Matrix must be square.");
        }

        MatrixArray = matrixArray;
    }

    /// <summary>
    /// Minor of the matrix for the specified row and column.
    /// </summary>
    /// <param name="row">Specified row.</param>
    /// <param name="column">Specified column.</param>
    /// <returns>Minor of the matrix.</returns>
    private T Minor(int row, int column)
    {
        var minor = new T[MatrixArray.GetLength(0) - 1, MatrixArray.GetLength(1) - 1];
        var minorRow = 0;
        var minorColumn = 0;
        for (var i = 0; i < MatrixArray.GetLength(0); i++)
        {
            for (var j = 0; j < MatrixArray.GetLength(1); j++)
            {
                if (i == row || j == column) continue;
                minor[minorRow, minorColumn] = MatrixArray[i, j];
                minorColumn++;
                if (minorColumn != minor.GetLength(1)) continue;
                minorColumn = 0;
                minorRow++;
            }
        }

        return new SquareMatrix<T>(minor).Determinant();
    }
    
    /// <summary>
    /// Cofactor of the matrix for the specified row and column.
    /// </summary>
    /// <param name="row">Specified row.</param>
    /// <param name="column">Specified column.</param>
    /// <returns>Cofactor of the matrix.</returns>
    private T Cofactor(int row, int column)
    {
        var minor = Minor(row, column);
        return (row + column) % 2 == 0 ? minor : minor * -T.One;
    }

    /// <summary>
    /// Calculates the determinant of the matrix.
    /// </summary>
    /// <returns>Determinant of the matrix.</returns>
    public T Determinant()
    {
        if (MatrixArray.GetLength(0) == 1)
        {
            return MatrixArray[0, 0];
        }

        T det = default;
        for (var i = 0; i < MatrixArray.GetLength(0); i++)
        {
            det += MatrixArray[0, i] * Cofactor(0, i);
        }

        return det;
    }
}