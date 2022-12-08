/*
144. Binary Tree Preorder Traversal
Link: https://leetcode.com/problems/binary-tree-preorder-traversal/

Given the root of a binary tree, return the preorder traversal of its nodes' values.
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
    public List<Integer> preorderTraversal(TreeNode root) {
        List<Integer> elements = new ArrayList<>();
        preorderTraversal(root, elements);
        return elements;
    }
    
    private void preorderTraversal(TreeNode root, List<Integer> elements) {
        if (root == null) return;
        elements.add(root.val);
        preorderTraversal(root.left, elements);
        preorderTraversal(root.right, elements);
    }
}