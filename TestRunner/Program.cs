using MathLib.Matrices;

var array = new[,]
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

var matrix = new SquareMatrix<int>(array);

Console.WriteLine(matrix.Determinant());