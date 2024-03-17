"""
110. Balanced Binary Tree
Link: https://leetcode.com/problems/balanced-binary-tree/description/

Given a binary tree, determine if it is height-balanced.

A height-balanced binary tree is a binary tree in which the depth of the two
subtrees of every node never differs by more than one.

Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: true

Example 2:
Input: root = [1,2,2,3,3,null,null,4,4]
Output: false

Example 3:
Input: root = []
Output: true
 
Constraints:
The number of nodes in the tree is in the range [0, 5000].
-104 <= Node.val <= 104
"""

# Definition for a binary tree node.
# class TreeNode(object):
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution(object):
    def isBalanced(self, root):
        """
        :type root: TreeNode
        :rtype: bool
        """

        def height(root):

            if root is None:
                return 0

            height_left = height(root.left)
            height_right = height(root.right)

            if height_left == -1 or height_right == -1 or abs(height_left - height_right) > 1:
                return -1

            return 1 + max(height_left, height_right)
        
        return height(root) != -1
