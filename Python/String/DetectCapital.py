
"""
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

Other solution:
return word[1:]==word[1:].lower() or word==word.upper()
"""

class Solution(object):
    def detectCapitalUse(self, word):
        """
        :type word: str
        :rtype: bool
        """
        number_of_upper = 0

        # Iterate through letters in word to get number of capitals
        for character in word:
            if character.isupper():
                number_of_upper += 1

        # Set true if:
        #   - All lower letters  
        #   - All letters are capitals
        #   - nly first letter is capital   
        valid_capital = number_of_upper == 0 or number_of_upper == len(word) or (number_of_upper == 1 and word[0].isupper())

        return valid_capital
        
        