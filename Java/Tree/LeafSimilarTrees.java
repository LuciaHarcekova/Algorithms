/*
872. Leaf-Similar Trees
Link: https://leetcode.com/problems/leaf-similar-trees/

Consider all the leaves of a binary tree, from left to right order, the values
of those leaves form a leaf value sequence.

For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).
Two binary trees are considered leaf-similar if their leaf value sequence is the same.
Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.
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
    public boolean leafSimilar(TreeNode root1, TreeNode root2) {
        List<Integer> root1Leaves = new ArrayList<Integer>();
        getLeaves(root1, root1Leaves);

        List<Integer> root2Leaves = new ArrayList<Integer>();
        getLeaves(root2, root2Leaves);

        return root1Leaves.equals(root2Leaves);
    }

    public static void getLeaves(TreeNode root, List<Integer> leaves) {   
        if (root.left == null && root.right == null)
            leaves.add(root.val);
        if (root.left != null)
            getLeaves(root.left, leaves);
        if (root.right != null)
            getLeaves(root.right, leaves);
    }
}