using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class Solutions
    {
        //* Definition for singly-linked list.
        public class ListNode
        {
            public int val; public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        //highest speed
        public class Solution
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {

                ListNode head = new ListNode();
                ListNode newList = head;

                while (list1 != null && list2 != null)
                {
                    if (list1.val <= list2.val)
                    {
                        newList.next = new ListNode(list1.val);
                        list1 = list1.next;
                    }
                    else
                    {
                        newList.next = new ListNode(list2.val);
                        list2 = list2.next;
                    }
                    newList = newList.next;
                }

                while (list1 != null)
                {
                    newList.next = new ListNode(list1.val);
                    list1 = list1.next;
                    newList = newList.next;
                }

                while (list2 != null)
                {
                    newList.next = new ListNode(list2.val);
                    list2 = list2.next;
                    newList = newList.next;
                }
                return head.next;
            }

            //least memory

            //public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            //{
            //    var root = new ListNode();
            //    var node = root;

            //    while (list1 != null && list2 != null)
            //    {
            //        if (list1.val <= list2.val)
            //        {
            //            node.next = new ListNode(list1.val);
            //            list1 = list1.next;
            //        }
            //        else
            //        {
            //            node.next = new ListNode(list2.val);
            //            list2 = list2.next;
            //        }

            //        node = node.next;
            //    }
            //    if (list1 != null)
            //    {
            //        node.next = list1;
            //    }
            //    else
            //    {
            //        node.next = list2;
            //    }

            //    GC.Collect();
            //    return root.next;
            //}
        }
    }
}
