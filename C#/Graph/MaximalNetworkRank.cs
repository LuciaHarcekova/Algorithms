/*
1615. Maximal Network Rank
Link: https://leetcode.com/problems/maximal-network-rank/

There is an infrastructure of n cities with some number of roads connecting these cities.
Each roads[i] = [ai, bi] indicates that there is a bidirectional road between cities ai and bi.

The network rank of two different cities is defined as the total number of directly connected
roads to either city. If a road is directly connected to both cities, it is only counted once.

The maximal network rank of the infrastructure is the maximum network rank of all pairs of different cities.

Given the integer n and the array roads, return the maximal network rank of the entire infrastructure.

Example 1:
Input: n = 4, roads = [[0,1],[0,3],[1,2],[1,3]]
Output: 4
Explanation: The network rank of cities 0 and 1 is 4 as there are 4 roads that are connected to
either 0 or 1. The road between 0 and 1 is only counted once.

Example 2:
Input: n = 5, roads = [[0,1],[0,3],[1,2],[1,3],[2,3],[2,4]]
Output: 5
Explanation: There are 5 roads that are connected to cities 1 or 2.

Example 3:
Input: n = 8, roads = [[0,1],[1,2],[2,3],[2,4],[5,6],[5,7]]
Output: 5
Explanation: The network rank of 2 and 5 is 5. Notice that all the cities do not have to be connected.
*/

public class Solution {
    public int MaximalNetworkRank(int n, int[][] roads) {
        var d = new Dictionary<int, List<int>>();
        
        for (int i = 0; i <= n; i++) {
            d.Add(i, new List<int>());
        }
        foreach (int[] e in roads) {
            d[e[0]].Add(e[1]);
            d[e[1]].Add(e[0]);
        }

        int ans=0;
        for(int i=0;i<=n;i++){
            int deg1=d[i].Count;
            for(int j=i+1;j<=n;j++){
                int deg2=d[j].Count;
                if(d[i].Contains(j)){
                    ans=Math.Max(ans,deg1+deg2-1);
                }else{
                    ans=Math.Max(ans,deg1+deg2);
                }
            }
        }

        return ans;
    }
}