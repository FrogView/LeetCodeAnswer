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
