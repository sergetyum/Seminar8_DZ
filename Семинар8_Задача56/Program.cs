// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.

// 1. Задаем параметры прямоугольного массива (размер, мин. и макс. значения).
Console.WriteLine("Задайте параметры двумерного массива.");
Console.Write("Введите количество строк m: ");
int m = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов n: ");
int n = int.Parse(Console.ReadLine());
Console.Write("Задайте min значение массива: ");
int min = int.Parse(Console.ReadLine());
Console.Write("Задайте max значение массива: ");
int max = int.Parse(Console.ReadLine());

// 2. Объявляем двумерный массив.
int[,] matrix = new int[m, n];

// 3. Инициализируем массив с помощью генератора случайных чисел.
void FillArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(min, max + 1);
        }
    }
}

// 5. Печатаем матрицу.
void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}{" "}");
        }
        Console.WriteLine();
    }
}

// 6. Находим строку с наименьшей суммой элементов. Выводим номер строки с наименьшей суммой элементов в терминал.
void StringWithTheSmallestSumOfElements(int[,] matrix)
{
    int index = 0;
    int minsumma = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int summa = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            summa += matrix[i, j];
        }
        if (i == 0)
        {
            minsumma = summa;
        }
        else if (summa < minsumma)
        {
            minsumma = summa;
            index = i;
        }
    }
    Console.Write($"Строка с наименьшей суммой элементов: {index + 1}."); // index+1 - учитываем, что нумерация индекса начинается с 0.
    Console.WriteLine();
}

// 7. Вызываем методы.
FillArray(matrix);
Console.Write("Задан массив:");
Console.WriteLine();
PrintArray(matrix);
StringWithTheSmallestSumOfElements(matrix);
Console.WriteLine();