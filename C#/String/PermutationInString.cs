/*
567. Permutation in String
Link: https://leetcode.com/problems/permutation-in-string/

Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.

In other words, return true if one of s1's permutations is the substring of s2.

Example 1:
Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").

Example 2:
Input: s1 = "ab", s2 = "eidboaoo"
Output: false
*/

public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        
        int len1 = s1.Length;
        int len2 = s2.Length;

        // can't be the permutation because s2 contains less characters
        if (len1 > len2) return false;
        
        int[] count = new int[26];

        for (int i = 0; i < len1; i++) {
            count[s1[i] - 'a']++;
        }
        
        for (int i = 0; i < len2; i++) {
            count[s2[i] - 'a']--;
            if (i - len1 >= 0) count[s2[i - len1] - 'a']++;
            if (allZero(count)) return true;
        }
        
        return false;
    }
    
    private bool allZero(int[] count) {
        for (int i = 0; i < 26; i++) {
            if (count[i] != 0) return false;
        }
        return true;
    }
}

