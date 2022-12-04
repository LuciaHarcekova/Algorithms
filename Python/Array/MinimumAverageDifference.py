"""
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
"""

class Solution:
    def minimumAverageDifference(self, nums: List[int]) -> int:

        n = len(nums)
        rightSum = sum(nums)
        leftSum = 0
        
        minAverage = inf
        result = 0
        
        for i, value in enumerate(nums):
            leftSum += value
            rightSum -= value
            
            leftAvg = leftSum//(i+1)

            rightAvg = rightSum//(n-i-1) if n-i-1!=0 else 0
            absDif = abs(leftAvg-rightAvg)
            
            if (minAverage > absDif):
                minAverage = absDif
                index = i

        return index
