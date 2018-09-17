using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion
{
    public static class Program
    {
        private static int BinarySearch(int[] xs, int target, int lb, int ub)
        {
            if (lb >= ub) return -1; // base case
            int mid = (lb + ub) / 2;
            if (xs[mid] == target) return mid; // base case
            if (xs[mid] < target) return BinarySearch(xs, target, mid + 1, ub); // recursive case
            return BinarySearch(xs, target, lb, mid); // recursive case
        }

        private static int[] Merge(int[] xs, int[] ys, int xi, int yi)
        {
            if (xi >= xs.Length) return ys.Skip(yi).ToArray();
            if (yi >= ys.Length) return xs.Skip(xi).ToArray();
            List<int> result = new List<int>();
            if (xs[xi] <= ys[yi]) result.Add(xs[xi++]);
            else result.Add(ys[yi++]);
            result.AddRange(Merge(xs, ys, xi, yi));
            return result.ToArray();
        }

        private static int Sum(int[] xs)
        {
            if (xs.Length == 0) return 0;
            return xs[0] + Sum(xs.Skip(1).ToArray());
        }

        public static void Main(string[] args)
        {
            int[] blah = { 1, 3, 5, 6, 7, 8, 9, 11, 15, 25, 30, 32 };
            for (int i = 0; i < 35; i++)
            {
                int idx = BinarySearch(blah, i, 0, blah.Length);
                if (idx == -1)
                    Console.WriteLine($"Value {i} not found.");
                else
                    Console.WriteLine($"Value {i} found at index {idx}.  Validation: {blah[idx]}");
            }
            Console.ReadLine();
            /*
            int[] a = new int[10];
            int[] b = new int[10];
            Random gen = new Random(2981);
            for (int i = 0; i < 10; i++) { a[i] = gen.Next(0, 25); }
            Array.Sort(a);
            for (int i = 0; i < 10; i++) { b[i] = gen.Next(0, 25); }
            Array.Sort(b);
            int[] c = Merge(a, b, 0, 0);
            for (int i = 0; i < a.Length; i++) { Console.Write($"{a[i]} "); }
            Console.WriteLine();
            for (int i = 0; i < b.Length; i++) { Console.Write($"{b[i]} "); }
            Console.WriteLine();
            for (int i = 0; i < c.Length; i++) { Console.Write($"{c[i]} "); }
            Console.ReadLine();
            */
        }
    }
}