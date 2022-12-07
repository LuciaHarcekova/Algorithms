/*
328. Odd Even Linked List
Link: https://leetcode.com/problems/odd-even-linked-list/

Given the head of a singly linked list, group all the nodes with odd indices together
followed by the nodes with even indices, and return the reordered list.

The first node is considered odd, and the second node is even, and so on.

Note that the relative order inside both the even and odd groups should remain as
it was in the input.

You must solve the problem in O(1) extra space complexity and O(n) time complexity.
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
    public ListNode OddEvenList(ListNode head) {
        if (head == null) return head;

        ListNode oddHead = new ListNode(0);
        ListNode odd = oddHead;
        ListNode evenHead = new ListNode(0);
        ListNode even = evenHead;    
        while (head != null) {
            // Assign values
            odd.next = head;
            even.next = head.next;
            // Proceed in list
            odd = odd.next;
            even = even.next;
            head = head.next != null ? head.next.next : null;
        }
        odd.next = evenHead.next;
        return oddHead.next;
    }
}