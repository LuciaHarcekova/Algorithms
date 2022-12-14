"""
931. Minimum Falling Path Sum
Link: https://leetcode.com/problems/minimum-falling-path-sum/

Given an n x n array of integers matrix, return the minimum sum of
any falling path through matrix.

A falling path starts at any element in the first row and chooses
the element in the next row that is either directly below or diagonally
left/right. Specifically, the next element from position (row, col)
will be (row + 1, col - 1), (row + 1, col), or (row + 1, col + 1).
"""

class Solution(object):
    def minFallingPathSum(self, matrix):
        """
        :type matrix: List[List[int]]
        :rtype: int
        """
        if (not matrix): return 0

        m = len(matrix[0])
        min_index = 0

        for column in range(1, m):
            if (matrix[0][min_index] > matrix[0][column]):
                min_index = column

        min_sum = matrix[0][min_index]
        for row in range(1, len(matrix)):
            tmp = matrix[row][min_index]
            for i in (-1, 0, 1):
                if (min_index+i >= 0 and min_index+i < m and tmp > matrix[row][min_index+i]):
                    tmp = matrix[row][min_index+i]
                    min_index = min_index+i
            min_sum += tmp

        return min_sum