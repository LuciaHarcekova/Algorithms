"""
349. Intersection of Two Arrays
Link: https://leetcode.com/problems/intersection-of-two-arrays/

Given two integer arrays nums1 and nums2, return an array of their intersection.
Each element in the result must be unique and you may return the result in any order.

One line solutions:
list(set([i for i in nums1 if i in nums2]))
list(set(filter(lambda x: x in nums1, nums2)))
"""

class Solution(object):
    def intersection(self, nums1, nums2):
        """
        :type nums1: List[int]
        :type nums2: List[int]
        :rtype: List[int]
        """
        return list(set([i for i in nums1 if i in nums2]))