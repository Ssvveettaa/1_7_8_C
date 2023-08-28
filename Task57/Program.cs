// Задача 57:
// Составить частотный словарь элементов двумерного массива.
// Частотный словарь содержит информацию о том,
// сколько раз встречается элемент входных данных.

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

int[] MatrixToArray(int[,] mtrx)
{
    int[] arr = new int[mtrx.Length];
    int k = 0;
    for (int i = 0; i < mtrx.GetLength(0); i++)
    {
        for (int j = 0; j < mtrx.GetLength(1); j++)
        {
            arr[k] = mtrx[i, j];
            k++;
        }
    }
    return arr;
}

void FrequencyNumDictionary(int[] arr)
{
    int currentNum = arr[0];
    int count = 1;
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] == currentNum) count++;
        else
        {
            Console.WriteLine($"Количество {currentNum} –> {count}.");
            currentNum = arr[i];
            count = 1;
        }
    }
    Console.WriteLine($"Количество {currentNum} –> {count}.");
}

int[,] matrix = CreateMatrixRandomInt(3, 3, 1, 9);
OutputMatrix(matrix);
Console.WriteLine();

// int[] array = { 1, 1, 1, 2, 2, 2, 3, 3, 3, 9, 9, 9, 9 };
int[] array = MatrixToArray(matrix);
Array.Sort(array);

Console.WriteLine(string.Join(" ", array));
Console.WriteLine();
FrequencyNumDictionary(array);
