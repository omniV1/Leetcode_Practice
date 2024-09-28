/* Advanced Concepts: 
*
* Binary representation of integers
* Bitwise Shift Operators
* Bitwirse Logical Operators 
*  & | ^ ` 
* Bitmasks
*/
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
                if ((num & 1) == 0) // num: xxxxxx0 & bitmask: 000000001
                {
                   // before we used num /= 2;
                   num >>= 1; 
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