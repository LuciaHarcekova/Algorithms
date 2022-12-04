/*
2256. Minimum Average Difference
Link: https://leetcode.com/problems/minimum-average-difference/

You are given a 0-indexed integer array nums of length n.

The average difference of the index i is the absolute difference between the average
of the first i + 1 elements of nums and the average of the last n - i - 1 elements.
Both averages should be rounded down to the nearest integer.

Return the index with the minimum average difference. If there are multiple such
indices, return the smallest one.

Note:
The absolute difference of two numbers is the absolute value of their difference.
The average of n elements is the sum of the n elements divided (integer division) by n.
The average of 0 elements is considered to be 0.
*/

public class Solution {
    public int MinimumAverageDifference(int[] nums) {
        int n = nums.Length;
        long sumRight = nums.Sum(n => (long)n);
        long sumLeft = 0;
        int minAverage = int.MaxValue;
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            sumLeft += nums[i];
            sumRight -= nums[i];

            int leftAverage = (int)(sumLeft / (i + 1));
            int rightAverage = (n - i - 1) == 0 
                ? 0 
                : (int)(sumRight / (n - i - 1));

            int diff = Math.Abs(leftAverage - rightAverage);
            if (diff < minAverage)
            {
                index = i;
                minAverage = diff;
            }
        }
        return index;
    }
}