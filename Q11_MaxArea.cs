/// <summary>
/// 题目
/// </summary>
/*
给定 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

说明：你不能倾斜容器，且 n 的值至少为 2。



图中垂直线代表输入数组 [1,8,6,2,5,4,8,3,7]。在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为 49。

 

示例:

输入: [1,8,6,2,5,4,8,3,7]
输出: 49

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/container-with-most-water
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/

using System;

namespace LeetCodeDemo
{
    class Q11_MaxArea
    {

        //暴力解法，遍历所有线段可能组成的面积，取出最大的面积即可。
        public int Sulution1_MaxArea(int[] height)
        {
            int maxarea = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    maxarea = Math.Max(maxarea, Math.Min(height[i], height[j]) * (j - i));
                }
            }
            return maxarea;
        }


        //双指针法，头尾各放一个指针，计算L-R中矩形的最大面积，存入maxarea，然后比较小的那个指针往比较大的那个指针移动，再计算他们之中最大的面积，并且把结果和maxarea比较，重复步骤
        public int Sulution2_MaxArea(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, (Math.Min(height[l], height[r]) * (r - l)));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }

    }
}
