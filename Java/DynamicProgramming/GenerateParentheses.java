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

class Solution {
    public List<String> generateParenthesis(int n) {
        List<String> result = new ArrayList<String>();
        dfs(0, 0, result, "", n);
        return result;
    }

    public void dfs(int left, int right, List<String> result, String s, int n) {
        if (s.length() == n*2) {
            result.add(s);
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