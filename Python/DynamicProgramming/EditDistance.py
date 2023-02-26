"""
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
"""

class Solution(object):
    def minDistance(self, w1, w2):
        """
        :type word1: str
        :type word2: str
        :rtype: int
        """

        m,n,d = len(w1),len(w2),{}
        def mds(w1, w2, i, j):
            if i*j==0: return i+j
            if (i,j) in d: return d[(i,j)]
            val = 0
            if w1[i-1]==w2[j-1]:
                val = mds(w1, w2, i-1, j-1)
            else:
                val = 1+min(mds(w1,w2,i,j-1),mds(w1,w2,i-1,j-1),mds(w1,w2,i-1,j))
            d[(i,j)]=val
            return val
        return mds(w1,w2,m,n)