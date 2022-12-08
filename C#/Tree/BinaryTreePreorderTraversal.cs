/*
144. Binary Tree Preorder Traversal
Link: https://leetcode.com/problems/binary-tree-preorder-traversal/

Given the root of a binary tree, return the preorder traversal of its nodes' values.
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
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> elements = new List<int>();
        preorderTraversal(root, elements);
        return elements;
    }
    
    private void preorderTraversal(TreeNode root, List<int> elements) {
        if (root == null) return;
        elements.Add(root.val);
        preorderTraversal(root.left, elements);
        preorderTraversal(root.right, elements);
    }
}