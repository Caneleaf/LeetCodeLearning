using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeDemo
{
    public class Q1_TwoSum
    {

        //通过两次遍历数组
        public int[] Solution1_TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new Exception("No two sum solution");

        }

        //通过hashtale（赋值的时候会覆盖相同的key）
        public int[] Solution2_TwoSum(int[] nums, int target)
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                hashtable[nums[i]] = i;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (hashtable.Contains(complement) && (int)hashtable[complement] != i)
                {
                    return new int[] { i, (int)hashtable[complement] };
                }
            }
            throw new Exception("No Two Sum Solution");
        }        
    }
}
