using System.Numerics;

namespace MathLib.Matrices;

/// <summary>
/// Represents a square matrix.
/// </summary>
/// <typeparam name="T">Matrix from this type.</typeparam>
public class SquareMatrix<T> : Matrix<T> where T : INumber<T>, new()
{
    /// <summary>
    /// Creates a square matrix from a 2D array.
    /// </summary>
    /// <param name="matrixArray">2D array to create a matrix.</param>
    /// <exception cref="ArgumentException">Thrown when the matrix is not square.</exception>
    public SquareMatrix(T[,] matrixArray) : base(matrixArray)
    {
        if (matrixArray.GetLength(0) != matrixArray.GetLength(1))
        {
            throw new ArgumentException("Matrix must be square.");
        }
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

        var det = new T();
        for (var i = 0; i < MatrixArray.GetLength(0); i++)
        {
            det += MatrixArray[0, i] * Cofactor(0, i);
        }

        return det;
    }
    
    /// <summary>
    /// Calculates the invertible matrix. Incorrectly calculated for matrices of integer types.
    /// </summary>
    /// <returns>Invertible matrix.</returns>
    /// <exception cref="ArithmeticException">Thrown when the determinant is zero.</exception>
    public SquareMatrix<T> Inverse()
    {
        var det = Determinant();
        if (det == T.Zero)
        {
            throw new ArithmeticException("Matrix is not invertible. Determinant is zero.");
        }

        var invertible = new T[MatrixArray.GetLength(0), MatrixArray.GetLength(1)];
        for (var i = 0; i < MatrixArray.GetLength(0); i++)
        {
            for (var j = 0; j < MatrixArray.GetLength(1); j++)
            {
                invertible[i, j] = Cofactor(j, i) / det;
            }
        }

        return new SquareMatrix<T>(invertible);
    }
}