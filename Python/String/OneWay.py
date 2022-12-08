"""
1.5 One way
Link: https://www.crackingthecodinginterview.com

There are three types of edits that can be performed on strings:
insert a character, remove a character, or replace a character.
Given two strings, write a function to check if they are one edit
(or zero edits) away.

Example:
pale, ple true pales, pale -> true 
pale, bale -> true 
pale, bae -> false

Solution:
Clarification on operations:
• Replacement: Consider two strings, such as bale and pale, that are
  one replacement away. Yes, that does mean that you could replace a
  character in bale to make pale. But more precisely, it means that
  they are different only in one place.
• Insertion: The strings apple and aple are one insertion away. This
  means that if you compared the strings, they would be identical-except
  for a shift at some point in the strings.
• Removal: The strings apple and aple are also one removal away, since
  removal is just the inverse of insertion.

Approaches:
- "brute force" algorithm and check all the possibilities
- use understanding of rules above
  (implemented below)
"""

def oneAway(first, second):

    # Get shorter and longer string.
    s1, s2 = first, second
    if len(first) > len(second):
        s1, s2 = second, first
    
    # Length checks.
    if (len(s1) - len(s2)) > 1: return False
    
    indexl = index2 = 0
    foundDifference = False

    while (index2 < len(s2) and indexl < len(s1)):
        if (s1[indexl] != s2[index2]): 
            if (foundDifference): return False # we already have one
            foundDifference = True
            if len(s1) == len(s2): # On replace, move shorter pointer
                indexl += 1
        else:
            indexl += 1 # If matching, move shorter pointer
        index2 += 1 # Always move pointer for longer string

    return True