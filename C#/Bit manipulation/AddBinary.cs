/*
67. Add Binary
Link: https://leetcode.com/problems/add-binary/description/

Given two binary strings a and b, return their sum as a binary string.

Example 1:
Input: a = "11", b = "1"
Output: "100"

Example 2:
Input: a = "1010", b = "1011"
Output: "10101"
 

Constraints:
1 <= a.length, b.length <= 104
a and b consist only of '0' or '1' characters.
Each string does not contain leading zeros except for the zero itself.
*/

public class Solution {
    public string AddBinary(string a, string b) {
       int i = a.Length - 1;
       int j = b.Length - 1;
       int carry = 0;
       string result = "";

       while (i>=0 || j>=0 || carry ==1){
           if (i>=0) carry += a[i--] - '0';
           if (j>=0) carry += b[j--] - '0';
           result += (carry %2).ToString();
           carry /= 2;
       }

       return new string(result.Reverse().ToArray());
    }
}