using System;

namespace RichestCustomerWealth
{
    class Program 
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution(); 

            int[][] accounts = new int[][]
            {
                new int[] {1,2,3},
                new int[] {3,2,1},
                new int[] {4,5,6}
            }; 
            int maxWealth = solution.MaximumWealth(accounts); 

            Console.WriteLine($"The maximum wealth is: {maxWealth}"); 
        }
    }

    public class Solution 
    {
        public int MaximumWealth(int[][] accounts) 
        {
            int maxWealthSoFar = 0;
            
            foreach (int[] customer in accounts) 
            {
                int currentCustomerWealth = 0;

                foreach (int bank in customer) 
                {
                    currentCustomerWealth += bank;
                }

                maxWealthSoFar = Math.Max(maxWealthSoFar, currentCustomerWealth);
            }
           
            return maxWealthSoFar;
        }
    }
}