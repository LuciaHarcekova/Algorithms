/*
1.8 Zero Matrix
Link: https://www.crackingthecodinginterview.com

Write an algorithm such that if an element in an MxN
matrix is 0, its entire row and column are set to 0.

Approaches:
- iterate through the matrix and and save rows and columns where
  is 0, then set them to zeros. 

2d array:
int m[][] = {
    {0,1,2,3},
    {1,1,2,1},
    {2,2,0,3},
    {3,3,2,3}
};
*/

class Solution {

    void setZeros(int[][] matrix) {

        // store 0 for rows and columns
        boolean[] row = new boolean[matrix.length];
        boolean[] column = new boolean[matrix[0].length];
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length;j++){
                if (matrix[i][j] == 0) {
                    row[i] = true;
                    column[j] = true;
                }
            }
        }

        // Nullify rows
        for (int i = 0; i < row.length; i++) {
            if (row[i]) nullifyRow(matrix, i);
        }

        // Nullify columns
        for (int j = 0; j < column.length; j++) {
            if (column[j]) nullifyColumn(matrix, j);
        }
    }

    void nullifyRow(int[][] matrix, int row) {
        for (int j = 0; j < matrix[0].length; j++) {
            matrix[row][j] = 0;
        }
    }

    void nullifyColumn(int[][] matrix, int col) {
        for (int i = 0; i < matrix.length; i++) {
            matrix[i][col] = 0;
        }
    }
}