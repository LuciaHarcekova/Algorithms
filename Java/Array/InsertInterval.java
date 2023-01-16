/*
57. Insert Interval
Link: https://leetcode.com/problems/insert-interval/

You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi]
represent the start and the end of the ith interval and intervals is sorted in ascending order by
starti. You are also given an interval newInterval = [start, end] that represents the start and
end of another interval.

Insert newInterval into intervals such that intervals is still sorted in ascending order by starti
and intervals still does not have any overlapping intervals (merge overlapping intervals if
necessary).

Return intervals after the insertion.

Example 1:
Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]

Example 2:
Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
*/

class Solution {
    public int[][] insert(int[][] intervals, int[] newInterval) {
        List<int[]> result = new ArrayList<int[]>();

    // Iterate through intervals
    for (int[] i : intervals) {
        // We have already added newInterval or the newInterval is after i,
        // add the remaining intervals to the result
        if (newInterval == null || i[1] < newInterval[0])
            result.add(i);
        // new interval ends before the i
        else if (i[0] > newInterval[1]) {
            result.add(newInterval);
            result.add(i);
            newInterval = null;
        } else {
            // There is intersection between the intervals
            newInterval[0] = Math.min(newInterval[0], i[0]);
            newInterval[1] = Math.max(newInterval[1], i[1]);
        }
    }

    // If we didn't add the interval before
    if (newInterval != null)
        result.add(newInterval);

    // Convert the result to the array
    int[][] array = new int[result.size()][];
    for(int i=0; i<array.length; i++)
         array[i] = result.get(i);

    return array; 
    }
}