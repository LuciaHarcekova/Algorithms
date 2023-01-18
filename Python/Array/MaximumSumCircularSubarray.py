"""
918. Maximum Sum Circular Subarray
Link: https://leetcode.com/problems/maximum-sum-circular-subarray/

Given a circular integer array nums of length n, return the maximum possible sum
of a non-empty subarray of nums.

A circular array means the end of the array connects to the beginning of the array.
Formally, the next element of nums[i] is nums[(i + 1) % n] and the previous element 
of nums[i] is nums[(i - 1 + n) % n].

A subarray may only include each element of the fixed buffer nums at most once.
Formally, for a subarray nums[i], nums[i + 1], ..., nums[j], there does not exist
i <= k1, k2 <= j with k1 % n == k2 % n.

Example 1:
Input: nums = [1,-2,3,-2]
Output: 3
Explanation: Subarray [3] has maximum sum 3.

Example 2:
Input: nums = [5,-3,5]
Output: 10
Explanation: Subarray [5,5] has maximum sum 5 + 5 = 10.

Example 3:
Input: nums = [-3,-2,-3]
Output: -2
Explanation: Subarray [-2] has maximum sum -2.

Approach:
https://leetcode.com/problems/maximum-sum-circular-subarray/solutions/178900/super-easy-python-solution-one-pass/
https://leetcode.com/problems/maximum-sum-circular-subarray/solutions/189299/java-2-approaches/
https://leetcode.com/problems/maximum-sum-circular-subarray/solutions/298435/easiest-solution-java/?orderBy=most_relevant&page=3
https://leetcode.com/problems/maximum-sum-circular-subarray/solutions/178435/c-o-n-solution/
"""


class Solution(object):
    def maxSubarraySumCircular(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """

        if not nums or len(nums) == 0:
            return 0

        local_min = nums[0]
        local_max = nums[0]
        res_min = nums[0]
        res_max = nums[0]

        for i in range(1, len(nums)):
            local_max = max(local_max + nums[i], nums[i])
            local_min = min(local_min + nums[i], nums[i])
            res_min = min(res_min, local_min)
            res_max = max(local_max, res_max)

        if sum(nums) != res_min:
            result = max(sum(nums)-res_min, res_max)
        else:
            result = res_max

        return result
