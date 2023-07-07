// Задача 4: * Напишите программу, которая заполнит спирально квадратный массив.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.Clear();
int inputDimensionArray = CheckCorrectInputRowsAndCollumns("Input dimension for array: ");

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

int[,] FillSpiral(int demention) // spiral filling of array  
{
    int[,] array = new int[demention, demention];
    int rowBeg = 0, rowFin = 0, columnBeg = 0, columnFin = 0;
    int row = 0;
    int column = 0;
    int stepNumber = 0;
    while (stepNumber < array.Length)
    {
        array[row, column] = stepNumber;
        if (row == rowBeg && column < demention - columnFin - 1)
            column++;
        else if (column == demention - columnFin - 1 && row < demention - columnFin - 1)
            row++;
        else if (row == demention - rowFin - 1 && column > columnBeg)
            column--;
        else
            row--;
        if ((row == rowBeg + 1) && (column == columnBeg) && (columnBeg != demention - columnFin - 1))
        {
            rowBeg++;
            rowFin++;
            columnBeg++;
            columnFin++;
        }
        stepNumber++;
    }
    return array;
}

int[,] result = FillSpiral(inputDimensionArray);
PrintArray2D(result);
Console.WriteLine();