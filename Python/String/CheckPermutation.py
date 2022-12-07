"""
1.2 Check permutation
Link: https://www.crackingthecodinginterview.com

Given two strings, write a method to decide if one is a permutation of the other one.

Solution:
- confirm if the permutation comparison is case sensitive
- check is space is significant

Approaches:
- sort both strings and compare
- check if the two strings have identical character counts
  (implemented below)
- check counts for each character
"""

def checkPermutation(s, t):
    return sorted(s) == sorted(t)