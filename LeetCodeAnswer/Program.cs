using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LeetCodeAnswer
{
    class Program
    {
        static void Main(string[] args)
        {
            var dd= Math.Pow(2, 29);
            double val = (double)Math.Log(536870912, 2);
            var tt = Math.Abs(val % 1);
            if (  Math.Abs(val % 1) <= (Double.Epsilon * 100))
            {

            }

            if (val - (double)((int)val) < double.Epsilon)
            {

            }
                uint n = 43261596;
            int count = 0;
            int current = 0;
            while (current < 32)
            {
                var bit = n & 0x01;
                if (bit == 1)
                {
                    count++;
                }
                n = n >> 1;
                current++;
            }

            char[] arr = Convert.ToString(n, 2).PadLeft(32, '0').ToCharArray();
            Array.Reverse(arr);
            string s = new string(arr);
            s.Count(p => p == '1');
            Convert.ToUInt32(s, 2);

            DateTime dt = DateTime.Now;
            dt = dt.AddDays(280);

            Solution solution = new Solution();
            object result;
            solution.ContainsNearbyDuplicate(new int[] { 1, 2, 3, 1 }, 3);
            result = solution.TitleToNumber("ZY");
            result = solution.ConvertToTitle(701);
            result = solution.SingleNumber(new int[] {  2,2,1});
            result = solution.IsPalindrome("race a car");
            result = solution.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
            result = solution.GetRow(5);
            result = solution.HasPathSum(
                new TreeNode(5)
                {
                    left = new TreeNode(4)
                     {
                        left = new TreeNode(11)
                        {
                            left = new TreeNode(7)
                            {
                                
                            },
                            right=new TreeNode(2)
                            {

                            }
                        }
                    },
                    right=new TreeNode(8)
                    {
                        left = new TreeNode(13)
                        {
                            
                        },
                        right=new TreeNode(4)
                        {
                            right=new TreeNode(1)
                            {

                            }
                        }
                    }
                },22);

            Console.WriteLine("Hello World!");
        }
    }



}
