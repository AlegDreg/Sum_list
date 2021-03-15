using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static public List<ListNode> fir_list { get; private set; }
        static public List<ListNode> Sec_list { get; private set; }
        static public List<ListNode> Third { get; private set; }

        static void Main(string[] args)
        {
            fir_list = new List<ListNode>();
            Sec_list = new List<ListNode>();
            Third = new List<ListNode>();

            Console.Write("Введите l1 = ");
            string s1 = Delete_non_correct_items(Console.ReadLine().Replace(" ",""));

            Console.Write("\nВведите l2 = ");
            string s2 = Delete_non_correct_items(Console.ReadLine().Replace(" ",""));

            if(s1=="" || s2 =="")
            {
                Console.WriteLine("Некорректные значения!\n");
                Main(args);
                return;
            }

            Add_elements(s1.Split(new char[] { ',' }), fir_list);

            Add_elements(s2.Split(new char[] { ',' }), Sec_list);

            AddTwoNombers(fir_list, Sec_list);

            Print(Third);

            Console.ReadKey();
        }

        static string Delete_non_correct_items(string line)
        {
            string[] k = line.Split(new char[] { ',' });

            string lines = "";

            for (int s = 0; s < k.Length; s++)
            {
                int it;

                bool z = Int32.TryParse(k[s], out it);

                if (z && it >=0 && it < 10)
                {
                    lines += k[s] + ",";
                }
            }
            bool isUnc = false;

            if (lines[lines.Length - 1] == ',')
            {
                lines = lines.Remove(lines.Length - 1);
                isUnc = true;
            }

            if(lines[0] == '0')
            {
                lines = lines.Remove(0,2);
                isUnc = true;
            }

            if (isUnc)
                Console.WriteLine("Были удалены некорректные значения! Полученная строка - " + lines+"\n");

            if (lines.Length > 199)
                return "";

            return lines;
                
        }

        static void Print(List<ListNode> lists)
        {
            Console.Write("Вывод - ");
            foreach (ListNode list in lists)
            {
                Console.Write(list.val + " ");
            }

        }

        static void Add_elements(string[] mas, List<ListNode> list)
        {
            for (int l = 0; l < mas.Length; l++)
            {
                if (!isCorrect_item(mas[l]))
                    continue;

                list.Add(new ListNode
                {
                    val = Convert.ToInt32(mas[l])
                });

                if (l > 0)
                {
                    list[list.Count - 2].next = list[list.Count - 1];
                }
            }
        }

        static bool isCorrect_item(string item)
        {
            if (item == "" || Convert.ToInt32(item) < 0 || Convert.ToInt32(item) > 9)
                return false;
            else return true;
        }

        static void AddTwoNombers(List<ListNode> l1, List<ListNode> l2)
        {
            string one = Get_sum(l1);
            string two = Get_sum(l2);

            int z = Convert.ToInt32(one) + Convert.ToInt32(two);

            Console.WriteLine($"Сумма - ({z})");

            string v = "";
            int count = 0;

            if (z != 0)
            {
                while (z > 0)
                {
                    count++;
                    int k = z % 10;
                    v += k;
                    z = (z - z % 10) / 10;

                    Third.Add(new ListNode
                    {
                        val = Convert.ToInt32(k)
                    });

                    if (count > 1)
                    {
                        Third[Third.Count - 2].next = Third[Third.Count - 1];
                    }
                }
            }
            else
            {
                Third.Add(new ListNode
                {
                    val = 0
                });
            }
        }

        static string Get_sum(List<ListNode> lists)
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
