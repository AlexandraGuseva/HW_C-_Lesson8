// Задача 2: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
Console.Clear();
int inputCountRow = CheckCorrectInputRowsAndCollumns("Input count row: ");
int inputCountColumn = CheckCorrectInputRowsAndCollumns("Input count columns: ");
int inputRandomMin = ReadConsole("Input min random number: ");
int inputRandomMax = ReadConsole("Input max random number: ");
int[,] randomArray = GenerateArray2D(inputCountRow, inputCountColumn, inputRandomMin, inputRandomMax);

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

int SumElementsOfRows(int[,] array, int i) // Counts the sum of elements in each row and outputs the row number with the smallest sum of elements
{
    int j;
    int sum = array[i, 0];
    for (j = 0; j < array.GetLength(0); j++)
    {
        sum += array[i, j];
    }
    Console.WriteLine($"sum of elements in row {i}: {sum} ");
    return sum;
}

Console.WriteLine($"\nYours array:");
PrintArray2D(randomArray);
Console.WriteLine();
int minSumLine = 0;
int sumLine = SumElementsOfRows(randomArray, 0);
for (int i = 1; i < randomArray.GetLength(0); i++)
{
    int tempSumLine = SumElementsOfRows(randomArray, i);
    if (sumLine > tempSumLine)
    {
        sumLine = tempSumLine;
        minSumLine = i;
    }
}
Console.WriteLine($"\nRow number with the smallest sum of elements: {minSumLine}. Summ is:  {sumLine}");