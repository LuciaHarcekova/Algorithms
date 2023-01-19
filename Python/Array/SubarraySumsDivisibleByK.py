"""
974. Subarray Sums Divisible by K
Link: https://leetcode.com/problems/subarray-sums-divisible-by-k/

Given an integer array nums and an integer k, return the number of non-empty
subarrays that have a sum divisible by k.

A subarray is a contiguous part of an array.

Example 1:
Input: nums = [4,5,0,-2,-3,1], k = 5
Output: 7
Explanation: There are 7 subarrays with a sum divisible by k = 5:
[4, 5, 0, -2, -3, 1], [5], [5, 0], [5, 0, -2, -3], [0], [0, -2, -3], [-2, -3]

Example 2:
Input: nums = [5], k = 9
Output: 0

Approach:
https://leetcode.com/problems/subarray-sums-divisible-by-k/solutions/217976/c-simple-slow-dp/
https://leetcode.com/problems/subarray-sums-divisible-by-k/solutions/217962/java-clean-o-n-number-theory-prefix-sums/
https://leetcode.com/problems/subarray-sums-divisible-by-k/solutions/217982/java-11ms-9-liner-prefix-sum-without-hashmap-time-o-n/
"""

class Solution(object):
    def subarraysDivByK(self, nums, k):
        """
        :type nums: List[int]
        :type k: int
        :rtype: int
        """
        result = 0
        prefix_sum = 0
        hist = {0: 1}

        for num in nums:
            prefix_sum += num
            key = prefix_sum % k
            result += hist.get(key, 0)
            hist[key] = hist.get(key, 0) + 1

        return result
