/*
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
*/

public class Solution
{
    public static bool OneAway(String first, String second) {
        /* Get shorter and longer string.*/
        string s1 = first.Length < second.Length ? first : second;
        string s2 = first.Length < second.Length ? second : first;
        
        /* Length checks. */
        if (s1.Length - s2.Length > 1) {
            return false;
        }
        
        int indexl = 0;
        int index2 = 0;
        bool foundDifference = false;

        while (index2 < s2.Length && indexl < s1.Length) {
            if (s1[indexl] != s2[index2]) {
                if (foundDifference) return false; // we already have one
                foundDifference = true;
                if (s1.Length == s2.Length) { // On replace, move shorter pointer
                    indexl++;
                }
            } else {
                indexl++; // If matching, move shorter pointer
            }
            index2++; // Always move pointer for longer string
        }
        return true;
    }
}