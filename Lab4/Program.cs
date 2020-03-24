using System;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new GenericsDescSortedList<int>();
            list.Add(0);
            list.Add(10);
            list.Add(2);
            list.Add(20);
            list.Add(2);
            list.Add(-1);
            list.Add(2);
            list.Add(6);

            Console.WriteLine("Items:");
            
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            
            Console.WriteLine($"\nCount: {list.Count}");
            Console.WriteLine($"Max: {list.Max()}");
            Console.WriteLine($"Min: {list.Min()}");

            Console.ReadKey();
        }
    }
}