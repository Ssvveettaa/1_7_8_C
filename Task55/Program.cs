// Задача 55:
// Задайте двумерный массив.
// Напишите программу, которая
// заменяет строки на столбцы.
// В случае, если это невозможно,
// программа должна вывести сообщение для пользователя.

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
            Console.Write($"{mtrx[i, j],5}");
        }
        Console.WriteLine();
    }
}

bool ValidateSquareMatrix(int[,] mtrx)
{
    return mtrx.GetLength(0) == mtrx.GetLength(1);
}

void SwapRowsColumns(int[,] mtrx)
{
    // for (int i = 1; i < matrix.GetLength(0); i++)    // Нижний треугольник
    for (int i = 0; i < mtrx.GetLength(0) - 1; i++)     // Верхний треугольник
    {
        // for (int j = 0; j < i; j++)                  // Нижний треугольник
        for (int j = i + 1; j < mtrx.GetLength(1); j++) // Верхний треугольник
        {                                               // x-x   x-x   x-x   x-x    // x-x   0-1   0-2   0-3
            int temp = mtrx[i, j];                      // 1-0   x-x   x-x   x-x    // x-x   x-x   1-2   1-3
            mtrx[i, j] = mtrx[j, i];                    // 2-0   2-1   x-x   x-x    // x-x   x-x   x-x   2-3
            mtrx[j, i] = temp;                          // 3-0   3-1   3-2   x-x    // x-x   x-x   x-x   x-x
            // (mtrx[j, i], mtrx[i, j]) = (mtrx[i, j], mtrx[j, i]); // Кортеж
        }
    }
}

int[,] matrix = CreateMatrixRandomInt(4, 4, 1, 9);
OutputMatrix(matrix);
Console.WriteLine();

if (ValidateSquareMatrix(matrix))
{
    SwapRowsColumns(matrix);
    OutputMatrix(matrix);
}
else Console.WriteLine("Невозможно заменить строки на столбцы.");
