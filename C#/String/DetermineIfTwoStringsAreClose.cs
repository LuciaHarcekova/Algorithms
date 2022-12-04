/*
1657. Determine if Two Strings Are Close
Link: https://leetcode.com/problems/determine-if-two-strings-are-close/

Two strings are considered close if you can attain one from the other using the following operations:

Operation 1: Swap any two existing characters.
    For example, abcde -> aecdb
Operation 2: Transform every occurrence of one existing character into another existing character, and do the same with the other character.
    For example, aacabb -> bbcbaa (all a's turn into b's, and all b's turn into a's)

You can use the operations on either string as many times as necessary.

Given two strings, word1 and word2, return true if word1 and word2 are close, and false otherwise.

Observation:
Operation 1: word1 and word2 have the same set of unique characters
Operation 2: word1 and word2 have the same set of occurrencces of characters
*/

public class Solution {
    public bool CloseStrings(string word1, string word2) {

        if(word1.Length != word2.Length)
            return false;
        
        HashSet<char> set1 = new HashSet<char>();
        HashSet<char> set2 = new HashSet<char>();
        
        int[] freq1 = new int[26];
        int[] freq2 = new int[26];

        for(int i = 0; i < word1.Length; i++)
        {
            // Frequencies
            freq1[word1[i] - 'a']++;
            freq2[word2[i] - 'a']++;
            
            // The same set
            set1.Add(word1[i]);
            set2.Add(word2[i]);
        }
        
        Array.Sort(freq1);
        Array.Sort(freq2);
        
        return freq1.SequenceEqual(freq2) && set1.SetEquals(set2);
    }
}