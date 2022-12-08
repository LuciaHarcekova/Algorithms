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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        List<int> root1Leaves = new List<int>();
        _GetLeaves(root1, root1Leaves);
        List<int> root2Leaves = new List<int>();
        _GetLeaves(root2, root2Leaves);
        return root1Leaves.SequenceEqual(root2Leaves);
        
    }

    private void _GetLeaves(TreeNode root,  List<int> leaves){
        if (root.left == null && root.right == null)
            leaves.Add(root.val);
        if (root.left != null)
            _GetLeaves(root.left, leaves);
        if (root.right != null)
            _GetLeaves(root.right, leaves);
    }
}