/*
1675. Minimize Deviation in Array
Link: https://leetcode.com/problems/minimize-deviation-in-array/

You are given an array nums of n positive integers.

You can perform two types of operations on any element of the array any number of times:

If the element is even, divide it by 2.
For example, if the array is [1,2,3,4], then you can do this operation on the last element,
and the array will be [1,2,3,2].
If the element is odd, multiply it by 2.
For example, if the array is [1,2,3,4], then you can do this operation on the first element,
and the array will be [2,2,3,4].
The deviation of the array is the maximum difference between any two elements in the array.

Return the minimum deviation the array can have after performing some number of operations.

Example 1:
Input: nums = [1,2,3,4]
Output: 1
Explanation: You can transform the array to [1,2,3,2], then to [2,2,3,2], then the deviation
will be 3 - 2 = 1.

Example 2:
Input: nums = [4,1,5,20,3]
Output: 3
Explanation: You can transform the array after two operations to [4,2,5,5,3], then the deviation
will be 5 - 2 = 3.

Example 3:
Input: nums = [2,10,8]
Output: 3

Source: https://leetcode.com/problems/minimize-deviation-in-array/solutions/1782143/c-418ms-sortedset/?q=C%23&orderBy=most_relevant
*/

public class Solution {
        public int MinimumDeviation(int[] nums) {
        
        // multiply every odd number by 2; leave the evens alone
        var sortedSet = new SortedSet<int>(nums.Select(x => (1 == (x & 1)) ? x * 2 : x));
        
        int minDeviation = sortedSet.Max - sortedSet.Min;
        
        while (true){
            int max = sortedSet.Max;
            
            if(0 != (max & 1)) break;   // if we can't reduce the maximum, we are done
            
            sortedSet.Remove(max);
            sortedSet.Add(max/2);
            
            minDeviation = Math.Min(minDeviation, sortedSet.Max - sortedSet.Min);
        }
        
        //Console.WriteLine(string.Join(',', sortedSet));
        return minDeviation;
    }
}