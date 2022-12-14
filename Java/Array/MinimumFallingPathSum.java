/*
931. Minimum Falling Path Sum
Link: https://leetcode.com/problems/minimum-falling-path-sum/

Given an n x n array of integers matrix, return the minimum sum of
any falling path through matrix.

A falling path starts at any element in the first row and chooses
the element in the next row that is either directly below or diagonally
left/right. Specifically, the next element from position (row, col)
will be (row + 1, col - 1), (row + 1, col), or (row + 1, col + 1).
*/

class Solution {
    public int minFallingPathSum(int[][] matrix) {

        if (matrix == null) return 0;

        int n = matrix.length;
        int min_sum = Integer.MAX_VALUE;

        // edge case
        if (n == 1) return matrix[0][0];

        // go row by row and always check minimum path from previous row
        for (int i=1; i<n; i++) {
            for (int j=0; j<n; j++) {
                if (j == 0)
                    matrix[i][j] += Math.min(matrix[i-1][j], matrix[i-1][j+1]);
                else if (j == n-1)
                    matrix[i][j] += Math.min(matrix[i-1][j], matrix[i-1][j-1]);
                else
                    matrix[i][j] += Math.min(matrix[i-1][j], Math.min(matrix[i-1][j-1], matrix[i-1][j+1]));
                // in the last iteration we pick total sum minimum
                if (i == n - 1)
                    min_sum = Math.min(min_sum, matrix[i][j]);
            }
        }

        return min_sum;
    }
}