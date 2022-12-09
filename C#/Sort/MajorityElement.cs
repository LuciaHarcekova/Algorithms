/*
169. Majority Element
Link: https://leetcode.com/problems/majority-element/

Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times.
You may assume that the majority element always exists in the array.
*/

public class Solution {
    public int MajorityElement(int[] nums) {
        int count = 0;
        int candidate = 0;

        foreach (int num in nums) {
            if (count == 0) {
                candidate = num;
            }
            count += (num == candidate) ? 1 : -1;
        }

        return candidate; 
    }
}