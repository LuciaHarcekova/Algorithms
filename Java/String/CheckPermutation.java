/*
1.2 Check permutation
Link: https://www.crackingthecodinginterview.com

Given two strings, write a method to decide if one is a permutation of the other one.

Solution:
- confirm if the permutation comparison is case sensitive
- check is space is significant

Approaches:
- sort both strings and compare
- check if the two strings have identical character counts
  (implemented below)
*/

boolean checkPermutation(String s, String t){
    if (s.length() != t.length()) return false;

    int[] letters = new int[128];

    for (char c : s.toCharArray()) letters[c]++;

    for (char c : t.toCharArray()){
        letters[c]--;
        if (letters[c] < 0) return false;
    } 

    return true;
}