"""
75. Sort Colors
Link: https://leetcode.com/problems/sort-colors/

Given an array nums with n objects colored red, white, or blue, sort them
in-place so that objects of the same color are adjacent, with the colors
in the order red, white, and blue.

We will use the integers 0, 1, and 2 to represent the color red, white,
and blue, respectively.

You must solve this problem without using the library's sort function.

Example 1:
Input: nums = [2,0,2,1,1,0]
Output: [0,0,1,1,2,2]

Example 2:
Input: nums = [2,0,1]
Output: [0,1,2]
"""

class Solution(object):
    def sortColors(self, nums):
        """
        :type nums: List[int]
        :rtype: None Do not return anything, modify nums in-place instead.
        """
        count0 = 0
        count1 = 0

        for c in nums:
            if c == 0:
                count0 += 1
            elif c == 1:
                count1 += 1
        nums[0 : count0] = [0] * count0
        nums[count0 : count0+count1] = [1] * count1
        nums[count0+count1 :] = [2] * (len(nums) - count0 - count1)
        return nums
