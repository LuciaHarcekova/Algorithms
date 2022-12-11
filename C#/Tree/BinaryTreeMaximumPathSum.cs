/*
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
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    int max = Int32.MinValue;

    public int MaxPathSum(TreeNode root) {
        CalculateSum(root);
        return max;
    }
    
    public int CalculateSum(TreeNode node) {
        if (node == null) return 0;
        int left_sum = CalculateSum(node.left);
        int right_sum = CalculateSum(node.right);
        int max_single_path = Math.Max(node.val + Math.Max(left_sum, right_sum), node.val);
        max = Math.Max(max, Math.Max(max_single_path, node.val + left_sum + right_sum));
        return max_single_path;
    }
}