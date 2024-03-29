/*
29. Divide Two Integers
Link: https://leetcode.com/problems/divide-two-integers/description/

Given two integers dividend and divisor, divide two integers without using multiplication,
division, and mod operator.

The integer division should truncate toward zero, which means losing its fractional part.
For example, 8.345 would be truncated to 8, and -2.7335 would be truncated to -2.

Return the quotient after dividing dividend by divisor.

Note: Assume we are dealing with an environment that could only store integers within the 32-bit
signed integer range: [−231, 231 − 1]. For this problem, if the quotient is strictly greater than
231 - 1, then return 231 - 1, and if the quotient is strictly less than -231, then return -231.

Example 1:
Input: dividend = 10, divisor = 3
Output: 3
Explanation: 10/3 = 3.33333.. which is truncated to 3.

Example 2:
Input: dividend = 7, divisor = -3
Output: -2
Explanation: 7/-3 = -2.33333.. which is truncated to -2.

Solution:
https://leetcode.com/problems/divide-two-integers/solutions/427345/python-24ms-beats-99-with-and-w-o-bitwise-operators/
https://leetcode.com/problems/divide-two-integers/solutions/1085017/js-python-java-c-updated-logarithmic-bit-manipulation-solutions-w-explanation/
*/

class Solution {
    public int divide(int A, int B) {
        if (A == -2147483648 && B == -1) return 2147483647;
        
        int ans = 0;
        int mark = A > 0 == B > 0 ? 1 : -1;
        
        if (A < 0) A = -A;
        if (B < 0) B = -B;
        if (A == B) return mark;

        for (int i = 0, val = B; A - B >= 0; i = 0, val = B) {
            while (val > 0 && A - val >= 0) {
                val = B << ++i;
            }
            A -= B << i - 1;
            ans += 1 << i - 1;
        }

        return mark < 0 ? -ans : ans;
    }
}