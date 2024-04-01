/*
24. Swap Nodes in Pairs
Link: https://leetcode.com/problems/swap-nodes-in-pairs/description/

Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without
modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)

Example 1:
Input: head = [1,2,3,4]
Output: [2,1,4,3]

Example 2:
Input: head = []
Output: []

Example 3:
Input: head = [1]
Output: [1]
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
    public ListNode SwapPairs(ListNode head) {
        if (head != null && head.next != null){
            ListNode nextNode = head.next;
            head.next = SwapPairs(nextNode.next);
            nextNode.next = head;
            return nextNode;
        }

        return head;
    }
}