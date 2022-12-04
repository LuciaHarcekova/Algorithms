"""
451. Sort Characters By Frequency
Link: https://leetcode.com/problems/sort-characters-by-frequency/

Given a string s, sort it in decreasing order based on the frequency of the characters.
The frequency of a character is the number of times it appears in the string.

Return the sorted string. If there are multiple answers, return any of them.


One line solution:
''.join([ch*ct for ch, ct in sorted(Counter(s).items(), key = lambda x: (-x[1], x[0]))])
"""

class Solution:
    def frequencySort(self, s: str) -> str:
        frequencies = Counter(s)
        dic = list(frequencies.items())
        dic.sort(key = lambda x: (-x[1], x[0])) 
        words = [ch*n for ch, n in dic]  
        reult = ''.join(words)           
        return reult