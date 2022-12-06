/*
101. Symmetric Tree
Link: https://leetcode.com/problems/symmetric-tree/

Given the root of a binary tree, check whether it is a mirror of itself
(i.e., symmetric around its center).
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
    public bool IsSymmetric(TreeNode root)
    {
        if (root == null) return true;
        return Compare(root.left, root.right);
    }

    private bool Compare(TreeNode left, TreeNode right)
    {
        if (left != null && right != null)
            return left.val == right.val && Compare(left.left, right.right) && Compare(left.right, right.left);
        return left == right;
    }
}