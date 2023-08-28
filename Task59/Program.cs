// Задача 59:
// Задайте двумерный массив из целых чисел.
// Напишите программу, которая удалит строку и столбец,
// на пересечении которых расположен наименьший элемент массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент – 1, на выходе получим следующий массив:
// 9 2 3
// 4 2 4
// 2 6 7

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

int[] IndexesMinElemMatrix(int[,] mtrx)
{
    int indexRow = 0;
    int indexColumn = 0;
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1); j++)
        {
            if (mtrx[i, j] < mtrx[indexRow, indexColumn])
            {
                indexRow = i;
                indexColumn = j;
            }
        }
    }
    return new int[] { indexRow, indexColumn };
}

int[,] DeleteCrossMinElem(int[,] mtrx, int delRow, int delColumn)
{
    int[,] resultMtrx = new int[mtrx.GetLength(0) - 1, mtrx.GetLength(1) - 1];
    int m = 0, n = 0;
    for (int i = 0; i < resultMtrx.GetLength(0); i++)
    {
        if (m == delRow) m++;
        for (int j = 0; j < resultMtrx.GetLength(1); j++)
        {
            if (n == delColumn) n++;
            resultMtrx[i, j] = mtrx[m, n];
            n++;
        }
        n = 0;
        m++;
    }
    return resultMtrx;
}

// int[,] matrix = { { 1, 4, 7, 2 }, { 5, 9, 2, 3 }, { 8, 4, 2, 4 }, { 5, 2, 6, 7 } };
int[,] matrix = CreateMatrixRandomInt(4, 4, 1, 9);
OutputMatrix(matrix);
Console.WriteLine();

int[] indexesMinElem = IndexesMinElemMatrix(matrix);
int[,] resultMatrix = DeleteCrossMinElem(matrix, indexesMinElem[0], indexesMinElem[1]);
OutputMatrix(resultMatrix);
