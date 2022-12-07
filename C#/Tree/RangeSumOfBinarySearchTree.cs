/*
938. Range Sum of BST
Link: https://leetcode.com/problems/range-sum-of-bst/

Given the root node of a binary search tree and two integers low and high,
return the sum of values of all nodes with a value in the inclusive range [low, high].
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
    public int RangeSumBST(TreeNode root, int low, int high) {
        if(root == null)
            return 0;
        if(root.val < low)
            return RangeSumBST(root.right, low, high);
        if(root.val > high)
            return RangeSumBST(root.left, low, high);
        return root.val + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
    }
}