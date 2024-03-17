"""
118. Pascal's Triangle
Link: https://leetcode.com/problems/pascals-triangle/description/

Given an integer numRows, return the first numRows of Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

Example 1:
Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]

Example 2:
Input: numRows = 1
Output: [[1]]
 
Constraints:
1 <= numRows <= 30
"""

class Solution(object):
    def generate(self, numRows):
        """
        :type numRows: int
        :rtype: List[List[int]]
        """
        if numRows == 0:
            return []
        if numRows == 1:
            return [[1]]

        previous_rows = self.generate(numRows-1)
        last_row = previous_rows[-1]
        current_row = [1]

        for i in range (1, numRows-1):
            current_row.append(last_row[i - 1] + last_row[i])

        current_row.append(1)
        previous_rows.append(current_row)

        return previous_rows
