/*
491. Non-decreasing Subsequences
Link: https://leetcode.com/problems/non-decreasing-subsequences/description/

Given an integer array nums, return all the different possible non-decreasing subsequences
of the given array with at least two elements. You may return the answer in any order.

Example 1:
Input: nums = [4,6,7,7]
Output: [[4,6],[4,6,7],[4,6,7,7],[4,7],[4,7,7],[6,7],[6,7,7],[7,7]]

Example 2:
Input: nums = [4,4,3,2,1]
Output: [[4,4]]
*/

class Solution {
    public List<List<Integer>> findSubsequences(int[] nums) {
        List<List<Integer>> result = new LinkedList<>();
        search(new LinkedList<Integer>(), 0, nums, result);
        return result; 
    }

    private void search(LinkedList<Integer> list, int index, int[] nums, List<List<Integer>> result) {
        if (list.size() > 1)
            result.add(new LinkedList<Integer>(list));
        
        Set<Integer> used = new HashSet<>();

        for (int i=index; i<nums.length; i++) {
            if (!used.contains(nums[i]) && (list.size()==0 || nums[i]>=list.peekLast())) {
                used.add(nums[i]);
                list.add(nums[i]); 
                search(list, i+1, nums, result);
                list.remove(list.size()-1);
            }
        }
    }
}