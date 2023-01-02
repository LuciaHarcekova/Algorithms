/*
520. Detect Capital
Link: https://leetcode.com/problems/detect-capital/

We define the usage of capitals in a word to be right when one of the following cases holds:
    All letters in this word are capitals, like "USA".
    All letters in this word are not capitals, like "leetcode".
    Only the first letter in this word is capital, like "Google".
Given a string word, return true if the usage of capitals in it is right.

Example 1:
Input: word = "USA"
Output: true

Example 2:
Input: word = "FlaG"
Output: false
*/

class Solution {
    public boolean detectCapitalUse(String word) {
        int numberOfUpper = 0;

        // Iterate through letters in word to get number of capitals
        for (char letter : word.toCharArray())
            if (Character.isUpperCase(letter))
                numberOfUpper++;

        // Set true if:
        //   - All lower letters  
        //   - All letters are capitals
        //   - nly first letter is capital   
        boolean validCapital = numberOfUpper == 0 || numberOfUpper == word.length() || (numberOfUpper == 1 && Character.isUpperCase(word.charAt(0)));

        return validCapital;        
    }
}