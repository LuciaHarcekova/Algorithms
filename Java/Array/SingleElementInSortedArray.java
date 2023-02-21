/*
540. Single Element in a Sorted Array
Link: https://leetcode.com/problems/single-element-in-a-sorted-array/

You are given a sorted array consisting of only integers where every element
appears exactly twice, except for one element which appears exactly once.

Return the single element that appears only once.

Your solution must run in O(log n) time and O(1) space.

Example 1:
Input: nums = [1,1,2,3,3,4,4,8,8]
Output: 2

Example 2:
Input: nums = [3,3,7,7,10,11,11]
Output: 10
*/

class Solution {
    public int singleNonDuplicate(int[] nums) {
        int l = 0;
        int u = nums.length - 1;
        
        while(l < u){
            int mid = l + (u - l) / 2;
            
            // If mid == 0 or if mid happens to be the unique entry return that
            if(mid == 0 || (nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1])){
                return nums[mid];
            }
            
            if((nums[mid] == nums[mid - 1] && mid % 2 == 1) ||
              (nums[mid] == nums[mid + 1] && mid % 2 == 0)){
                l = mid + 1;
            } else {
                u = mid - 1;
            }
        }
        
        return nums[u];
    }
}