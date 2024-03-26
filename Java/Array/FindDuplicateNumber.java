/*
287. Find the Duplicate Number
Link: https://leetcode.com/problems/find-the-duplicate-number/description/?envType=daily-question&envId=2024-03-24

Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.

There is only one repeated number in nums, return this repeated number.

You must solve the problem without modifying the array nums and uses only constant extra space.

Example 1:
Input: nums = [1,3,4,2,2]
Output: 2

Example 2:
Input: nums = [3,1,3,4,2]
Output: 3

Example 3:
Input: nums = [3,3,3,3,3]
Output: 3

Solution:
https://leetcode.com/problems/find-the-duplicate-number/solutions/4916443/interview-approach-7-approaches/
https://leetcode.com/problems/find-the-duplicate-number/solutions/4916338/floyd-s-cycle-detection-slow-fast-pointer-c-java-python3-kotlin/
*/

class Solution {
    public int findDuplicate(int[] nums) {
    
    int slow = nums[0];
    int fast = nums[0];

    do {
      slow = nums[slow];
      fast = nums[nums[fast]];
    } while (slow != fast);

    fast = nums[0];
    while (slow != fast) {
      slow = nums[slow];
      fast = nums[fast];
    }

    return slow;
    }
}