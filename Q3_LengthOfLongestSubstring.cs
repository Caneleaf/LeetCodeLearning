using System.Collections.Generic;


/// <summary>
/// 题目
/// </summary>
/*给定一个字符串，请你找出其中不含有重复字符的 最长子串的长度。

示例 1:

输入: "abcabcbb"
输出: 3 
解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
示例 2:

输入: "bbbbb"
输出: 1
解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
示例 3:

输入: "pwwkew"
输出: 3
解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/longest-substring-without-repeating-characters
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/



namespace LeetCodeDemo
{
    class Q3_LengthOfLongestSubstring
    {
        //滑动窗口，复杂度O(n)
        public int Solution1_LengthOfLongestSubstring(string s)
        {
            //两个List
            List<char> ls = new List<char>();
            List<char> result = new List<char>();
            int n = s.Length;
            int intMaxLength = 0;
            for (int i = 0; i < n; i++)
            {
                //判断是否有重复字符
                if (ls.Contains(s[i]))
                {
                    //判断result是否小于ls
                    if (result.Count <= ls.Count)
                    {
                        result.AddRange(ls);
                    }
                    //移除重复字符之前的字符串
                    ls.RemoveRange(0, ls.IndexOf(s[i]) + 1);
                }
                ls.Add(s[i]);
                intMaxLength = ls.Count> intMaxLength ? ls.Count : intMaxLength;
            }

            //输出result（并不必要）
            if (result.Count==0)
            {
                foreach (var item in ls)
                {
                    System.Console.WriteLine(item);
                }
            }
            else
            {
                foreach (var item in result)
                {
                    System.Console.WriteLine(item);
                }
            }

            return intMaxLength;
        }
    }
}

/*
直接看答案了，思考了一下感觉没有问题；
new一个List当做子串，遍历原字符串s，每次都提取一个字符看看List中是否有相同字符
若有相同字符，则移除第一次出现这个字符和它之前的所有字符串，然后再往这个新的子串里添加字符，
但是此时，这个新子串的大小不一定比删除字符前的子串大小更大，所以要判断一下intMaxLength（旧的最大子串长度）是否大于ls.count（新的最大子串长度），
如果ls.count>intMaxLenth，重新赋值，否则不变。
最后输出intMaxLenth。

这样做有一个问题就是，如果题目要求的是输出这个最大子串的话,
测试用例是 "abcb" 这样的字符串时，ls最后的结果会是cb，但intMaxLength还是3。如果此时输出ls，那结果就和预想的不一样了；
因此创建一个List叫result，在ls遇到重复的字符的时候判断一下，result.count是否小等于ls.count，是的话才把ls赋值给result；
最后输出result就行。

LeetCode大佬还是厉害啊..
*/