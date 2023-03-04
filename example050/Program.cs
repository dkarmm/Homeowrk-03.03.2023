// Задача 50. Напишите программу, которая на вход принимает позиции элемента 
// в двумерном массиве, и возвращает значение этого элемента или же указание, 
// что такого элемента нет.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// 1, 7 -> такого числа в массиве нет

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

int GetIndexElementFromUser(string messageForUser) // Запрос индекса элемента.
{
    int value = 0;
    bool flag = false;

    while (!flag)

    {
        Console.Write(messageForUser);
        flag = int.TryParse(Console.ReadLine(), out value);
        if (flag == false || value < 0)
        {
            Console.WriteLine("Введённое значение не валидно, используйте целые числа больше -1.");
            flag = false;
        }
    }

    return value;
}

void GetNumberFromMatrix(int[,] matrix, int lineForElement, int columnForElement) // Нахождение элемента в матрице.
{
    if (lineForElement > matrix.GetLength(0) | columnForElement > matrix.GetLength(1))
    {
        Console.WriteLine("Такого элемента в матрице нет.");
        return;
    }
    else
    {
        Console.WriteLine($"Элемент по введённым индексам = {matrix[lineForElement, columnForElement]}");
        return;
    }
}

int lines = GetDataFromUser("Введите количество строк массива: ");
int columns = GetDataFromUser("Введите количество столбцов массива: ");
int minimum = GetRangeFromUser("Введите минимальный диапазон чисел: ");
int maximum = GetRangeFromUser("Введите максимальный диапазон чисел: ");

int[,] matrix = new int[lines, columns];

Console.WriteLine("Получена матрица: ");
PrintMatrix(FillMatrix(matrix, minimum, maximum));

int lineForElement = GetIndexElementFromUser("Введите индекс элемента в строке: ");
int columnForElement = GetIndexElementFromUser("Введите индекс элемента в столбце: ");

GetNumberFromMatrix(matrix, lineForElement, columnForElement);
