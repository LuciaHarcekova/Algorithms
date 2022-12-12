/*
17. Letter Combinations of a Phone Number
Link: https://leetcode.com/problems/letter-combinations-of-a-phone-number/

Given a string containing digits from 2-9 inclusive, return all possible
letter combinations that the number could represent. Return the answer in
any order.

A mapping of digits to letters (just like on the telephone buttons) is
given below. Note that 1 does not map to any letters.

Example:
Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
*/

public class Solution {
    public IList<string> LetterCombinations(string digits) {

        var combinations = new List<string>();
        if (string.IsNullOrEmpty(digits)) return combinations;

        var buttons = new Dictionary<char, string> {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

        // add the first possible letters from button
        foreach (char c in buttons[digits[0]])
            combinations.Add(c.ToString());

        // combine all the letters in combinations with all letters from rest of buttons
        for(int i = 1; i < digits.Length; i++) {
            char buttonNumber = digits[i];
            string button = buttons[buttonNumber];
            var newCombinations = new List<string>();

            foreach (string combo in combinations)
                foreach (char c in button)
                    newCombinations.Add(combo + c); 

            combinations = newCombinations;
        }

        return combinations;
    }
}