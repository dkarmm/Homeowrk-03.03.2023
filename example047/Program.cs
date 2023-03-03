// Задача 47. Задайте двумерный массив размером m×n, 
// заполненный случайными вещественными числами.

// m = 3, n = 4.

// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

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

double[,] FillMatrix(double[,] matrix, int min, int max) // Добавление случайных вещ. чисел.
{
    int lines = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < lines; i++)
    {
        for (int j = 0; j < columns; j++)
        {

            matrix[i, j] = Math.Round(new Random().NextDouble() * (max - min) + min, 2);
        }
    }

    return matrix;
}

void PrintMatrix(double[,] matrix) // Вывод матрицы.
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

int lines = GetDataFromUser("Введите количество строк массива: ");
int columns = GetDataFromUser("Введите количество столбцов массива: ");
int minimum = GetRangeFromUser("Введите минимальный диапазон чисел: ");
int maximum = GetRangeFromUser("Введите максимальный диапазон чисел: ");

double[,] matrix = new double[lines, columns];

PrintMatrix(FillMatrix(matrix, minimum, maximum));
