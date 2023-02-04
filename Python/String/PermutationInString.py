"""
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
"""

# keep track of the count of characters in substrings of s2 by offsetting that of s1
class Solution(object):
    def checkInclusion(self, s1, s2):
        """
        :type s1: str
        :type s2: str
        :rtype: bool
        """
        m, n, a = len(s1), len(s2), ord('a')

        if n < m:
            return False

        count = [0] * 26
        for c in s1:
            count[ord(c)-a] += 1
        for i in xrange(0, m):
            count[ord(s2[i])-a] -= 1
        for i in xrange(m, n):
            if not any(count):
                return True
            count[ord(s2[i-m])-a] += 1
            count[ord(s2[i])-a] -= 1
        return not any(count)
