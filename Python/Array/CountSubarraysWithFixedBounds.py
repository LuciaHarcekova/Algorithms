"""
2444. Count Subarrays With Fixed Bounds
Link: https://leetcode.com/problems/count-subarrays-with-fixed-bounds/description/?envType=daily-question&envId=2024-03-31

You are given an integer array nums and two integers minK and maxK.

A fixed-bound subarray of nums is a subarray that satisfies the following conditions:

The minimum value in the subarray is equal to minK.
The maximum value in the subarray is equal to maxK.
Return the number of fixed-bound subarrays.

A subarray is a contiguous part of an array.

Example 1:
Input: nums = [1,3,5,2,7,5], minK = 1, maxK = 5
Output: 2
Explanation: The fixed-bound subarrays are [1,3,5] and [1,3,5,2].

Example 2:
Input: nums = [1,1,1,1], minK = 1, maxK = 1
Output: 10
Explanation: Every subarray of nums is a fixed-bound subarray. There are 10 possible subarrays.
"""

Solution(object):
    def countSubarrays(self, nums, minK, maxK):
        """
        :type nums: List[int]
        :type minK: int
        :type maxK: int
        :rtype: int
        """
        ans = 0
        left_index, right_index = -1, -1

        # we need to make a note from which position we started counting again 
        last_time_reset = -1

        for i, elem in enumerate(nums):
            
            if elem == minK:
                left_index = i
            
            if elem == maxK:
                right_index = i
            
            if minK > elem or elem > maxK:
                last_time_reset = i
                #left_index = -1
                #right_index = -1
            
            # min will secure we contains the both elements
            # max will secure we don't add negative numbers if we reseted
            # print("elem: ", elem,"left: ", left_index, "right: ",right_index, "last reset: ", last_time_reset)
            ans +=  max(0, min(left_index, right_index) - last_time_reset)
        
        return ans
            