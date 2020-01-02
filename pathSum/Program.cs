using System;
using System.Collections.Generic;

namespace dagSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Dag triangle = new Dag("inputs/input2.txt");
            PathSum maxSum = triangle.getMaxSum();

            Console.WriteLine(maxSum.PrettyString);
        }
    }
}
