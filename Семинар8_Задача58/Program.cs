// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

// 1. Задаем параметры первой матрицы.
Console.WriteLine("Задайте параметры первой матрицы.");
Console.Write("Введите количество строк m1: ");
int m1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов n1: ");
int n1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Задайте min1 значение массива: ");
int min1 = int.Parse(Console.ReadLine());
Console.Write("Задайте max1 значение массива: ");
int max1 = int.Parse(Console.ReadLine());

// 2. Задаем параметры второй матрицы.
Console.WriteLine("Задайте параметры второй матрицы.");
Console.Write("Введите количество строк m2: ");
int m2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов n2: ");
int n2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Задайте min2 значение массива: ");
int min2 = int.Parse(Console.ReadLine());
Console.Write("Задайте max2 значение массива: ");
int max2 = int.Parse(Console.ReadLine());

// 3. Объявляем массивы.
int[,] matrix1 = new int[m1, n1];
int[,] matrix2 = new int[m2, n2];

// 4. Инициализация матрицы с помощью генератора случайных чисел.
void FillArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(min2, max2 + 1);
        }
    }
}

// 5. Печать матрицы.
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

// 6. Проверка матриц на совместимость и их перемножение.
static int[,] MatrixProduct(int[,] matr1, int[,] matr2)
{
    if (matr1.GetLength(1) != matr2.GetLength(0)) throw new Exception("Матрицы не согласованы.");
    int[,] matrixRezult = new int[matr1.GetLength(0), matr2.GetLength(1)];
    for (int i = 0; i < matr1.GetLength(0); i++)
    {
        for (int j = 0; j < matr2.GetLength(1); j++)
        {
            for (int k = 0; k < matr2.GetLength(0); k++)
            {
                matrixRezult[i, j] += matr1[i, k] * matr2[k, j];
            }
        }
    }
    return matrixRezult;
}

// 7. Вызываем методы.
FillArray(matrix1);
FillArray(matrix2);
Console.WriteLine();
Console.WriteLine("Матрица 1:");
PrintArray(matrix1);
Console.WriteLine();
Console.WriteLine("Матрица 2:");
PrintArray(matrix2);
Console.WriteLine();
int[,] matrixRezult = MatrixProduct(matrix1, matrix2);
Console.Write("Результирующая матрица:");
Console.WriteLine();
PrintArray(matrixRezult);
Console.WriteLine();