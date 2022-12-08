"""
872. Leaf-Similar Trees
Link: https://leetcode.com/problems/leaf-similar-trees/

Consider all the leaves of a binary tree, from left to right order, the values
of those leaves form a leaf value sequence.

For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).
Two binary trees are considered leaf-similar if their leaf value sequence is the same.
Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.
"""

# Definition for a binary tree node.
# class TreeNode(object):
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution(object):
    def leafSimilar(self, root1, root2):
        """
        :type root1: TreeNode
        :type root2: TreeNode
        :rtype: bool
        """
        root1Leaves, root2Leaves = [], []
        self.getLeaves(root1, root1Leaves)
        self.getLeaves(root2, root2Leaves)
        return root1Leaves == root2Leaves
    
    def getLeaves(self, node, leaves):
        if node.left: self.getLeaves(node.left, leaves)
        if node.right: self.getLeaves(node.right, leaves)
        if not node.left and not node.right: leaves.append(node.val)
