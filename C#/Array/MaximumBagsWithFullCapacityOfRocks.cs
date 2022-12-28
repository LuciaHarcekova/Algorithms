/*
2279. Maximum Bags With Full Capacity of Rocks
Link: https://leetcode.com/problems/maximum-bags-with-full-capacity-of-rocks/

You have n bags numbered from 0 to n - 1. You are given two 0-indexed integer
arrays capacity and rocks. The ith bag can hold a maximum of capacity[i] rocks
and currently contains rocks[i] rocks. You are also given an integer additionalRocks,
the number of additional rocks you can place in any of the bags.

Return the maximum number of bags that could have full capacity after placing the
additional rocks in some bags.

Example 1:
Input: capacity = [2,3,4,5], rocks = [1,2,4,4], additionalRocks = 2
Output: 3
Explanation:
Place 1 rock in bag 0 and 1 rock in bag 1.
The number of rocks in each bag are now [2,3,4,4].
Bags 0, 1, and 2 have full capacity.
There are 3 bags at full capacity, so we return 3.
It can be shown that it is not possible to have more than 3 bags at full capacity.
Note that there may be other ways of placing the rocks that result in an answer of 3.

Example 2:
Input: capacity = [10,2,2], rocks = [2,2,0], additionalRocks = 100
Output: 3
Explanation:
Place 8 rocks in bag 0 and 2 rocks in bag 2.
The number of rocks in each bag are now [10,2,2].
Bags 0, 1, and 2 have full capacity.
There are 3 bags at full capacity, so we return 3.
It can be shown that it is not possible to have more than 3 bags at full capacity.
Note that we did not use all of the additional rocks.

Approach:
Notice we don't care about on which position are the bags, we only want to find out
the maximum number of bags that could have full capacity after placing the additional
rocks.

For solving this issue we can use the different data structures (array, queue, etc.).
I'll do my implementation using array.  Algorithm:
1. Calculate the difference between  capacity of bags and rocks, capacity[i] -= rocks[i].
   By this we will find out for each bag how many rocks we need to add to make it full.
2. Sort the differences. We will first start checking from bags which needs teh lowest
   number of additional rocks.
*/

public class Solution {
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks) {
        for (int i=0; i<capacity.Length; i++) {
            capacity[i] -= rocks[i];
        }
        
        Array.Sort(capacity);

        int count = 0;

        foreach (var diff in capacity) {
            if (diff == 0){
                count++;
            } else if (additionalRocks >= diff) {
                additionalRocks -= diff;
                count++;
            } else {
                break;
            }
        }
        
        return count;
    }
}