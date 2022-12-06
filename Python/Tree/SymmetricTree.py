"""
101. Symmetric Tree
Link: https://leetcode.com/problems/symmetric-tree/

Given the root of a binary tree, check whether it is a mirror of itself
(i.e., symmetric around its center).
"""

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def isSymmetric(self, root: Optional[TreeNode]) -> bool:
        if (root.left or root.right):
            return self.compare(root.left, root.right)
        return True

    def compare(self, left: Optional[TreeNode], right: Optional[TreeNode]) -> bool:
        if (left and right): 
            return left.val == right.val and self.compare(left.left, right.right) and self.compare(right.left, left.right)
        return left is right