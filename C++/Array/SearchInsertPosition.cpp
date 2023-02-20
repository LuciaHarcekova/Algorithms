/*
35. Search Insert Position
Link: https://leetcode.com/problems/search-insert-position/

Given a sorted array of distinct integers and a target value, return the
index if the target is found. If not, return the index where it would be
if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [1,3,5,6], target = 5
Output: 2

Example 2:
Input: nums = [1,3,5,6], target = 2
Output: 1

Example 3:
Input: nums = [1,3,5,6], target = 7
Output: 4
*/

class Solution {
public:
    int searchInsert(vector<int>& nums, int target) {
        // Initialize lower and upper boundary
        int l = 0;
        int r = nums.size() - 1;

        // Loop between lower and upper until l = r
        while (l < r) {
            int m = (l + r) / 2;
            if (nums[m] >= target) r = m;
            else l = m + 1;
        }

        return nums[l] >= target ? l : l + 1;
    }
};