/*
79. Word Search
Link: https://leetcode.com/problems/word-search/description/

Given an m x n grid of characters board and a string word, return true if word exists
in the grid.

The word can be constructed from letters of sequentially adjacent cells, where adjacent
cells are horizontally or vertically neighboring. The same letter cell may not be used
more than once.

Example 1:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true

Example 2:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
Output: true

Example 3:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
Output: false
*/

public class Solution {
    public bool Exist(char[][] board, string word) {
        int m = board.Length;
        int n = board[0].Length;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                    if (Backtrack(board, word, i, j, 0)) return true;
            }
        }
        
        return false;
    }

    private bool Backtrack(char[][] board, String word, int i, int j, int index) {
       if (index == word.Length) {
            return true;
        }
        
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != word[index]) {
            return false;
        }
        
        char tmp = board[i][j];
        board[i][j] = ' ';
        
        if (Backtrack(board, word, i + 1, j, index + 1) ||
            Backtrack(board, word, i - 1, j, index + 1) ||
            Backtrack(board, word, i, j + 1, index + 1) ||
            Backtrack(board, word, i, j - 1, index + 1)) {
            return true;
        }
        
        board[i][j] = tmp;
        return false;
    }
}