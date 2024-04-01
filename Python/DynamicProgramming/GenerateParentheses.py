"""
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
"""

class Solution(object):
    def generateParenthesis(self, n):
        """
        :type n: int
        :rtype: List[str]
        """

        result = []

        def dfs(left, right, s):
            if len(s) == n*2:
                result.append(s)

            if left<n:
                dfs(left+1, right, s+'(')

            if right<left:
                dfs(left, right+1, s+')')

        dfs(0, 0, "")
        return result
        