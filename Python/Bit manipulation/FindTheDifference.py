"""
389. Find the Difference
Link: https://leetcode.com/problems/find-the-difference/

You are given two strings s and t.

String t is generated by random shuffling string s and then add
one more letter at a random position.

Return the letter that was added to t.

Example:
Input: s = "abcd", t = "abcde"
Output: "e"
Explanation: 'e' is the letter that was added.

Approach:
https://leetcode.com/problems/find-the-difference/solutions/1751380/java-c-python-very-very-easy-to-go-solution/
"""

class Solution(object):
    def findTheDifference(self, s, t):
        """
        :type s: str
        :type t: str
        :rtype: str
        """
        c = 0
        for cs in s: c ^= ord(cs) #ord is ASCII value
        for ct in t: c ^= ord(ct)
        return chr(c) #chr = convert ASCII into character