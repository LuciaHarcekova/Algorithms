"""
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
"""

class Solution(object):
    def exist(self, board, word):
        """
        :type board: List[List[str]]
        :type word: str
        :rtype: bool
        """
        
        def backtrack(i, j, word_pos):
            if word_pos == len(word):
                return True
            
            if i<0 or i>=len(board) or j<0 or j>=len(board[0]) or board[i][j] != word[word_pos]:
                return False
            
            temp = board[i][j]
            board[i][j] = ''
            word_pos += 1

            if backtrack(i+1, j, word_pos) or backtrack(i-1, j, word_pos) or backtrack(i, j+1, word_pos) or backtrack(i, j-1, word_pos):
                return True
            
            board[i][j] = temp

            return False
        
        for i in range (len(board)):
            for j in range(len(board[0])):
                if backtrack(i, j, 0):
                    return True
        
        return False