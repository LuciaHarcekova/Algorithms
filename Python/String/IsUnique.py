"""
1.1 Is Unique
Link: https://www.crackingthecodinginterview.com

Implement an algorithm to determine if a string has all unique characters.
What if you cannot use additional data structures?

Approaches:
- compare every character of a string to other characters in the string
  (time complexity n^2)
- sort the string and compare the neighbors
- create an array of 128 characters to count for each character occurrence
  (implemented below)
"""

def isUniqueChars(st):
 
    # String length cannot be more than 256 - ASCII.
    if len(st) > 256:
        return False
 
    # Initialize occurrences of all characters
    occurrences = [False] * 128
 
    # For every character, check if it exists in "occurrences"
    for i in range(0, len(st)):
        val = ord(st[i])
        if occurrences[val]:
            return False
        occurrences[val] = True
 
    return True