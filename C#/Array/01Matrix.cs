/*
542. 01 Matrix
Link: https://leetcode.com/problems/01-matrix/

Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.
The distance between two adjacent cells is 1.

Example 1:
Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
Output: [[0,0,0],[0,1,0],[0,0,0]]

Example 2:
Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
Output: [[0,0,0],[0,1,0],[1,2,1]]
*/

public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        if (mat == null || mat.Length == 0 || mat[0].Length == 0)
            return new int[0][];

        int m = mat.Length, n = mat[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int MAX_VALUE = m * n;
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 0) {
                    queue.Enqueue((i, j));
                } else {
                    mat[i][j] = MAX_VALUE;
                }
            }
        }
        
        (int, int)[] directions = {(1, 0), (-1, 0), (0, 1), (0, -1)};
        
        while (queue.Count > 0) {
            (int row, int col) = queue.Dequeue();
            foreach (var (dr, dc) in directions) {
                int r = row + dr, c = col + dc;
                if (r >= 0 && r < m && c >= 0 && c < n && mat[r][c] > mat[row][col] + 1) {
                    queue.Enqueue((r, c));
                    mat[r][c] = mat[row][col] + 1;
                }
            }
        }
        
        return mat;
    }
}