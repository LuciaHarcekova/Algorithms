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

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        LinkedList<int> window = new LinkedList<int>();
        List<int> result = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            while (window.Count > 0 && window.First.Value < i - k + 1)
                window.RemoveFirst();

            while (window.Count > 0 && nums[window.Last.Value] <  nums[i])
                window.RemoveLast();

            window.AddLast(i);
            
            if (i >= k-1)
                result.Add(nums[window.First.Value]);
        }

        return result.ToArray();
    }
}