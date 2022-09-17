
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
    int row = Array.IndexOf(table, choice) % 4;
    int col = Array.IndexOf(table, choice) / 4;


    
    if (row == 0 && col == 0)
    {
        if ((int)table.GetValue(row * 4 + col) == 0 ||
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
        if ((int)table.GetValue(row * 4 + col-1) != 0 ||
            (int)table.GetValue(((row + 1) * 4 + col)) != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    if (row == 3 && col == 0)
    {
        if ((int)table.GetValue(row * 4 + col + 1) != 0 ||
            (int)table.GetValue(((row -1) * 4 + col)) != 0)
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
        if ((int)table.GetValue(row * 4 + col - 1) != 0 ||
            (int)table.GetValue(((row - 1) * 4 + col)) != 0 ||
            (int)table.GetValue(((row - 1) * 4 + col - 1)) != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    if (row == 0)
    {
        if ((int)table.GetValue(row*4 + col -1) != 0 ||
            (int)table.GetValue(row*4 + col +1) != 0 ||
            (int)table.GetValue((row+1) + col) != 0 ||
            (int)table.GetValue((row+1) + col+1) != 0 ||
            (int)table.GetValue((row+1) + col-1) != 0)
        {
            return false;
        }
        else
        {
            return true;
        }       
    }

    if (row == 3)
    {
        if ((int)table.GetValue(row * 4 + col - 1) != 0 ||
            (int)table.GetValue(row * 4 + col + 1) != 0 ||
            (int)table.GetValue((row - 1) + col) != 0 ||
            (int)table.GetValue((row - 1) + col + 1) != 0 ||
            (int)table.GetValue((row - 1) + col - 1) != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    if (col == 0)
    {
        if ((int)table.GetValue((row - 1) + col) != 0 ||
            (int)table.GetValue((row + 1) + col) != 0 ||
            (int)table.GetValue(row + col+1) != 0 ||
            (int)table.GetValue((row + 1) + (col+1)) != 0 ||
            (int)table.GetValue((row - 1) + (col+1)) != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    if (col == 3)
    {
        if ((int)table.GetValue((row - 1) + col) != 0 ||
            (int)table.GetValue((row + 1) + col) != 0 ||
            (int)table.GetValue(row + col -1)  != 0 ||
            (int)table.GetValue((row - 1) + (col-1)) != 0 ||
            (int)table.GetValue((row + 1) + ( col-1)) != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    if ((int)table.GetValue(row + col + 1) != 0 ||
        (int)table.GetValue(row + col - 1) != 0 ||
        (int)table.GetValue((row - 1) + col) != 0 ||
        (int)table.GetValue((row + 1) + col) != 0 ||
        (int)table.GetValue((row - 1) + (col - 1)) != 0 ||
        (int)table.GetValue((row - 1) + (col + 1)) != 0 ||
        (int)table.GetValue((row + 1) + (col - 1)) != 0 ||
        (int)table.GetValue((row + 1) + (col + 1)) != 0)
    {
        return false;
    }
    else
    {
        return true;
    }
}

int[] debugTable = new[] {7,3,11,15,0,1,5,10,8,2,13,12,4,14,9,6};


//int[] table = generateRandomArray();
printTable(debugTable);
Console.WriteLine("\n");
utilPrint(debugTable);
Console.WriteLine("\n");

Console.Write("Quale casella vuoi spostare: ");
int choice = Convert.ToInt32(Console.ReadLine());
Console.Write("Riga della scelta ");
Console.WriteLine(Array.IndexOf(debugTable, choice) % 4);
Console.Write("Colonna della scelta ");
Console.WriteLine(Array.IndexOf(debugTable,choice) / 4);
int row = 1;
int col = 2;
int ids = row * 4 + col;
Console.WriteLine(debugTable.GetValue(ids));

Console.WriteLine(isValidChoice(debugTable, choice));