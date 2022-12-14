/*
349. Intersection of Two Arrays
Link: https://leetcode.com/problems/intersection-of-two-arrays/

Given two integer arrays nums1 and nums2, return an array of their intersection.
Each element in the result must be unique and you may return the result in any order.
*/

using System;
using System.Collections.Generic;

public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {

        HashSet<int> set1 = new HashSet<int>();
        HashSet<int> set2 = new HashSet<int>();
        
        foreach (int num in nums1) {
            set1.Add(num);
        }
        
        foreach (int num in nums2) {
            if(set1.Contains(num))
            {
                set2.Add(num);
            }            
        }
        
        int[] result = new int[set2.Count];
        int i = 0;
        foreach (int num in set2) {
            result[i++] = num;
        }
        
        return result;
    }
}