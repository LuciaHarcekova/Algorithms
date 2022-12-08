"""
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
"""

def urlify(str, str_length):
    return str[:str_length].replace(' ', '%20')