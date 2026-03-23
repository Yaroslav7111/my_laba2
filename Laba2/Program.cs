using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using System.Security.AccessControl;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ввиберіть задачу:");
        int n = Convert.ToInt32(Console.ReadLine());
        Tasks(n);
    }
    static void Tasks(int n)
    {
        switch (n)
        {
            case 1:
                Task1();
                break;

            case 2:
                Task2();
                break;

            case 3:
                Task3();
                break;

            case 4:
                Task4();
                break;

            default:
                Console.WriteLine("Такої задачі немає");
                break;
        }


    }
    static bool Corect(int rows, int cols, int[] n, int[] k)
    {
        int sum = n.Length;
        int sum1 = k.Length;
        if (sum > rows || sum < rows)
        {
            Console.WriteLine("Ви ввели не правильну кількість рядків");
            return false;
        }
        if (sum1 > cols || sum1 < cols)
        {
            Console.WriteLine("Ви ввели не правильну кількість стовпців");
            return false;
        }
        else
        {
            return true;
        }
    }
    static int[,] Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        return matrix;
    }
    static bool Corect2(int n, int c)
    {
        if (n == c)
            return true;
        else
            return false;
    }
    static int[,] Input(int[,] arr, int rows, int cols)
    {
        Console.WriteLine("Введіть дані:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Введіть елемент {j + 1} у рядку {i + 1} = ");
                arr[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        return arr;
    }
    static void Input2(out int rows, out int cols)
    {
        Console.Write("Введіть кількість рядків: ");
        rows = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість стовпців: ");
        cols = int.Parse(Console.ReadLine());
    }
    static int [] Sort(int[] arr ,int left, int right)
    {
        int pivot = arr[(left + right) / 2];
        int i = left, j = right;
        while (arr[i] < pivot)
            i++;
        while (arr[j] > pivot)
            j--;
        int temp;
        if (i <= j)
        {
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
            j--;
        }
        if (left < j)
            Sort(arr, left, j);

        if (i < right)
            Sort(arr, i, right);
        return arr;

    }

    static void Task1()
    {
        int rows, cols;

        Input2(out rows, out cols);

        int[,] arr = new int[rows, cols];

        Input(arr, rows, cols);

        int[] ints = new int[rows];
        int[] ints1 = new int[cols];

        int[,] outcome = new int[rows, 2];

        if (!Corect(rows, cols, ints, ints1))
        {
            return;
        }

        for (int i = 0; i < rows; i++)
        {
            int min = arr[i, 0];
            int index = 0;

            for (int j = 0; j < cols; j++)
            {
                if (arr[i, j] < min)
                {
                    min = arr[i, j];
                    index = j;
                }
            }

            outcome[i, 0] = min;
            outcome[i, 1] = index;
        }
        Print(outcome);


    }

    static void Task2()
    {
        int rows, cols;

        Input2(out rows, out cols);

        if (!Corect2(rows, cols))
        {
            Console.WriteLine("Введіть елементи, щоб матриця була квадратна!!!");
            return;
        }

        int[,] arr = new int[rows, cols];

        Input(arr, rows, cols);

        int maxelm = arr[0, 0];
        int maxelemRow = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (arr[i, j] > maxelm)
                {
                    maxelm = arr[i, j];

                    maxelemRow = i;

                }
            }
        }
        int[] maxElmRow = new int[cols];

        for (int j = 0; j < cols; j++)
        {
            maxElmRow[j] = arr[maxelemRow, j];
        }

        int[] needrow = new int[cols];
        
        for (int i = rows - 1, j = 0; i >= 0; i--, j++)
        {
            needrow[j] = arr[i, j];
        }
        for(int j =0; j < cols; j++)
        {
            arr[maxelemRow, j] = needrow[j];
        }
        for (int i =0; i< rows;i++)
        {
            arr[i, cols - 1 - i] = maxElmRow[i];
        }
        
        Print(arr);
    }
        static void Task3()
        {
        int rows, cols;

        Input2(out rows, out cols);

        int[,] arr = new int[rows, cols];

        Input(arr, rows, cols);
        int thisrow;
        int minelm = arr[0, 0];
        thisrow = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (arr[i, j] < minelm)
                {
                    minelm = arr[i, j];
                    thisrow = i;
                }
            }
        }


        int[] thisarr = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            thisarr[j] = arr[thisrow, j];
        }
        Sort(thisarr, 0, thisarr.Length - 1);

        for (int j = 0; j < thisarr.Length; j++)
        {
            arr[thisrow, j] = thisarr[j];
        }
        

        Print(arr);

    }
   
    static void Task4()
        {

        }
    }
