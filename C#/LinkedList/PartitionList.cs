/*
86. Partition List
Link: https://leetcode.com/problems/partition-list/

Given the head of a linked list and a value x, partition it such that all
nodes less than x come before nodes greater than or equal to x.
You should preserve the original relative order of the nodes in each of the two partitions.

Example 1:
Input: head = [1,4,3,2,5,2], x = 3
Output: [1,2,2,4,3,5]

Example 2:
Input: head = [2,1], x = 2
Output: [1,2]
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        ListNode beforeHead = new ListNode(0);
        ListNode afterHead = new ListNode(0);
        ListNode beforeCurr = beforeHead;
        ListNode afterCurr = afterHead;

        // Iterate through the list
        while (head != null){
            // Compare to which list place the element
            if (head.val < x){
                beforeCurr.next = head;
                beforeCurr = beforeCurr.next;
            } else {
                afterCurr.next = head;
                afterCurr = afterCurr.next;
            }
            // Move in the list
            head = head.next;
        }

        // Cnnect the result lists
        afterCurr.next = null;
        beforeCurr.next = afterHead.next;

        return beforeHead.next;
    }
}