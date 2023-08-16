/*
239. Sliding Window Maximum
Link: https://leetcode.com/problems/sliding-window-maximum/

You are given an array of integers nums, there is a sliding window of size k
which is moving from the very left of the array to the very right. You can
only see the k numbers in the window. Each time the sliding window moves right
by one position.
Return the max sliding window.

Example 1:
Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
Output: [3,3,5,5,6,7]
Explanation: 
Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7

Example 2:
Input: nums = [1], k = 1
Output: [1]
*/

class Solution {
    public int[] maxSlidingWindow(int[] nums, int k) {
        int n = nums.length;
        int[] result = new int[n - k + 1];
        Deque<Integer> window  = new LinkedList<>();
        
        for (int i=0; i<n; i++){

            while (!window.isEmpty() && window.peekFirst() < i - k + 1) {
                window.pollFirst();
            }
            
            while (!window.isEmpty() && nums[window.peekLast()] < nums[i]) {
                window.pollLast();
            }

            window.offerLast(i);

            if (i >= k - 1) {
                result[i - k + 1] = nums[window.peekFirst()];
            }
        }

        return result;
    }
}