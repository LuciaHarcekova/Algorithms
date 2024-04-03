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

class Solution {
    public boolean exist(char[][] board, String word) {
        int m = board.length;
        int n = board[0].length;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                    if (backtrack(board, word, i, j, 0)) return true;
            }
        }
        
        return false;
    }

    private boolean backtrack(char[][] board, String word, int i, int j, int index) {
       if (index == word.length()) {
            return true;
        }
        
        if (i < 0 || i >= board.length || j < 0 || j >= board[0].length || board[i][j] != word.charAt(index)) {
            return false;
        }
        
        char tmp = board[i][j];
        board[i][j] = ' ';
        
        if (backtrack(board, word, i + 1, j, index + 1) ||
            backtrack(board, word, i - 1, j, index + 1) ||
            backtrack(board, word, i, j + 1, index + 1) ||
            backtrack(board, word, i, j - 1, index + 1)) {
            return true;
        }
        
        board[i][j] = tmp;
        return false;
    }
}