"""
290. Word Pattern
Link: https://leetcode.com/problems/word-pattern/

Given a pattern and a string s, find if s follows the same pattern.

Here follow means a full match, such that there is a bijection between a
letter in pattern and a non-empty word in s.

Example 1:
Input: pattern = "abba", s = "dog cat cat dog"
Output: true

Example 2:
Input: pattern = "abba", s = "dog cat cat fish"
Output: false

Example 3:
Input: pattern = "aaaa", s = "dog cat cat dog"
Output: false
"""

class Solution(object):
    def wordPattern(self, pattern, s):
        """
        :type pattern: str
        :type s: str
        :rtype: bool
        """
        words = s.split()    
        
        # Check if pattern is correcponding the number of words
        if len(words) != len(pattern): 
            return False
        
        # Iterate through pattern
        dic = dict()  
        for i in range(len(pattern)):
            c = pattern[i]
            if c not in dic:
                if words[i] in dic.values():
                    return False
                dic[c] = words[i]
            elif dic[c] != words[i]:
                    return False

        return True