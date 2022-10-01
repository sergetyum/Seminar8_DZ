// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

// 1. Исходные данные
int m = 4; //задано кол-во строк
int n = 4; //задано кол-во столбцов
int s = 1; //задано начальное значение

// 2. Объявляем и инициализируем двумерный массив.
int[,] array = new int[m, n];

// 3. Формирование массива по спирали.
void FillArray(int[,] array)
{
    //Заполняем периметр массива по часовой стрелке.
    for (int j = 0; j < array.GetLength(1); j++)
    {
        array[0, j] = s;
        s++;
    }
    for (int i = 1; i < array.GetLength(0); i++)
    {
        array[i, n - 1] = s;
        s++;
    }
    for (int j = array.GetLength(1) - 2; j >= 0; j--)
    {
        array[m - 1, j] = s;
        s++;
    }
    for (int i = array.GetLength(0) - 2; i > 0; i--)
    {
        array[i, 0] = s;
        s++;
    }

    //Продолжаем заполнять массив и задаём координаты ячейки, которую необходимо заполнить следующей.
    int k = 1;
    int l = 1;

    while (s < m * n)
    {
        //Следующие циклы поочерёдно работают, заполняя ячейки.
        //Вложенный цикл останавливается, если следующая ячейка имеет значение, отличное от ноля.
        //Ячейка, на которой остановился цикл, не заполняется.

        while (array[k, l + 1] == 0) //движемся вправо
        {
            array[k, l] = s;
            s++;
            l++;
        }

        while (array[k + 1, l] == 0) //движемся вниз
        {
            array[k, l] = s;
            s++;
            k++;
        }

        while (array[k, l - 1] == 0) //движемся влево
        {
            array[k, l] = s;
            s++;
            l--;
        }

        while (array[k - 1, l] == 0) //движемся вверх
        {
            array[k, l] = s;
            s++;
            k--;
        }
    }

    //При данном решении в центре всегда остаётся незаполненная ячейка.Убираем её при помощи цикла.
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] == 0)
            {
                array[i, j] = s;
            }
        }
    }
}

// 4. Печать массива.
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < 10)
            {
                Console.Write($"0{array[i, j]}{" "}"); //Добавим 0 для однозначных чисел.
            }
            else
            {
                Console.Write($"{array[i, j]}{" "}");
            }
        }
        Console.WriteLine();
    }
}

// 5. Вызываем методы.
Console.WriteLine("Заполнение спиралью массива 4 на 4:");
FillArray(array);
PrintArray(array);