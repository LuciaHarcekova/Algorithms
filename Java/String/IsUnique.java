/*
1.1 Is Unique
Link: https://www.crackingthecodinginterview.com

Implement an algorithm to determine if a string has all unique characters.
What if you cannot use additional data structures?

Solution:
- investigate if string is ASCII or Unicode (we'll go ahead with ASCII)

Approaches:
- compare every character of a string to other characters in the string
  (time complexity n^2)
- sort the string and compare the neighbors
- create an array of 128 characters to count for each character occurrence
  (implemented below)
*/

class Solution {
    public boolean isUniqueChars(String str) {

        // String length cannot be more than 256 - ASCII.
        if (str.length() > 128) return false;

        // Initialize occurrences of all characters
        boolean[] occurrences = new boolean[128];

        // For every character, check if it exists in "occurrences"
        for (int i=0; i<str.length(); i++){
            int value = str.charAt(i);
            if (occurrences[value]){
                return false;
            }
            occurrences[value] = true;
        }

        return true;
    }
}