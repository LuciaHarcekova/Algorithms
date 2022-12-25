"""
790. Domino and Tromino Tiling
Link: https://leetcode.com/problems/domino-and-tromino-tiling/

You have two types of tiles: a 2 x 1 domino shape and a tromino
shape. You may rotate these shapes.

Given an integer n, return the number of ways to tile an 2 x n board.
Since the answer may be very large, return it modulo 10^9 + 7.

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
"""

class Solution(object):
    def numTilings(self, n):
        """
        :type n: int
        :rtype: int
        """
        MOD = 10**9 + 7
        a, b, c = 1, 1, 2
        for i in range(2, n+1):
            tmp = a
            a = b
            b = c
            c = (2*b + tmp) % MOD

        return b