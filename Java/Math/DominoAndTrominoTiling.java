/*
790. Domino and Tromino Tiling
Link: https://leetcode.com/problems/domino-and-tromino-tiling/

You have two types of tiles: a 2 x 1 domino shape and a tromino
shape. You may rotate these shapes.

Given an integer n, return the number of ways to tile an 2 x n board.
Since the answer may be very large, return it modulo 109 + 7.

In a tiling, every square must be covered by a tile. Two tilings are
different if and only if there are two 4-directionally adjacent cells
on the board such that exactly one of the tilings has both squares
occupied by a tile. 

Example 1:
Input: n = 3
Output: 5
Explanation: The five different ways are explain in the link.

Example 2:
Input: n = 1
Output: 1

Approach:
Dynamic Programming
*/

class Solution {
    public int numTilings(int n) {
        int MOD = (int)(1e9) + 7;
        int a = 1, b = 1, c = 2;

        for (int i=2; i<n+1; i++) {
            int tmp = a;
            a = b;
            b = c;
            c = (2*b % MOD  + tmp) % MOD;
        }

        return b; 
    }
}