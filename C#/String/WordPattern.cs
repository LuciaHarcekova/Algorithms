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

public class Solution {
    public bool WordPattern(string pattern, string s) {

        string[] words = s.Split(" ");     
        
        // Check if pattern is correcponding the number of words
        if (words.Length != pattern.Length) 
            return false;        
        
        // Iterate through pattern
        Dictionary<char, string> dic = new Dictionary<char,string>();      
        for (int i = 0; i < pattern.Length; i++) {
            var c = pattern[i];
            if (!dic.ContainsKey(c)) {
                if (dic.ContainsValue(words[i]))
                    return false;
                dic.Add(c, words[i]);
            } else if(!dic[c].Equals(words[i]))
                    return false;
        }

        return true;
    }
}