/*
1.4 Palindrome Permutation
Link: https://www.crackingthecodinginterview.com

Given a string, write a function to check if it is a permutation of a palindrome.

A palindrome is a word or phrase that is the same forwards and backwards.
A permutation is a rearrangement of letters. The palindrome does not need to be
limited to just dictionary words.

Example:
Input: Tact Coa
Output: True (permutations: "taco cat'; "atc o eta·; etc.)

Solution:
! check if it's case sensitive

A palindrome is a string that is the same forwards and backwards. What does it take 
to be able to write a set of characters the same way forwards and backwards? We need
to have an even number of almost all characters, so that half can be on one side and
half can be on the other side. At most one character (the middle character) can have
an odd count.

Approaches:
- use a hash table to count how many times each character appears
- use a single integer (as a bit vector). When we see a letter, we map it
  to an integer between O and 26 (assuming an English alphabet)
*/

public class Solution {
    public static boolean isPermutationOfPalindrome(String phrase) {
        int countOdd = 0;
        int[] table = new int[Character.getNumericValue('z') - Character.getNumericValue('a') + 1];
        for (char c : phrase.toCharArray()) {
            int x = Character.getNumericValue(c);
            if (x != -1) {
                table[x]++;
                if (table[x] % 2 == 1) {
                    countOdd++;
                } else {
                    countOdd--;
                }
            }
        }
        return countOdd <= 1;
    } 
}