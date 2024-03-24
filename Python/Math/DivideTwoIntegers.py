"""
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
"""

class Solution(object):
    def divide(self, dividend, divisor):
        """
        :type dividend: int
        :type divisor: int
        :rtype: int
        """
        
        mark = (dividend < 0) != (divisor < 0)
        divisor = abs(divisor)
        dividend = abs(dividend)

        quotient = 0
        tmp_sum = divisor

        while tmp_sum <= dividend:
            tmp_quotient = 1
            while tmp_sum+tmp_sum <= dividend:
                tmp_quotient += tmp_quotient
                tmp_sum += tmp_sum
            quotient += tmp_quotient
            dividend -= tmp_sum
            tmp_sum = divisor
        
        quotient = -quotient if mark else quotient
        return min(2147483647, max(quotient, -2147483648))
        