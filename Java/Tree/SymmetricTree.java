/*
101. Symmetric Tree
Link: https://leetcode.com/problems/symmetric-tree/

Given the root of a binary tree, check whether it is a mirror of itself
(i.e., symmetric around its center).
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    public boolean isSymmetric(TreeNode root) {
        if (root==null) return true;
        return compare(root.left, root.right);
    }

    public boolean compare(TreeNode left, TreeNode right){
        if (left != null && right != null)
            return left.val==right.val && compare(left.left, right.right) && compare(left.right, right.left);
        
        return left==right;
    }
}