/*
349. Intersection of Two Arrays
Link: https://leetcode.com/problems/intersection-of-two-arrays/

Given two integer arrays nums1 and nums2, return an array of their intersection.
Each element in the result must be unique and you may return the result in any order.
*/

class Solution {
    public int[] intersection(int[] nums1, int[] nums2) {
        HashSet<Integer> set1 = new HashSet<Integer>();
        HashSet<Integer> set2 = new HashSet<Integer>();
        
        for(int num : nums1) {
            set1.add(num);
        }
        
        for(int num : nums2) {
            if(set1.contains(num))
            {
                set2.add(num);
            }            
        }
        
        int[] result = new int[set2.size()];
        int i = 0;
        for(int num : set2) {
            result[i++] = num;
        }
        
        return result;
    }
}