/// <summary>
/// 题目
/// </summary>
/*
 * 给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。

请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。

你可以假设 nums1和 nums2不会同时为空。

示例 1:

nums1 = [1, 3]
nums2 = [2]

则中位数是 2.0
示例 2:

nums1 = [1, 2]
nums2 = [3, 4]

则中位数是(2 + 3)/2 = 2.5

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/median-of-two-sorted-arrays
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/


using System;
using System.Collections.Generic;

/*
    测试用例
    static void Main(string[] args)
{
    Q4_FindMedianSortedArrays q4 = new Q4_FindMedianSortedArrays();
    int[] a = new int[] { 1, 2, 5 };
    int[] b = new int[] { 3, 4, 2 };
    Console.WriteLine("result = " + q4.Sulution1_FindMedianSortedArrays(a, b));
}
*/


namespace LeetCodeDemo
{
    class Q4_FindMedianSortedArrays
    {

        /*
         一般解法，先组合两个数组到total再对total排序
        最后判断中位数输出，
        leetcode运行时间280ms，较长，优点是参数数组不要求有序，和底下的差别主要应该是在排序方法不同
        */
        public double Sulution1_FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double result = 0;
            List<int> total = new List<int>();
            total.AddRange(nums1);
            total.AddRange(nums2);
            total.Sort();
            int middle = total.Count / 2;

            if (total.Count % 2 != 0)
            {
                result = total[middle];
            }
            else
            {
                result = (total[middle] + total[middle - 1]) / 2.0;
            }
            foreach (var item in total)
            {
                Console.WriteLine(item);
            }

            return result;
        }


        //188ms范例，但是运行结果和我想象中有偏差，主要是因为题目给的两个数组是有序数组
        public double Sulution2_FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var nums = new int[nums1.Length + nums2.Length];
            int index = 0, i = 0, j = 0;

            //这一部分会把比较nums1和nums2中的大小，比较小的那个数组会先放入nums中，放完以后会跳出循环
            for (; i < nums1.Length && j < nums2.Length;)
            {
                if (nums1[i] < nums2[j])
                {
                    nums[index++] = nums1[i++];
                }
                else if (nums1[i] > nums2[j])
                {
                    nums[index++] = nums2[j++];
                }
                else
                {
                    nums[index++] = nums1[i++];
                    nums[index++] = nums2[j++];
                }
            }

            //这部分会把剩下的数组放入nums中，由于剩下的肯定是比较大的，而且它本身是有序的，所以直接一个一个放进去就行
            if (i < nums1.Length)
            {
                for (; i < nums1.Length;)
                {
                    nums[index++] = nums1[i++];
                }
            }
            else if (j < nums2.Length)
            {
                for (; j < nums2.Length;)
                {
                    nums[index++] = nums2[j++];
                }
            }
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }

            //这时候nums已经排好序了，直接找到中位数输出就行，但是如果是无序数组，这样做是不行的，
            var middleIndex = index / 2;
            if (index % 2 == 0)
            {
                return (nums[middleIndex - 1] + nums[middleIndex]) / 2.0;
            }


            return nums[middleIndex];
        }

    }
}
