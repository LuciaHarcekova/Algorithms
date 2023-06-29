/*
530. Minimum Absolute Difference in BST
Link: https://leetcode.com/problems/minimum-absolute-difference-in-bst/

Given the root of a Binary Search Tree (BST), return the minimum absolute difference
between the values of any two different nodes in the tree.

Example 1:
Input: root = [4,2,6,1,3]
Output: 1

Example 2:
Input: root = [1,0,48,null,null,12,49]
Output: 1
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

    int minDiff = int.MaxValue;
    TreeNode prev;

    public int GetMinimumDifference(TreeNode root) {
        _inorder(root);
        return this.minDiff;
    }

    private void _inorder(TreeNode node){
        if (node == null) return;
        _inorder(node.left);
        if (this.prev != null)
            this.minDiff =  Math.Min(this.minDiff, node.val - this.prev.val);
        this.prev = node;
        _inorder(node.right);
    }
}