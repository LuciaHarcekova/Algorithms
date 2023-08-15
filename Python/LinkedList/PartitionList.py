"""
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
"""

# Definition for singly-linked list.
# class ListNode(object):
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution(object):
    def partition(self, head, x):
        """
        :type head: ListNode
        :type x: int
        :rtype: ListNode
        """
        beforeHead = ListNode(0) 
        afterHead = ListNode(0)
        beforeCurr = beforeHead;
        afterCurr = afterHead

        while head:
            if head.val < x:
                beforeCurr.next, beforeCurr = head, head
            else:
                afterCurr.next, afterCurr = head, head
            head = head.next
        
        afterCurr.next = None
        beforeCurr.next = afterHead.next
        
        return beforeHead.next
