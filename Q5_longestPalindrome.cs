/// <summary>
/// 题目
/// </summary>
/*
给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

示例 1：

输入: "babad"
输出: "bab"
注意: "aba" 也是一个有效答案。
示例 2：

输入: "cbbd"
输出: "bb"

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/longest-palindromic-substring
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/
namespace LeetCodeDemo
{
    /*    
     测试用例

      static void Main(string[] args)
    {
        Q5_longestPalindrome q5 = new Q5_longestPalindrome();
        string s = "abbccbbasa";
        string result = q5.Sulution2_longestPalindrome(s);
        Console.WriteLine(result);
    }
    */
    class Q5_longestPalindrome
    {
        /*        
        暴力解法，时间复杂度O(n^3)
        先遍历字符串，寻找s[i]=s[j]，那么s[i]到s[j]中间的字符串就*有可能*是回文。
        要判断子串是否是回文，则再循环，判断s[tmp1]==s[tmp2]，若是，则tmp1++,tmp2--（这是向子串内部遍历比较，判断是否是回文）
        直到tmp1>tmp2时，子串对比完毕，把自粗汉长度赋值给maxlen,然后输出
        由于用到三个嵌套循环，所以时间复杂度不太合适。
        */
        public string Sulution1_longestPalindrome(string s)
        {
            if (s == "") return s;
            int len = s.Length;
            int maxLen = 1;
            int start = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    int tmp1 = i, tmp2 = j;
                    while (tmp1 < tmp2 && s[tmp1] == s[tmp2])
                    {
                        tmp1++;
                        tmp2--;
                    }

                    if (tmp1 >= tmp2 && j - i + 1 > maxLen)
                    {
                        maxLen = j - i + 1;
                        start = i;
                    }
                }
            }

            return s.Substring(start, maxLen);
        }
        /*
        中心扩散法，时间复杂度O(n^2)
        遍历数组，设定s[i]为中心点，判断s[i-1]==s[i+1]（偶数子串的时候判断s[i]==s[i+1]）
        若相等，则为回文，一直判断到不为回文为止，并把长度给maxlen,起始位置给start，输出最长子串；
        */
        public string Sulution2_longestPalindrome(string s)
        {
            if (s == "") return s;
            int len = s.Length;
            int maxlen = 1;
            int start = 0;

            //单数
            for (int i = 0; i < len; i++)
            {
                int j = i - 1, k = i + 1;
                while (j >= 0 && k < len && s[j] == s[k])
                {
                    if (k - j + 1 > maxlen)
                    {
                        maxlen = k - j + 1;
                        start = j;
                    }
                    j--;
                    k++;
                }
            }

            //双数
            for (int i = 0; i < len; i++)
            {
                int j = i, k = i + 1;
                while (j >= 0 && k < len && s[j] == s[k])
                {
                    if (k - j + 1 > maxlen)
                    {
                        maxlen = k - j + 1;
                        start = j;
                    }
                    j--;
                    k++;
                }
            }
            return s.Substring(start, maxlen);
        }
    }
}
