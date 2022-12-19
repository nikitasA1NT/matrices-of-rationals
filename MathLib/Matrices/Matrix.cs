namespace MathLib.Matrices;

/// <summary>
/// Represents a matrix.
/// </summary>
/// <typeparam name="T">Matrix from this type.</typeparam>
public class Matrix<T>
{
    /// <summary>
    /// Creates a matrix from a 2D array.
    /// </summary>
    /// <param name="matrixArray">2D array to create a matrix.</param>
    public Matrix(T[,] matrixArray)
    {
        MatrixArray = matrixArray;
    }

    /// <summary>
    /// Matrix array.
    /// </summary>
    public T[,] MatrixArray { get; }
    
    /// <summary>
    /// Adds two matrices.
    /// </summary>
    /// <param name="matrix1">First matrix.</param>
    /// <param name="matrix2">Second matrix.</param>
    /// <returns>New matrix added from the first and second.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
    {
        if (matrix1.MatrixArray.GetLength(0) != matrix2.MatrixArray.GetLength(0) ||
            matrix1.MatrixArray.GetLength(1) != matrix2.MatrixArray.GetLength(1))
        {
            throw new ArgumentException("Matrices must have the same size.");
        }

        var resultArr = new T[matrix1.MatrixArray.GetLength(0), matrix1.MatrixArray.GetLength(1)];

        for (var i = 0; i < matrix1.MatrixArray.GetLength(0); i++)
        {
            for (var j = 0; j < matrix1.MatrixArray.GetLength(1); j++)
            {
                resultArr[i, j] = (dynamic)matrix1.MatrixArray[i, j]! + matrix2.MatrixArray[i, j];
            }
        }

        return new Matrix<T>(resultArr);
    }
}