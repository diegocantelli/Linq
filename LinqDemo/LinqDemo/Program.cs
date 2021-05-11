using System;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Obtendo o menor valor de um array
            int result = numbers.Min();

            Console.WriteLine(result);
            Console.Read();
        }
    }
}
