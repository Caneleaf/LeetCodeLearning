namespace LeetCodeDemo
{
    //题目中的节点类
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class Q2_AddTwoNumbers
    {
        public ListNode Soulution_AddTwoSum(ListNode l1,ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);

            //由于直接把对象赋值，所以输出的dummyHead和curr所指向的地址是一样的
            ListNode p = l1, q = l2, curr = dummyHead;

            //控制进位，进位只可能是0或1
            int carry = 0;

            while (p!=null||q!=null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }
    }
}
/*
 * 解题过程：
 * 
 * 最开始把ListNode直接理解成了List，想了半天怎么直接实例化一个List对象进行运算操作；
 * 后来想不出来有啥子办法，就直接看答案了，这才知道是要一个一个节点实例化，然后通过Next控制各个节点的连接，组成一个链表的；
 * 
 * 我想着用数组做应该差不多？不过数组是顺序结构不是链式的，存储上应该有差别，主要通过数组下标来替代链表中的Next吧
 * 刚开始刷很不理想..啧
 * 原题地址：https://leetcode-cn.com/problems/add-two-numbers/
 * 
 *    这是Main方法，输出语句中result.next.next.next是判断是否还有进位，输出结果是8 9 0 1。
 *    
 *         static void Main(string[] args)
        {
            ListNode l1 = new ListNode(9);
            ListNode l2 = new ListNode(9);
            ListNode l3 = new ListNode(9);
            l1.next = l2;
            l2.next = l3;

            ListNode l4 = new ListNode(9);
            ListNode l5 = new ListNode(9);
            l4.next = l5;

            Q2_AddTwoNumbers q2 = new Q2_AddTwoNumbers();
            ListNode result = q2.Soulution_AddTwoSum(l1, l4);
            Console.WriteLine(result.val + " " + result.next.val + " " + result.next.next.val + " " + result.next.next.next.val);

        }
 * 
 */
