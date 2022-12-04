/*
1704. Determine if String Halves Are Alike
Link: https://leetcode.com/problems/determine-if-string-halves-are-alike/submissions/

You are given a string s of even length. Split this string into two halves of equal lengths,
and let a be the first half and b be the second half.

Two strings are alike if they have the same no. vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U').
Notice that s contains uppercase and lowercase letters.

Return true if a and b are alike. Otherwise, return false.
*/

public class Solution {
    public bool HalvesAreAlike(string s) {
        char[] vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
        int n = s.Length;
        int noVowelsAlike = 0;

        for (int i = 0; i < n; i++){
            if (vowels.Contains(s[i])){
                if (i < n / 2)
                    noVowelsAlike++;
                else
                    noVowelsAlike--;
            }
        }

        return noVowelsAlike == 0;
    }
}