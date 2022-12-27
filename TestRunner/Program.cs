using MathLib.Matrices;

var array = new[,]
{
    { 1.1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

var matrix = new SquareMatrix<double>(array);

Console.WriteLine(matrix.Determinant());

var invertible = matrix.Invertible();

Console.WriteLine(1.9 % 2);