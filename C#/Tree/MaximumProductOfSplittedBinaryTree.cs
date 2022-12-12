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
and 10. Their product is 110 (11*10)

Input: root = [1,null,2,3,4,null,null,5,6]
Output: 90
Explanation: Remove the red edge and get 2 binary trees with sum 15
and 6.Their product is 90 (15*6)

Similar problem:
Find natural numbers x and y to maximize x*y, where x+y=10. The best
option is to pick x = y = 5. If x+y=11, then best split is 5 and 6.

Approach: 
Traverse the tree once, store all subtree sums and pick best split,
which is closest to half of the tree sum.

Sources:
https://www.tutorialcup.com/leetcode-solutions/maximum-product-of-splitted-binary-tree-leetcode-solution.htm
*/

