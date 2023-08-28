// Задача 53:
// Задайте двумерный массив.
// Напишите программу, которая
// поменяет местами первую и последнюю строку массива.

int[,] CreateMatrixRandomInt(int rows, int columns, int min, int max)
{
    int[,] mtrx = new int[rows, columns];
    var random = new Random();
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1); j++)
        {
            mtrx[i, j] = random.Next(min, max + 1);
        }
    }
    return mtrx;
}

void OutputMatrix(int[,] mtrx)
{
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1); j++)
        {
            Console.Write($"{mtrx[i, j], 5}");
        }
        Console.WriteLine();
    }
}

void ChangeRows(int[,] matrix, int firstRow, int secondRow) // SwapFirstLastRows
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        int temp = matrix[firstRow, j];
        matrix[firstRow, j] = matrix[secondRow, j];
        matrix[secondRow, j] = temp;
        // (matrix[secondRow, j], matrix[firstRow, j]) = (matrix[firstRow, j], matrix[secondRow, j]); // Кортеж
    }
}

int[,] matrix = CreateMatrixRandomInt(4, 3, 1, 9);
OutputMatrix(matrix);
Console.WriteLine();

ChangeRows(matrix, 0, matrix.GetLength(0) - 1);
OutputMatrix(matrix);
