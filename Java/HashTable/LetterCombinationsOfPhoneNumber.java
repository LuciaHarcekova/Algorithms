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

class Solution {
    public List<String> letterCombinations(String digits) {

        List<String> combinations = new ArrayList<String>();
        if (digits.isEmpty()) return combinations;

        Map<Character, String> buttons = new HashMap<Character, String>() {{
            put('2', "abc");
            put('3', "def");
            put('4', "ghi");
            put('5', "jkl");
            put('6', "mno");
            put('7', "pqrs");
            put('8', "tuv");
            put('9', "wxyz");
        }};

        var digitsArr = digits.toCharArray();

        // add the first possible letters from button
        for(char c : buttons.get(digitsArr[0]).toCharArray())
            combinations.add(Character.toString(c));

        // combine all the letters in combinations with all letters from rest of buttons
        for(int i = 1; i < digitsArr.length; i++) {
            char buttonNumber = digitsArr[i];
            String button = buttons.get(buttonNumber);
            List<String> newCombinations = new ArrayList<String>();
            
            for(String combo : combinations)
                for (char c : button.toCharArray())
                    newCombinations.add(combo + c); 

            combinations = newCombinations;
        }

        return combinations;
    }
}