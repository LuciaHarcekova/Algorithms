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

function checkInclusion(s1: string, s2: string): boolean {
    var len1 = s1.length;
    var len2 = s2.length;

    if (len1 > len2) return false;

    var count = Array(26);
    count.fill(0);
    for (var i = 0; i < len1; i++) {
        count[s1.charCodeAt(i) - 'a'.charCodeAt(0)]++;
    }
    
    for (var j = 0; j < len2; j++) {
        count[s2.charCodeAt(j) - 'a'.charCodeAt(0)]--;
        if (j - len1 >= 0) count[s2.charCodeAt(j - len1) - 'a'.charCodeAt(0)]++;
        if (allZero(count)) return true;
    }

    return false;
    
   function allZero(count) {
        for (var i = 0; i < 26; i++) {
            if (count[i] !== 0) return false;
        }
        return true;
    } 
};