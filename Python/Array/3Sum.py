"""
15. 3Sum
Link: https://leetcode.com/problems/3sum/description/

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

Example 1:
Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.

Example 2:
Input: nums = [0,1,1]
Output: []
Explanation: The only possible triplet does not sum up to 0.

Example 3:
Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: The only possible triplet sums up to 0.
 
Constraints:
3 <= nums.length <= 3000
-105 <= nums[i] <= 105
"""

class Solution(object):
    def threeSum(self, nums):
        """
        :type nums: List[int]
        :rtype: List[List[int]]
        """
        nums.sort()
        l = []

        for i in range(len(nums)):
            if i>0 and nums[i-1]==nums[i]:
                continue

            j = i+1
            k = len(nums)-1
            while j<k:
                s = nums[i]+nums[k]+nums[j]
                if s>0:
                    k -= 1
                elif s<0:
                    j += 1
                else:
                    l.append([nums[i],nums[j],nums[k]])
                    j += 1
                    while nums[j-1]==nums[j]and j<k:
                        j += 1

        return l



import itertools

class Solution(object):


    def threeSum(self, nums):
        """
        :type nums: List[int]
        :rtype: List[List[int]]
        """

        result = set()
        negatives, positives, zeros = [], [], []

        for num in nums:
            if num > 0:
                positives.append(num)
            elif num < 0:
                negatives.append(num)
            else:
                zeros.append(num)
        
        negative_set, positive_set = set(negatives), set(positives)

        if zeros:
            for num in positive_set:
                if -1 * num in negative_set:
                    result.add((-1 * num, 0, num))

        if len(zeros) >= 3:
            result.add((0, 0, 0))
        
        for i in xrange(len(negatives)):
            for j in xrange(i + 1, len(negatives)):
                target = -1 * (negatives[i] + negatives[j])

                if target in positive_set:
                    result.add(tuple(sorted([negatives[i], negatives[j], target])))
        
        for i in xrange(len(positives)):
            for j in xrange(i + 1, len(positives)):
                target = -1 * (positives[i] + positives[j])

                if target in negative_set:
                    result.add(tuple(sorted([positives[i], positives[j], target])))
        

        return result
        

        return result