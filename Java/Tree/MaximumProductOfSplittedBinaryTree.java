/*
1339. Maximum Product of Splitted Binary Tree
Link: https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/

Given the root of a binary tree, split the binary tree into two
subtrees by removing one edge such that the product of the sums
of the subtrees is maximized.

Return the maximum product of the sums of the two subtrees. Since
the answer may be too large, return it modulo 109 + 7.

Note that you need to maximize the answer before taking the mod and
not after taking it.

Examle:
Input: root = [1,2,3,4,5,6]
Output: 110
Explanation: Remove the red edge and get 2 binary trees with sum 11
and 10. Their product is 110 (11*10).

Input: root = [1,null,2,3,4,null,null,5,6]
Output: 90
Explanation: Remove the red edge and get 2 binary trees with sum 15
and 6.Their product is 90 (15*6).

Similar problem:
Find natural numbers x and y to maximize x*y, where x+y=10. The best
option is to pick x = y = 5. If x+y=11, then best split is 5 and 6.

Approach: 
Traverse the tree once, store all subtree sums and pick best split,
which is closest to half of the tree sum.

Sources:
https://www.tutorialcup.com/leetcode-solutions/maximum-product-of-splitted-binary-tree-leetcode-solution.htm
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
    HashSet<long> hashSet = new HashSet<long>();
    public int MaxProduct(TreeNode root) 
    {
        long sum = TreeSum(root);
        long max = 0;
        foreach(var num in hashSet)
            max = Math.Max(max, (sum - num) * num);
        return (int) (max % 1_000_000_007);
    }
    
    private long TreeSum(TreeNode root)
    {
        if(root == null) return 0;
        long sum = root.val + TreeSum(root.left) + TreeSum(root.right);
        hashSet.Add(sum);
        return sum;
    }
}