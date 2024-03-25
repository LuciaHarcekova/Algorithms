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

class Solution {
    public String convert(String s, int numRows) {
        
        if(numRows == 1 || s.length() < numRows)
            return s;
        
        ArrayList<StringBuilder> rows = new ArrayList<>();
        for(int i =0; i<numRows; i++)
            rows.add(new StringBuilder());

        boolean down = false;
        int k = 0;
        for(char c: s.toCharArray())
        {
            rows.get(k).append(c);
            if(k == 0 || k == numRows-1)
                down = !down;
            k += down ? 1 : -1;
        }
        
        StringBuilder st = new StringBuilder();
        for(StringBuilder str : rows)
            st.append(str);

        return st.toString();
    }
}