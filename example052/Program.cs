// Задача 52. Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

int GetDataFromUser(string messageForUser) // Запрос размеров матрицы.
{
    int value = 0;
    bool flag = false;

    while (!flag)

    {
        Console.Write(messageForUser);
        flag = int.TryParse(Console.ReadLine(), out value);
        if (flag == false || value <= 0)
        {
            Console.WriteLine("Введённое значение не валидно, используйте целые числа больше 0.");
            flag = false;
        }
    }

    return value;
}

int GetRangeFromUser(string messageForUser) // Запрос диапозона матрицы.
{
    int value = 0;
    bool flag = false;

    while (!flag)

    {
        Console.Write(messageForUser);
        flag = int.TryParse(Console.ReadLine(), out value);
        if (flag == false)
        {
            Console.WriteLine("Введённое значение не валидно, используйте целые числа.");
        }
    }

    return value;
}

int[,] FillMatrix(int[,] matrix, int min, int max) // Добавление случайных чисел.
{
    int lines = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < lines; i++)
    {
        for (int j = 0; j < columns; j++)
        {

            matrix[i, j] = new Random().Next(min, max + 1);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix) // Вывод матрицы.
{
    int lines = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < lines; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

double[] GetAverage(int[,] matrix)
{
    double[] arrayWithAverages = new double[matrix.GetLength(1)];
    int index = 0;
    int sizeArray = arrayWithAverages.Length;
    double average = 0;
    int lines = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    while (index < sizeArray)
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < lines; j++)
            {
                average += matrix[j, i];
            }
            arrayWithAverages[index] = Math.Round(average / lines, 2);
            index++;
            average = 0;
        }
    }
    return arrayWithAverages;
}

void PrintArray(double [] array)
{
    for(int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}

int lines = GetDataFromUser("Введите количество строк массива: ");
int columns = GetDataFromUser("Введите количество столбцов массива: ");
int minimum = GetRangeFromUser("Введите минимальный диапазон чисел: ");
int maximum = GetRangeFromUser("Введите максимальный диапазон чисел: ");

int[,] matrix = new int[lines, columns];

Console.WriteLine("Получена матрица: ");
PrintMatrix(FillMatrix(matrix, minimum, maximum));


double [] arrayWithAverage = GetAverage(matrix);
PrintArray(arrayWithAverage);