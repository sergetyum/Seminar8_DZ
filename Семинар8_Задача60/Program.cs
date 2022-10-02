// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

// 1. Ввод данных.
string[] EnterAndSplitString()
{
    Console.Write("Введите через пробел размер массива X Y Z: ");
    return Console.ReadLine()!.Split(" ");
}

int[] ParseInput(string[] nums)
{
    int[] integerNums = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        integerNums[i] = int.Parse(nums[i]!);
    }
    return integerNums;
}

// 2. Формирование массива неповторяющихся чисел.
int[] RandomFillNoRep(int[,,] array3D)
{
    int[] randNums = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];

    if (randNums.Length > 90) // защита на случай задания большого массива, когда двухзначных чисел не хватит
    {
        throw new Exception("Нет такого количества двухзначных чисел");
    }

    for (int i = 0; i < randNums.GetLength(0); i++)
    {
        Random r = new Random();
        int y = 0;
        randNums[i] = r.Next(10, 100);
        y = randNums[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (randNums[i] == randNums[j])
                {
                    randNums[i] = r.Next(10, 100);
                    j = 0;
                    y = randNums[1];
                }
                y = randNums[i];
            }
        }
    }
    return randNums;
}

// 3. Формирование 3D массива.
void FillArray3D(int[,,] array3D, int[] fill)
{
    int l = 0;
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                array3D[i, j, k] = fill[l++];
            }
        }
    }
}

// 4. Печать массива.
void PrintArray3D(int[,,] array3D)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"{array3D[i, j, k],3} ({i}, {j}, {k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

}

// 5. Вызов методов и Вывод результата в терминал.
int[] size3D = ParseInput(EnterAndSplitString());
int[,,] matrix = new int[size3D[0], size3D[1], size3D[2]];
int[] fill = RandomFillNoRep(matrix);
FillArray3D(matrix, fill);
Console.WriteLine();
Console.Write($"Массив размером {size3D[0]} x {size3D[1]} x {size3D[2]}:");
Console.WriteLine();
PrintArray3D(matrix);