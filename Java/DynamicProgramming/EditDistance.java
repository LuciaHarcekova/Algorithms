/*
72. Edit Distance
Link: https://leetcode.com/problems/edit-distance/

Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

You have the following three operations permitted on a word:
    - Insert a character
    - Delete a character
    - Replace a character
 
Example 1:
Input: word1 = "horse", word2 = "ros"
Output: 3
Explanation: 
horse -> rorse (replace 'h' with 'r')
rorse -> rose (remove 'r')
rose -> ros (remove 'e')

Example 2:
Input: word1 = "intention", word2 = "execution"
Output: 5
Explanation: 
intention -> inention (remove 't')
inention -> enention (replace 'i' with 'e')
enention -> exention (replace 'n' with 'x')
exention -> exection (replace 'n' with 'c')
exection -> execution (insert 'u')

Source: https://leetcode.com/problems/edit-distance/solutions/25861/my-ac-java-dp-solution-only-use-o-n-space/
*/

class Solution {
    public int minDistance(String word1, String word2) {
        int m = word1.length(), n = word2.length();
        int[] dp = new int[n + 1];

        for (int i = 0; i <= n; i++) dp[i] = i;
        for (int i = 1; i <= m; i++) {
            int prev = i;
            for (int j = 1; j <= n; j++) {
                int cur;
                if (word1.charAt(i - 1) == word2.charAt(j - 1))
                    cur = dp[j - 1];
                else {
                    int insert = prev;
                    int delete = dp[j];
                    int replace = dp[j - 1];
                    cur = Math.min(Math.min(insert, delete), replace) + 1;
                }
                dp[j - 1] = prev;
                prev = cur;
            }
            dp[n] = prev;
        }

        return dp[n]; 
    }
}