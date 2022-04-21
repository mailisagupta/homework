using System;

class Sorter
{
    public static void BubbleSort(int[] array)
    {
        for (int index = 0; index < array.Length; index++)
        {
            for (int inner = index; inner < array.Length; inner++)
            {
                if (array[index] > array[inner])
                {
                    Swap(ref array[index], ref array[inner]);
                }
            }
        }
    }

    public static void Print(string title , int[] a)
    {
        Console.Write(title);
        for (int i =0; i < a.Length;i++)
        {
            Console.Write("{0},", a[i]);
        }
        Console.WriteLine();
    }

    private static void Swap(ref int first, ref int second)
    {
        var temp = first;
        first = second;
        second = temp;
    }

    // TODO: Add static Print function
}

class staticmethodexample
{
    static void Main()
    {
        var values = new int[] { 5, 4, 3, 2, 1 };

        Sorter.Print("Not sorted: ", values);
        Sorter.BubbleSort(values);
        Sorter.Print("Sorted: ", values);

        Console.ReadLine();
    }
}