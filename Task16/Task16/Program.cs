namespace Task16
{
    internal class Program
    {
        static void Main()
        {
           
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(',');
                int X = int.Parse(input[0]);
                int Y = int.Parse(input[1]);
                int Z = int.Parse(input[2]);

                if (Math.Pow(X + Y, 2) == Math.Pow(Z, 2))
                {
                    Console.WriteLine("Test Case Passed");
                }
                else
                {
                    Console.WriteLine("Test Case Failed");
                }
            }
        }
    }
}
