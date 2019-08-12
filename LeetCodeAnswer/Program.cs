using System;
using System.Collections.Generic;

namespace LeetCodeAnswer
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            object result;
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
