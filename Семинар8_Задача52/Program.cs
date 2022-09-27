// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит
// по убыванию элементы каждой строки двумерного массива.


// 1. Задаем параметры массива (размер, мин. и макс. значения).
Console.WriteLine("Задайте параметры двумерного массива.");
Console.Write("Введите количество строк m: ");
int m = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов n: ");
int n = int.Parse (Console.ReadLine());
Console.Write("Задайте min значение массива: ");
int min = int.Parse (Console.ReadLine());
Console.Write("Задайте max значение массива: ");
int max = int.Parse (Console.ReadLine());

// 2. Объявляем двумерный массив.
int[,] matrix = new int[m,n];

// 3. Инициализируем массив с помощью генератора случайных чисел.
void FillArray (int[,] matrix)
{
    for (int i=0; i<m; i++)
    {
       for (int j=0; j<n; j++)
       {
       matrix[i,j] = new Random().Next(min,max+1);
       }
    }
}

// 5. Печатаем матрицу.
void PrintArray (int[,] matrix)
{
    for (int i=0; i<m; i++)
    {
    for (int j=0; j<n; j++)
    {
    Console.Write ($"{matrix[i,j]}{" "}");
    }
    Console.WriteLine();
    }
}

// 6. Сортируем элементы каждой строки массива по убыванию. Отсортированный массив выводим в терминал.
 void SortingAndPrintArray (int[,] matrix)
{
    int[] row = new int[n]; // объявляем временный одномерный массив row с количеством элементов равным количеству элементов в каждой строке исходного массива.
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        row[j] = matrix[i, j];
        Array.Sort(row);
        for (int k = n-1; k >= 0; k--)
        {
        matrix[i, k] = row[k];
        Console.Write ($"{matrix[i,k]}{" "}");
        }
        Console.WriteLine();
    }
}

// 7. Вызываем методы
FillArray (matrix);
Console.Write("Задан массив:");
Console.WriteLine();
PrintArray (matrix);
Console.Write("Массив, отсортированный по убыванию элементов каждой строки:");
Console.WriteLine();
SortingAndPrintArray (matrix);