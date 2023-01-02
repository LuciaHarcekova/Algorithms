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

public class Solution {
    public bool DetectCapitalUse(string word) {
        int numberOfUpper = 0;

        // Iterate through letters in word to get number of capitals
        foreach (char letter in word)
            if (Char.IsUpper(letter))
                numberOfUpper++;

        // Set true if:
        //   - All lower letters  
        //   - All letters are capitals
        //   - nly first letter is capital   
        bool validCapital = numberOfUpper == 0 || numberOfUpper == word.Length || (numberOfUpper == 1 && Char.IsUpper(word[0]));

        return validCapital; 
    }
}