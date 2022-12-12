"""
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
"""

class Solution(object):
    def letterCombinations(self, digits):
        """
        :type digits: str
        :rtype: List[str]
        """

        if (digits == ""): return []

        buttons = {
            "2": 'abc',
            "3": 'def',
            "4": 'ghi',
            "5": 'jkl',
            "6": 'mno',
            "7": 'pqrs',
            "8": 'tuv',
            "9": 'wxyz'
        }

        # add all the letters from the first button
        combinations = [i for i in buttons[digits[0]]]

        # combine all the letters in combinations with all letters from rest of buttons
        for d in digits[1:]:
            combinations = [i + c for i in combinations for c in buttons[d]]

        return combinations