/*
169. Majority Element
Link: https://leetcode.com/problems/majority-element/

Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times.
You may assume that the majority element always exists in the array.

Approach:
Name: Boyer-Moore Voting Algorithm
Source: https://leetcode.com/problems/majority-element/solutions/127412/majority-element/
*/

class Solution {
    public int majorityElement(int[] nums) {
        int count = 0;
        int candidate = null;

        for (int num : nums) {
            if (count == 0) {
                candidate = num;
            }
            count += (num == candidate) ? 1 : -1;
        }

        return candidate; 
    }
}