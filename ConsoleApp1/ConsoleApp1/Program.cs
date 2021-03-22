using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return AddTwo(Get_list_from_listnode(l1,""), Get_list_from_listnode(l2,""))[0];
        }

        public string Get_list_from_listnode(ListNode l, string sum)
        {
            string z = l.val.ToString();

            sum += z;

            if (l.next != null)
                return Get_list_from_listnode(l.next, sum);

            return sum;
        }

        public List<ListNode> AddTwo(string l1, string l2)
        {
            int count = 0;

            int max_l = 0;

            if (l1.Length > l2.Length)
                max_l = l1.Length;
            else max_l = l2.Length;

            string integer = "";
            int g = 0;

            for (int i = 0; i < max_l; i++)
            {
                int helper = 0;

                helper += g;
                g = 0;

                if (i < l1.Length)
                    helper += Convert.ToInt32(l1[i].ToString());
                if (i < l2.Length)
                    helper += Convert.ToInt32(l2[i].ToString());

                if (helper > 9)
                {
                    g = Convert.ToInt32(helper.ToString()[0].ToString());
                    integer += helper.ToString()[1].ToString();
                }
                else
                {
                    g = 0;
                    integer += helper.ToString()[0].ToString();
                }

                if (i == max_l-1 && g != 0)
                    integer += g;
            }

            return Get_list(integer);
        }

        public List<ListNode> Get_list(string sum)
        {
            List<ListNode> Third = new List<ListNode>();
            
            Third.Add(new ListNode
            {
                val = Convert.ToInt32(sum[0].ToString())
            });

            for (int i = 1; i < sum.Length; i++)
            {
                Third.Add(new ListNode
                {
                    val = Convert.ToInt32(sum[i].ToString())
                });

                Third[i - 1].next = Third[i];
            }

            return Third;
        }

        public string Get_sum(List<ListNode> lists)
        {
            string s = "";
            for (int j = lists.Count - 1; j > -1; j--)
            {
                s += lists[j].val;
            }

            return s;
        }
    }

    public class ListNode
    {
        public int val;

        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
