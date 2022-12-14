/*
198. House Robber
Link: https://leetcode.com/problems/house-robber/

You are a professional robber planning to rob houses along a street.
Each house has a certain amount of money stashed, the only constraint
stopping you from robbing each of them is that adjacent houses have
security systems connected and it will automatically contact the police
if two adjacent houses were broken into on the same night.

Given an integer array nums representing the amount of money of each house,
return the maximum amount of money you can rob tonight without alerting
the police.
*/

public class Solution {
    public int Rob(int[] nums) {
        int prev = 0;
        int last = 0;
        foreach (int curr in nums) {
            int tmp = Math.Max(prev + curr, last);
            prev = last;
            last = tmp;
        }
        return last;
    }
}