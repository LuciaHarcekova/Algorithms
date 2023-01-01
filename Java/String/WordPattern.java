/*
290. Word Pattern
Link: https://leetcode.com/problems/word-pattern/

Given a pattern and a string s, find if s follows the same pattern.

Here follow means a full match, such that there is a bijection between a
letter in pattern and a non-empty word in s.

Example 1:
Input: pattern = "abba", s = "dog cat cat dog"
Output: true

Example 2:
Input: pattern = "abba", s = "dog cat cat fish"
Output: false

Example 3:
Input: pattern = "aaaa", s = "dog cat cat dog"
Output: false
*/

class Solution {
    public boolean wordPattern(String pattern, String s) {
        String[] words = s.split(" ");     
        
        // Check if pattern is correcponding the number of words
        if (words.length != pattern.length()) 
            return false;        
        
        // Iterate through pattern
        HashMap<Character, String> map = new HashMap<Character,String>();      
        for (int i = 0; i < pattern.length(); i++) {
            var c = pattern.charAt(i);
            if (!map.containsKey(c)) {
                if (map.containsValue(words[i]))
                    return false;
                map.put(c, words[i]);
            } else if(!map.get(c).equals(words[i]))
                    return false;
        }

        return true;
    }
}