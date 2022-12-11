"""
124. Binary Tree Maximum Path Sum
Link: https://leetcode.com/problems/binary-tree-maximum-path-sum/

A path in a binary tree is a sequence of nodes where each pair of adjacent
nodes in the sequence has an edge connecting them. A node can only appear
in the sequence at most once. Note that the path does not need to pass
through the root.

The path sum of a path is the sum of the node's values in the path.

Given the root of a binary tree, return the maximum path sum of any non-empty path.

Example:
Input: root = [1,2,3]
Output: 6
Explanation: The optimal path is 2 -> 1 -> 3 with a path sum of 2 + 1 + 3 = 6.
"""

# Definition for a binary tree node.
# class TreeNode(object):
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution(object):
    
    maximum = float('-inf')

    def maxPathSum(self, root):
        """
        :type root: TreeNode
        :rtype: int
        """
        self.calculate_sum(root)
        return self.maximum
    
    def calculate_sum(self, node):
        if not node: return 0
        left_sum, right_sum = self.calculate_sum(node.left), self.calculate_sum(node.right)
        max_single_path = max(
            node.val + max(left_sum, right_sum),
            node.val)
        self.maximum = max(
            self.maximum,
            max_single_path,
            node.val + left_sum + right_sum)
        return max_single_path