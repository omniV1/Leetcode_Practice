using System;

namespace NumberOfStepsToReduceToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            
            // Example: Reduce 14 to zero
            int num = 14;
            int steps = solution.ReduceToZero(num);
            
            Console.WriteLine($"Number of steps to reduce {num} to zero: {steps}");
        }
    }

    public class Solution
    {
        public int ReduceToZero(int num)
        {
            int steps = 0;
            
            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num--;
                }
                steps++;
            }
            return steps;
        }
    }
}