"""
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
"""

# Definition for singly-linked list.
# class ListNode(object):
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution(object):
    def swapPairs(self, head):
        """
        :type head: ListNode
        :rtype: ListNode
        """

        if (not head or not head.next):
            return head

        start = head.next
        prev = None

        # check if we have elements to swap
        while (head and head.next):
            next_node = head.next
            head.next = next_node.next
            next_node.next = head
            
            if (prev): prev.next = next_node
            prev = head

            head = head.next
            

        return start
        