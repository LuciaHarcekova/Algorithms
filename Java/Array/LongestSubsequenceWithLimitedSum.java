/*
2389. Longest Subsequence With Limited Sum
Link: https://leetcode.com/problems/longest-subsequence-with-limited-sum/

You are given an integer array nums of length n, and an integer array queries
of length m.

Return an array answer of length m where answer[i] is the maximum size of a
subsequence that you can take from nums such that the sum of its elements is
less than or equal to queries[i].

A subsequence is an array that can be derived from another array by deleting
some or no elements without changing the order of the remaining elements.

Example 1:
Input: nums = [4,5,2,1], queries = [3,10,21]
Output: [2,3,4]
Explanation: We answer the queries as follows:
- The subsequence [2,1] has a sum less than or equal to 3. It can be proven
  that 2 is the maximum size of such a subsequence, so answer[0] = 2.
- The subsequence [4,5,1] has a sum less than or equal to 10. It can be proven
  that 3 is the maximum size of such a subsequence, so answer[1] = 3.
- The subsequence [4,5,2,1] has a sum less than or equal to 21. It can be proven
  that 4 is the maximum size of such a subsequence, so answer[2] = 4.

Example 2:
Input: nums = [2,3,4,5], queries = [1]
Output: [0]
Explanation: The empty subsequence is the only subsequence that has a sum less
than or equal to 1, so answer[0] = 0.
*/

class Solution {
    public int[] answerQueries(int[] nums, int[] queries) {
        int n = nums.length; 
		int m = queries.length;
        int[] result = new int[m];

		Arrays.sort(nums);

        // initialize and fill the helper sums
        // at i position we have sum of numbers from 0 to i-th index
        int[] prefixSums = new int[n];
        prefixSums[0] = nums[0];
        for(int i=1; i<n; i++) {
			prefixSums[i] = prefixSums[i-1] + nums[i];
		}

        for (int i=0; i<m; i++) {
            int j = 0;
            while (j<n && prefixSums[j]<=queries[i]) j++;
            result[i] = j;
        }

        return result;
    }
}