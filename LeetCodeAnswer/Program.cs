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
            result = solution.LevelOrderBottom(new TreeNode(1) { left = new TreeNode(1) { left = new TreeNode(2) { left = new TreeNode(3) { left = new TreeNode(3) } } } });

            Console.WriteLine("Hello World!");
        }
    }



}
