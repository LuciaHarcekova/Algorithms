/*
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
    public int MaxAncestorDiff(TreeNode root) {
        if (root == null) return 0;
        int maxDiff = maxDifference(root, root.val, root.val);
        return maxDiff;
    }

    public int maxDifference(TreeNode root, int max, int min){
        if (root == null){
            return max - min;
        }
        max = Math.Max(root.val, max);
        min = Math.Min(root.val, min);

        return Math.Max(
            maxDifference(root.left, max, min),
            maxDifference(root.right, max, min)
        );
    }
}