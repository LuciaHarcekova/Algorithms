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

public class Solution {
    public long CountSubarrays(int[] nums, int minK, int maxK) {
        
        long ans = 0;
        int left_index = -1, right_index = -1;

        // we need to make a note from which position we started counting again 
        int last_time_reset = -1;

        for (int i = 0; i<nums.Length; i++) {
            
            int elem = nums[i];
            
            if (elem == minK)
                left_index = i;
            
            if (elem == maxK)
                right_index = i;
            
            if (minK > elem || elem > maxK)
                last_time_reset = i;
            
            // min will secure we contains the both elements
            // max will secure we don't add negative numbers if we reseted
            ans +=  Math.Max(0, Math.Min(left_index, right_index) - last_time_reset);
        }

        return ans;
    }
}