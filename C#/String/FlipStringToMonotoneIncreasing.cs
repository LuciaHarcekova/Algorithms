/*
926. Flip String to Monotone Increasing
Link: https://leetcode.com/problems/flip-string-to-monotone-increasing/

A binary string is monotone increasing if it consists of some number of 0's (possibly none),
followed by some number of 1's (also possibly none).

You are given a binary string s. You can flip s[i] changing it from 0 to 1 or from 1 to 0.

Return the minimum number of flips to make s monotone increasing.

Example 1:
Input: s = "00110"
Output: 1
Explanation: We flip the last digit to get 00111.

Example 2:
Input: s = "010110"
Output: 2
Explanation: We flip to get 011111, or alternatively 000111.

Example 3:
Input: s = "00011000"
Output: 2
Explanation: We flip to get 00000000.

Approach:
https://leetcode.com/problems/flip-string-to-monotone-increasing/solutions/183851/c-java-4-lines-o-n-o-1-dp/
https://leetcode.com/problems/flip-string-to-monotone-increasing/solutions/183889/c-time-o-n-just-keep-count-of-0-s-and-1-s/
*/

public class Solution {
    public int MinFlipsMonoIncr(string s) {
        // Count of all zeros in input string
        int flipped_zeros = s.Count(x => x == '0');;

        // Check if the string is monotary
        if (flipped_zeros == 0 || flipped_zeros == s.Length)
            return 0;

        // Flip all zeros to ones
        int result = flipped_zeros;
        int flipped_ones = 0;

        foreach (char c in s) {
            if (c == '0') {
                // Decrement the count of zeros to be flipped
                flipped_zeros--;
            } else {
                // Increment the count of ones to be flipped
                flipped_ones++;
            }
            result = Math.Min(result, flipped_zeros + flipped_ones);
        }

        return result;
    }
}