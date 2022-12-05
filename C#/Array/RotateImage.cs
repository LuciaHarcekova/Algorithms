/*
48. Rotate Image
Link: https://leetcode.com/problems/rotate-image/

You are given an n x n 2D matrix representing an image, rotate
the image by 90 degrees (clockwise).

You have to rotate the image in-place, which means you have to modify
the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.
*/

public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        for (int row=0; row<n/2; row++){
            for (int col=row; col<n-row-1; col++){
                int tmp = matrix[row][col];
                matrix[row][col] = matrix[n-col-1][row];
                matrix[n-col-1][row] = matrix[n-row-1][n-col-1];
                matrix[n-row-1][n-col-1] = matrix[col][n-row-1];
                matrix[col][n-row-1] = tmp;
            }
        }
    }
}