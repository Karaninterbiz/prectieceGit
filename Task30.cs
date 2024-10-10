using System;

namespace LogicalQuestion30
{
    internal class Program
    {
        public static long Factorial(int num)
        {
            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i; 
            }
            return result;
        }
        public static (int, int) FindPrimeDigit(int num)
        {
            long factorial = Factorial(num); 
            string factorialStr = factorial.ToString(); 

            for (int i = factorialStr.Length - 1; i >= 0; i--)
            {
                int digit = factorialStr[i] - '0'; 

                
                if (IsPrime(digit))
                {
                    int positionFromEnd = factorialStr.Length - i;
                    return (digit, positionFromEnd); 
                }
            }
            return (-1, -1);
        }

        public static bool IsPrime(int digit)
        {
            return (digit == 2 || digit == 3 || digit == 5 || digit == 7); 
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(" Please Enter a number which is less than 15 and it should be positive number : ");

                bool isValidNum = int.TryParse(Console.ReadLine(), out int num);
                if (!(isValidNum && num <= 15 && num > 0))
                {
                    Console.WriteLine("Please input value which is less than 15 and it should be positive number");
                    continue;
                }

                (int prime, int position) result = FindPrimeDigit(num);
                Console.WriteLine($"Prime number: {result.prime}, Position from end: {result.position}");
            }
        }
    }
}
