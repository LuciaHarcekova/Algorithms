"""
100. Same Tree
Link: https://leetcode.com/problems/same-tree/

Given the roots of two binary trees p and q, write a function to check
if they are the same or not.
Two binary trees are considered the same if they are structurally identical,
and the nodes have the same value.

Example 1:
Input: p = [1,2,3], q = [1,2,3]
Output: true

Example 2:
Input: p = [1,2], q = [1,null,2]
Output: false

Example 3:
Input: p = [1,2,1], q = [1,1,2]
Output: false
"""

# Definition for a binary tree node.
# class TreeNode(object):
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution(object):
    def isSameTree(self, p, q):
        """
        :type p: TreeNode
        :type q: TreeNode
        :rtype: bool
        """
        if ((not p and q) or (not q and p)):
            return False
        return (not p and not q) or p.val == q.val and self.isSameTree(p.left, q.left) and self.isSameTree(p.right, q.right)