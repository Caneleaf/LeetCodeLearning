/// <summary>
/// 题目：判断是否是回文数
/// </summary>
/*
判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。

示例 1:

输入: 121
输出: true
示例 2:

输入: -121
输出: false
解释: 从左向右读, 为 -121 。 从右向左读, 为 121- 。因此它不是一个回文数。
示例 3:

输入: 10
输出: false
解释: 从右向左读, 为 01 。因此它不是一个回文数。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/palindrome-number
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/
namespace LeetCodeDemo
{
    class Q9_IsPalindrome
    {
        /*
        做了5、7、8这几题，这题就很好做了
        题目要求，负数不能为回文，那直接判断参数是不是负数，是负数就直接返回；
        不是负数，把参数用数学方法（这里主要是第七题的思路）
        也可以转换成字符串来解答（第五题思路：中心扩散，暴力遍历判断回文，马拉车算法[还是不会..只模模糊糊懂一点，希望以后理解会深一些]）
        确实是简单题
        */
        public bool Sulution1_IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            int parameter = x;
            int result = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && pop > 7)) return false;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && pop < -8)) return false;
                result = result * 10 + pop;
            }

            return (result == parameter);
        }
    }
}
