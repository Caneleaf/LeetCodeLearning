/// <summary>
/// 题目:转换罗马数字
/// </summary>
/*罗马数字包含以下七种字符： I， V， X， L，C，D 和M。

字符 数值
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
例如， 罗马数字 2 写做 II，即为两个并列的 1。12 写做 XII，即为 X+ II 。 27 写做 XXVII, 即为XX + V + II 。

通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，所表示的数等于大数 5 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：

I 可以放在V(5) 和 X(10) 的左边，来表示 4 和 9。
X 可以放在L(50) 和 C(100) 的左边，来表示 40 和 90。 
C 可以放在D(500) 和 M(1000) 的左边，来表示 400 和 900。
给定一个整数，将其转为罗马数字。输入确保在 1 到 3999 的范围内。

示例 1:

输入: 3
输出: "III"
示例 2:

输入: 4
输出: "IV"
示例 3:

输入: 9
输出: "IX"
示例 4:

输入: 58
输出: "LVIII"
解释: L = 50, V = 5, III = 3.
示例 5:

输入: 1994
输出: "MCMXCIV"
解释: M = 1000, CM = 900, XC = 90, IV = 4.

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/integer-to-roman
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。*/



namespace LeetCodeDemo
{
    class Q12_IntToRoman
    {
        /*
           贪心算法,把特殊的情况也算进数组中，从高到低匹配和数相对应的罗马数字，添加到字符串中，然后减去数，并且循环这个过程
        核心在于把特殊的情况一并添加到数组中去，不用通过计算来考虑。
        */
        public string Sulution1_IntToRoman(int num)
        {
            int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int index = 0;
            string res = "";
            while (index < 13)
            {
                while (num >= nums[index])
                {
                    res += romans[index];
                    num -= nums[index];
                }
                index += 1;
            }
            return res;
        }

        /*
           通过除法和取模的算术方式来匹配罗马字符。算是一种暴力求解;
        其实这题的数量有限制，数字在1-4000之间浮动，数据量相对小，怎么解复杂度都看作O(1)
        */
        public string Sulution2_IntToRoman(int num)
        {
            char[] result = new char[15];
            char[] romans = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int i = 14, j = 0, m = 0;

            while (num != 0)
            {
                m = num % 10;
                num /= 10;
                while (true)
                {
                    if (m == 9) { result[i--] = romans[j + 2]; m = 1; }
                    else if (m == 8) { result[i--] = romans[j]; m--; }
                    else if (m == 7) { result[i--] = romans[j]; m--; }
                    else if (m == 6) { result[i--] = romans[j]; m--; }
                    else if (m == 5) { result[i--] = romans[j + 1]; break; }
                    else if (m == 4) { result[i--] = romans[j + 1]; m = 1; }
                    else if (m == 3) { result[i--] = romans[j]; m--; }
                    else if (m == 2) { result[i--] = romans[j]; m--; }
                    else if (m == 1) { result[i--] = romans[j]; break; }
                    else break;
                }
                j += 2;
            }
            string r = "";
            foreach (var item in result)
            {
                if (item == '\0') continue;
                r += item;
            }
            return r.Trim();
        }
    }
}
