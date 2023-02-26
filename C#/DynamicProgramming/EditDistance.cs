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
*/

public class Solution {
    public int MinDistance(string word1, string word2) {
        if (word1 == string.Empty)
            return word2.Length;
        else if (word2 == string.Empty)
            return word1.Length;
        
        int [,] res = new int[word1.Length + 1, word2.Length + 1];
        
        for (int i = 0; i <= word1.Length; i++)
            res[i, 0] = i;
        
        for (int i = 1; i <= word2.Length; i++)
            res[0, i] = i;
        
        for (int i = 1; i <= word1.Length; i++)
            for (int j = 1; j <= word2.Length; j++)
                if (word1[i - 1] == word2[j - 1])
                    res[i, j] = res[i - 1, j - 1];
                else
                    res[i, j] = Math.Min(res[i - 1, j -1], Math.Min(res[i - 1, j], res[i, j - 1])) + 1;
                
        return res[word1.Length, word2.Length];
    }
}