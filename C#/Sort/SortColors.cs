/*
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
*/

public class Solution {
    public void SortColors(int[] nums) {
        int count0 = 0;
        int count1 = 0;

        foreach (int num in nums) {
            if (num == 0) {
                count0++;
            } else if (num == 1) {
                count1++;
            }
        }

        for(int i=0; i < nums.Length; i++) {
            if (count0 > 0) {
                nums[i] = 0;
                count0--;
            } else if (count1 > 0) {
                nums[i] = 1;
                count1--;
            } else {
                nums[i] = 2;
            }
        }
    }
}