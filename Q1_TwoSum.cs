题目1：两数之和
给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 1整数，并返回他们的数组下标。
你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。

示例:
给定 nums = [2, 7, 11, 15], target = 9
因为 nums[0] + nums[1] = 2 + 7 = 9
所以返回 [0, 1]

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/two-sum














代码：
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeDemo
{
    //记得在Main方法中new出你的宝贝对象，然后调用这些方法哦（参数记得给）
    public class Q1_TwoSum
    {

        //通过两次遍历数组；时间复杂度O（n^2），空间复杂度O(1)
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

        //通过hashtale（赋值的时候会覆盖相同的key）；时间复杂度O（n），空间复杂度O(n)
        public int[] Solution2_TwoSum(int[] nums, int target)
        {
            Hashtable hashtable = new Hashtable();
            //把数组值放入Hashtable；
            for (int i = 0; i < nums.Length; i++)
            {
                hashtable[nums[i]] = i;
            }
            //取出值
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

        /*
            方法2遇到的问题：
            在官方给的JAVA版答案中，使用了map.put(num[i],i)这个方法，把数组元素作为key，他们的下标作为value。
            一开始用C#重现的时候，我首先想到了用Hashtable.add(num[i],i)，
            这样做会有一个问题，当使用有重复元素的数组（如nums[]{3,3},target=6）作为参数时，会提示已经有相同的key,不能添加；
            第一时间想到的方法是，把key和value的对调，把下标作为key，数组元素作为value，
            返回的时候，返回value相同，但key（下标代表的是nums的下标）不同的key。
            但！
            首先，通过value来获取key违背了HashTable的原则，它存在的意义就是通过key找value；
            其次，"hashtable 本身是不支持这种反向操作的"，如果你想要这么做，你得自己写个方法；
            最后选择不把key和value对调。在上面的赋值方式中，若Hashtable[num[i]]的key有重复，新的value就会覆盖旧的，设置断点可以查看改变的过程。
            当i=0时，判断Hashtable中是否有key=num[i]但value！=i的键值对（因为被覆盖,原本key=3，value=0会被覆盖成key=3，value=1），
            若有，就输出i和该键值对中的value（数组下标）。
            Java中的map.put能这么写不报错是因为put本身就会覆盖相同的键值对，而在查找相关资料之前并不知道，所以这道题也纠结了很久。
            解题完毕。
            PS:进度也会在个人网站  Candream.cn 跟进，更新欢迎各位大佬前来指教；
        */

    }
}
