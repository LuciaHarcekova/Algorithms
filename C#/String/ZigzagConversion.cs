/*
6. Zigzag Conversion
Link: https://leetcode.com/problems/zigzag-conversion/description/

The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows
like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:
string convert(string s, int numRows);
 
Example 1:
Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"

Example 2:
Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I

Example 3:
Input: s = "A", numRows = 1
Output: "A"
*/

public class Solution {
    public string Convert(string s, int numRows) {
        
        if(numRows == 1 || s.Length < numRows)
            return s;
        
        string[] rows = new string[numRows];

        bool down = false;
        int index = 0;
        foreach(char c in s)
        {
            rows[index] += c;
            if (index == 0 || index == numRows-1)
                down = !down;
            index += down ? 1 : -1;
        }

        return string.Concat(rows);
    }
}