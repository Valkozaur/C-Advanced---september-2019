using System;

namespace _7._Pascal_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[n][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new long[i + 1];
                jaggedArray[i][0] = 1;
                jaggedArray[i][jaggedArray[i].Length - 1] = 1;
            }


            for (int row = 2; row < jaggedArray.Length; row++)
            {
                for (int col = 1; col < jaggedArray[row].Length - 1; col++)
                {
                    jaggedArray[row][col] = 
                        jaggedArray[row - 1][col - 1] + 
                        jaggedArray[row - 1][col + 0];
                }
            }

            foreach (var arr in jaggedArray)
            {
                foreach (var number in arr)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
