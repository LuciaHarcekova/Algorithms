/*
1.3 URLify
Link: https://www.crackingthecodinginterview.com

URLify: Write a method to replace all spaces in a string with '%20'. You may
assume that the string has sufficient space at the end to hold the additional
characters, and that you are given the "true" length of the string. 

(Note: if implementing in Java, please use a character array so that you
can perform this operation in place.)

Example:
Input: "Mr John Smith ", 13
Output: "Mr%20John%20Smith"

Solution:
A common approach in string manipulation problems is to edit the string
starting from the end and working backwards. This is useful because we have
an extra buffer at the end, which allows us to change characters without
worrying about what we're overwriting.
*/

public class Solution {
    public static char[] ReplaceSpaces(char[] str, int trueLength) {

        // Count spaces in string
        int spaceCount = 0;
        for (int i = 0; i < trueLength; i++) {
            if (str[i] == ' '){
                spaceCount++;
            }
        }

        // Replace characters
        int index = trueLength + spaceCount * 2;
        index = trueLength + spaceCount * 2;
        if (trueLength < str.Length){
            // End of array
            str[trueLength] = '\0';
        }
        for (int i = trueLength - 1; i >= 0; i--) {
            if (str[i] == ' ') {
                str[index - 1] = '0';
                str[index - 2] = '2'; 
                str[index - 3] = '%';
                index = index - 3;
            } else {
                str[index - 1] = str[i];
                index--;
            }
        }
        return str;
    }
}