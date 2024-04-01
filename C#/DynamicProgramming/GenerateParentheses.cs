/*
22. Generate Parentheses
Link: https://leetcode.com/problems/generate-parentheses/description/

Given n pairs of parentheses, write a function to generate all combinations
of well-formed parentheses.

Example 1:
Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:
Input: n = 1
Output: ["()"]
 
Constraints: 1 <= n <= 8
*/

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        List<String> result = new List<String>();
        dfs(0, 0, result, "", n);
        return result;
    }

    public void dfs(int left, int right, List<String> result, String s, int n) {
        if (s.Length == n*2) {
            result.Add(s);
            return;
        }

        if (left<n) {
            dfs(left+1, right, result, s+"(", n);
        }

        if (right<left) {
            dfs(left, right+1, result, s+")", n);
        }
    }
}