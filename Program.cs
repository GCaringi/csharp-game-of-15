
using System.Data;

void printTable(int[] table)
{
    for (int i = 0; i < table.Length; i++)
    {
        if (i % 4 != 0)
        {
            Console.Write($"{table[i]}\t");
        }
        else
        {
            Console.Write($"\n{table[i]}\t");
        }
    }
}

void utilPrint(int[] table)
{
    for (int i = 0; i < table.Length; i++)
    {
        if (i % 4 != 0)
        {
            Console.Write($"{table[i]}\t");
        }
        else
        {
            Console.Write($"|{table[i]}\t");
        }
    }
    Console.WriteLine();
}

int[] generateRandomArray()
{
    int[] randArray = new int[16];

    Random rnd = new Random();
    randArray = Enumerable.Range(0, randArray.Length)
                          .OrderBy(x => rnd.Next())
                          .ToArray();
    return randArray;
}

bool isValidChoice(int[] table,int choice) 
{
    int col = Array.IndexOf(table, choice) % 4;
    int row = Array.IndexOf(table, choice) / 4;

    if (row == 0 && col == 0)
    {
        if ((int)table.GetValue(row * 4 + col + 1) == 0 ||
            (int)table.GetValue(((row+1) * 4 + col)) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    if (row == 0 && col == 3)
    {
        if ((int)table.GetValue(row * 4 + col - 1) == 0 ||
            (int)table.GetValue((row + 1) * 4 + col) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    if (row == 3 && col == 0)
    {
        if ((int)table.GetValue(row * 4 + col + 1) == 0 ||
            (int)table.GetValue(((row - 1) * 4 + col)) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    if (row == 3 && row == 3)
    {
        if ((int)table.GetValue(row * 4 + col - 1) == 0 ||
            (int)table.GetValue(((row - 1) * 4 + col)) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    if (row == 0)
    {
        if ((int)table.GetValue(row * 4 + col - 1) == 0 ||
            (int)table.GetValue(row * 4 + col + 1) == 0 ||
            (int)table.GetValue((row + 1) * 4 + col) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }       
    }

    if (row == 3)
    {
        if ((int)table.GetValue(row * 4 + col - 1) == 0 ||
            (int)table.GetValue(row * 4 + col + 1) == 0 ||
            (int)table.GetValue((row - 1) * 4 + col) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    if (col == 0)
    {
        if ((int)table.GetValue((row - 1) * 4  + col) == 0 ||
            (int)table.GetValue((row + 1) * 4  + col) == 0 ||
            (int)table.GetValue(row * 4 + col + 1) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    if (col == 3)
    {
        if ((int)table.GetValue((row - 1) * 4 + col) == 0 ||
            (int)table.GetValue((row + 1) * 4  + col) == 0 ||
            (int)table.GetValue(row * 4  + col - 1)  == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    if ((int)table.GetValue(row * 4 + col + 1) == 0 ||
        (int)table.GetValue(row * 4 + col - 1) == 0 ||
        (int)table.GetValue((row - 1) * 4 + col) == 0 ||
        (int)table.GetValue((row + 1) * 4 + col) == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool isWin(int[] table)
{
    for (int i = 1; i < table.Length; i++)
    {
        Console.WriteLine($"{table[i-1]}, {i}");
        if (table[i-1] != i)
        {
            return false;
        }
    }

    return true;
}

//int[] debugTable = new[] {7,3,11,15,8,1,5,10,0,2,13,12,4,14,9,6};

int[] debugTable = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

//int[] debugTable = generateRandomArray();
printTable(debugTable);
Console.WriteLine("\n");
utilPrint(debugTable);
Console.WriteLine("\n");

Console.Write("Quale casella vuoi spostare: ");
int choice = Convert.ToInt32(Console.ReadLine());

Console.WriteLine(isValidChoice(debugTable, choice));

bool flag = isWin(debugTable);
if (flag)
{
    Console.WriteLine("Win");
}
else
{
    Console.WriteLine("Lose");
}