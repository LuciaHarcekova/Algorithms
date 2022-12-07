/*
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
*/

public class Solution {
    public static bool isUniqueChars(string str) {

        // String length cannot be more than 256 - ASCII.
        if (str.Length > 128) return false;

        // Initialize occurrences of all characters
        bool[] occurrences = new bool[128];

        // For every character, check if it exists in "occurrences"
        for (int i=0; i<str.Length; i++){
            int value = str[i];
            if (occurrences[value]){
                return false;
            }
            occurrences[value] = true;
        }

        return true;
    }
}