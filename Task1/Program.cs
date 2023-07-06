// Задача 1: Задайте двумерный массив. Напишите программу, которая упорядочивает по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2
Console.Clear();
int inputCountRow = CheckCorrectInputRowsAndCollumns("Input count row: ");
int inputCountColumn = CheckCorrectInputRowsAndCollumns("Input count columns: ");
int inputRandomMin = ReadConsole("Input min random number: ");
int inputRandomMax = ReadConsole("Input max random number: ");

int[,] GenerateArray2D(int rows, int columns, int min, int max) // Generating random(min,max) array[rows,columns] and return this array
{
    int[,] array = new int[rows, columns];
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(min, max);
        }
    }
    return array;
}

void PrintArray2D(int[,] array) // Output array[,] on display
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine("\t");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int CheckCorrectInputRowsAndCollumns(string message) // Checking input numbers on > 0
{
    System.Console.Write(message);
    int number = Convert.ToInt32(Console.ReadLine());
    if (number > 0) return number;
    else
    {
        Console.WriteLine("Please input positive number !");
        return CheckCorrectInputRowsAndCollumns(message);
    }
}

int ReadConsole(string message) // convert in to int32 input numbers on console
{
    System.Console.Write(message);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int[,] OrderByDescRowsElements(int[,] array) // Ordering rows in array by desc 
{
    int i, j;
    Random random = new Random();
    for (i = 0; i < array.GetLength(0); i++)
    {
        for (j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - 1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    int temp = array[i, k + 1];
                    array[i, k + 1] = array[i, k];
                    array[i, k] = temp;
                }
            }
        }
    }
    return array;
}

int[,] randomArray = GenerateArray2D(inputCountRow, inputCountColumn, inputRandomMin, inputRandomMax);
Console.WriteLine($"\nYours array:");
PrintArray2D(randomArray);
Console.WriteLine();
Console.WriteLine($"\nArray with rows order by desc:");
OrderByDescRowsElements(randomArray);
PrintArray2D(randomArray);
Console.WriteLine();