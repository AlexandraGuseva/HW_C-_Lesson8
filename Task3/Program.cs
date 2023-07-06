// Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// 2 4 | 3 4 2
// 3 2 | 3 3 1
// Результирующая матрица будет:
// 18 20 8
// 15 18 7
Console.Clear();
int inputCountRowArray1 = CheckCorrectInputRowsAndCollumns("Input count row for array1: ");
int inputCountColumnArray1 = CheckCorrectInputRowsAndCollumns("Input count columns for array1: ");
int inputCountRowArray2 = CheckCorrectInputRowsAndCollumns("Input count row for array2: ");
int inputCountColumnArray2 = CheckCorrectInputRowsAndCollumns("Input count columns for array2: ");
int inputRandomMin = ReadConsole("Input min random number: ");
int inputRandomMax = ReadConsole("Input max random number: ");
int[,] randomArray1 = GenerateArray2D(inputCountRowArray1, inputCountColumnArray1, inputRandomMin, inputRandomMax);
int[,] randomArray2 = GenerateArray2D(inputCountRowArray2, inputCountColumnArray2, inputRandomMin, inputRandomMax);

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
        Console.Write("\t");
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

int[,] MultiplyArray(int[,] array1, int[,] array2) // finds the product of elements of two arrays
{
    int[,] resultArray = new int[inputCountRowArray1, inputCountColumnArray2];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < array1.GetLength(1); k++)
            {
                sum += array1[i, k] * array2[k, j];
            }
            resultArray[i, j] = sum;
        }
    }
    return resultArray;
}

Console.WriteLine($"\nYours array1:");
PrintArray2D(randomArray1);
Console.WriteLine($"\nYours array2:");
PrintArray2D(randomArray2);
Console.WriteLine();
int[,] multipleArray = MultiplyArray(randomArray1, randomArray2);
Console.WriteLine($"\nResult multiply array12:");
PrintArray2D(multipleArray);
Console.WriteLine();