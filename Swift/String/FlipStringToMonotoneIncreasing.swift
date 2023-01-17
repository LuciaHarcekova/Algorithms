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

class Solution {
    func minFlipsMonoIncr(_ s: String) -> Int {

        var result = 0
        var flipped_ones = 0

        for c in s {
            if c == "1" {
                flipped_ones += 1
            } else {
                 result = min(result + 1, flipped_ones)
            }
        }

        return result
    }
}