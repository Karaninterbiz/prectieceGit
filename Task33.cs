using System;

class Sparsematrix
{
    public static int[,] GenerateSpars(int rows, int cols, int Count)
    {
        int[,] matrix = new int[rows, cols];
        Random r = new Random();

        for (int i = 0; i < Count; i++)
        {
            int m = r.Next(rows);
            int n = r.Next(cols);
            int value = r.Next(1, 10);


            while (matrix[m, n] != 0)
            {
                m = r.Next(rows);
                n = r.Next(cols);
            }

            matrix[m, n] = value;
        }

        return matrix;
    }

    public static void Print(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public  class Checker
    {
        public static bool IsSparse(int n)
        {
            return (n & (n << 1)) == 0;
        }

        public static void Test()
        {
            int n = 7;
            Console.WriteLine(IsSparse(n) ? "true" : "false"); 

            n = 5;
            Console.WriteLine(IsSparse(n) ? "true" : "false"); 
        }
    }

    public static void Main()
    {
        int n= 5; 
        int m= 5;
        
        int Count = 5;

        int[,] sparseMatrix = GenerateSpars(n, m, Count);
        Print(sparseMatrix);
        
      
        Checker.Test();

    }

   
}
