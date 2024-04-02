/*
205. Isomorphic Strings
Link: https://leetcode.com/problems/isomorphic-strings/description/

Given two strings s and t, determine if they are isomorphic.
Two strings s and t are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving
the order of characters. No two characters may map to the same character, but a character may map to itself. 

Example 1:
Input: s = "egg", t = "add"
Output: true

Example 2:
Input: s = "foo", t = "bar"
Output: false

Example 3:
Input: s = "paper", t = "title"
Output: true
 
Constraints:
1 <= s.length <= 5 * 104
t.length == s.length
s and t consist of any valid ascii character.
*/

public class Solution {
    public bool IsIsomorphic(string s, string t) {
        int[] map1 = new int[128];  // Stores frequency of s
        int[] map2 = new int[128];  // Stores frequency of t

        for(int i=0; i<s.Length; i++) {
            char s_ch = s[i];
            char t_ch = t[i];

            if(map1[s_ch]==0 && map2[t_ch]==0) {
                map1[s_ch] = t_ch;
                map2[t_ch] = s_ch;
            }
            else if(map1[s_ch] != t_ch || map2[t_ch] != s_ch) {
                return false;
            }
        }
        return true;
    }
}