/*
70. Climbing Stairs
Link: https://leetcode.com/problems/climbing-stairs/

You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct
ways can you climb to the top?

Example:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step

Approach:
Base rules:
    n == 0, ways = 0
    n == 1, only one way to climb the stair (1).
    n == 2, two ways to climb the stairs (1+1, 2).
*/

class Solution {
    public int climbStairs(int n) {
        // base scenarios
        if(n <= 2) return n;
        
        // calculate the rest bas eon the base rules
        int oneStep = 2;
        int twoSteps = 1;
        int ways = 0;
        for(int i=2; i<n; i++) {
            ways = oneStep + twoSteps;
            twoSteps = oneStep;
            oneStep = ways;
        }
        
        return ways;
    }
}