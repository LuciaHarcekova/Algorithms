/*
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
*/

public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> result = new List<IList<int>>();

        if (numRows == 0){
            return result;
        }

        if (numRows == 1) {
            List<int> firstRow = new List<int> {1};
            result.Add(firstRow);
            return result;
        }
        
        result = Generate(numRows - 1);
        IList<int> prevRow = result[numRows - 2];
        IList<int> currentRow =  new List<int> {1};

        for (int i = 1; i < numRows - 1; i++) {
            currentRow.Add(prevRow[i - 1] + prevRow[i]);
        }

        currentRow.Add(1);
        result.Add(currentRow);

        return result;
    }
}