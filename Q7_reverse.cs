/// <summary>
/// 题目
/// </summary>
/*给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。

示例 1:

输入: 123
输出: 321
 示例 2:

输入: -123
输出: -321
示例 3:

输入: 120
输出: 21
注意:

假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−231,  231 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/reverse-integer
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。*/


namespace LeetCodeDemo
{
/*
    这题比较简单，也很好理解。
    我看到题目的第一个想法是通过转换成字符串，然后遍历翻转，然后输出成int。
    但是这肯定不是最优解，然后我看了一下答案，可以直接通过数学运算得到结果。
    然而是要判断溢出的，这个是没有考虑的点...
    太菜了
*/
    class Q7_Reverse
    {
        public  int Sulution_Reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                //判断溢出
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
                if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }
    }
}
