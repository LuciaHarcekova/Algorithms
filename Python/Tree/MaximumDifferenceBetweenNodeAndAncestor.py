"""
1026. Maximum Difference Between Node and Ancestor
Link: https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/

Given the root of a binary tree, find the maximum value v for which
there exist different nodes a and b where v = |a.val - b.val| and a is an ancestor of b.

A node a is an ancestor of b if either: any child of a is equal
to b or any child of a is an ancestor of b.

Example:
Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
Output: 7
Explanation: We have various ancestor-node differences, some of which are given below :
|8 - 3| = 5
|3 - 7| = 4
|8 - 1| = 7
|10 - 13| = 3
Among all possible differences, the maximum value of 7 is obtained by |8 - 1| = 7.

Approach:
The biggest difference would happen between a node's value and the max or min
of its ancestors. That's why we only need to keep track of the minimums and
maximums as we traverse the tree.
"""

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def maxAncestorDiff(self, root: Optional[TreeNode]) -> int:
        if (root): 
            return self.findMaxDiff(root, root.val, root.val)
        return 0
    
    def findMaxDiff(self, root: Optional[TreeNode], maximum:int, minimum:int) -> int:
        if (not root):
            return maximum - minimum
        maximum = max(maximum, root.val)
        minimum = min(minimum, root.val)
        return max(
                self.findMaxDiff(root.left, maximum, minimum),
                self.findMaxDiff(root.right, maximum, minimum));