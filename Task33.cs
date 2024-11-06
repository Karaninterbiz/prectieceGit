using System;

class Sparsematrix
{ public static int[,] GenerateSpars(int rows, int cols, int count)
 {
     int[,] matrix = new int[rows, cols];

     int[,] positions = { { 0, 0 }, { 1, 2 }, { 2, 3 }, { 3, 1 }, { 4, 4 } };
     int[] values = { 5, 3, 8, 7, 2 };

  
     count = Math.Min(count, positions.Length / 2);

     for (int i = 0; i < count; i++)
     {
         int m = positions[i, 0];
         int n = positions[i, 1];
         int value = values[i];

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
