/// <summary>
/// 题目
/// </summary>
/// 
/*
 * 将一个给定字符串根据给定的行数，以从上往下、从左到右进行 Z 字形排列。
比如输入字符串为 "LEETCODEISHIRING" 行数为 3 时，排列如下：

L C   I R
E T O E S I I G
E D   H N
之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："LCIRETOESIIGEDHN"。

请你实现这个将字符串进行指定行数变换的函数：

string convert(string s, int numRows);
示例 1:

输入: s = "LEETCODEISHIRING", numRows = 3
输出: "LCIRETOESIIGEDHN"
示例 2:

输入: s = "LEETCODEISHIRING", numRows = 4
输出: "LDREOEIIECIHNTSG"
解释:

L D     R
E   O E   I I
E C   I H   N
T     S G

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/zigzag-conversion
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/

using System;
using System.Collections.Generic;
using System.Text;

/*
 static void Main(string[] args)
{
    Q6_Convert q = new Q6_Convert();
    Console.WriteLine(q.Sulution2_Convert("LEETCODEISHIRING", 3));

}
*/
namespace LeetCodeDemo
{
    class Q6_Convert
    {
        /*         
        官方解法1：
        由于是Z字走向，添加的方向只有两个，通过一个bool类型的变量来控制添加的字符串的方向，
        当当前添加的行为第一行或者最后一行的时候，改变方向，最后依次读取每一行的内容。
        */
        public string Sulution1_Convert(string s, int numRows)
        {
            if (numRows == 1) return s;//如果行数为一，直接返回字符串

            List<StringBuilder> sbList = new List<StringBuilder>();
            //为了防止字符串长度小于行数的特殊情况， 取行数和s的长度中最小的来初始化list.
            for (int i = 0; i < Math.Min(s.Length, numRows); i++)
            {
                StringBuilder sb = new StringBuilder();
                sbList.Add(sb);
            }

            int currRow = 0;//当前的行数
            bool goDown = false;//z字形 行进的方向
            //遍历s，将s[i]添加到合适的行里
            for (int i = 0; i < s.Length; i++)
            {
                sbList[currRow].Append(s[i]);
                //如果当前行数为第一行或最后一行，z字形 行进的方向应该改变，所以给goDowm取反
                if (currRow == 0 || currRow == numRows - 1) goDown = !goDown;

                //将当前行currRow+1或-1，保证下次循环可将数据存到正确的行里
                currRow += goDown ? 1 : -1;
            }
            //到此，sbList[0]中存的为z字形排列的第一行数据，sbList[1]中存的为z字形排列的第二行数据，以此类推。。。将所有拼接，即为结果
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < sbList.Count; i++)
            {
                result.Append(sbList[i]);
            }
            return result.ToString();

        }

        /*

        官方解法2：
        其实就是找规律了，cycleLen控制列的添加，
        result+=s[j+cyclelen-i]控制两列中间的数的添加;
        */
        public string Sulution2_Convert(string s, int numRows)
        {
            string result = "";
            if (numRows == 1) return s;
            int len = s.Length;
            int cycleLen = (2 * numRows) - 2;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j + i < len; j += cycleLen)
                {
                    //这里是添加列
                    result += s[j + i];

                    //这是添加两列之间的数
                    if (i != 0 && i != numRows - 1 && j + cycleLen - i < len)
                    {
                        result += s[j + cycleLen - i];
                    }
                }
            }
            return result;
        }
    }
}
