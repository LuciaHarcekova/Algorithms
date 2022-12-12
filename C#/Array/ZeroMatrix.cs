/*
1.8 Zero Matrix
Link: https://www.crackingthecodinginterview.com

Write an algorithm such that if an element in an MxN
matrix is 0, its entire row and column are set to 0.

Approaches:
- iterate through the matrix and and save rows and columns where
  is 0, then set them to zeros. 

2d array:
int[ , ] m = { 
    { 1, 2 ,3},
    { 3, 0, 5 } , 
    { 1, 2 ,3},
    { 0, 4, 2 } 
};
*/

public class Solution {

    public static void SetZeros(int[,] matrix, int n, int m) {    

        // store 0 for rows and columns
        bool[] row = new bool[n];
        bool[] column = new bool[m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m;j++){
                if (matrix[i,j] == 0) {
                    row[i] = true;
                    column[j] = true;
                }
            }
        }

        // Nullify rows
        for (int i = 0; i < n; i++) {
            if (row[i]) NullifyRow(matrix, i, m);
        }

        // Nullify columns
        for (int j = 0; j < m; j++) {
            if (column[j]) NullifyColumn(matrix, j, n);
        }
    }

    public static void NullifyRow(int[,] matrix, int row, int m) {
        for (int j = 0; j < m; j++) {
            matrix[row, j] = 0;
        }
    }

    public static void NullifyColumn(int[,] matrix, int col, int n) {
        for (int i = 0; i < n; i++) {
            matrix[i, col] = 0;
        }
    }
}