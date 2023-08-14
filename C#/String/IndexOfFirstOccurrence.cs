/*
28. Find the Index of the First Occurrence in a String
Link: https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/

Given two strings needle and haystack, return the index of the first occurrence of
needle in haystack, or -1 if needle is not part of haystack.

Example 1:
Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.

Example 2:
Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
*/

public class Solution {
    public int StrStr(string haystack, string needle) {
        int n = needle.Length;
        int h = haystack.Length;

        for (int window=0; window <= h-n; window++){
            for (int i=0; i<n; i++){
                // Different character we can skip follow up execution in this loop
                if (needle[i] != haystack[window+i])
                    break;
                // We compared the whole needle
                if (i == n-1){
                    return window;
                }
            }
        }

        // No solution
        return -1;
    }
}