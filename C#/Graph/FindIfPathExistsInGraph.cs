/*
1971. Find if Path Exists in Graph
Link: https://leetcode.com/problems/find-if-path-exists-in-graph/

There is a bi-directional graph with n vertices, where each vertex is
labeled from 0 to n - 1 (inclusive). The edges in the graph are represented
as a 2D integer array edges, where each edges[i] = [ui, vi] denotes a
bi-directional edge between vertex ui and vertex vi. Every vertex pair
is connected by at most one edge, and no vertex has an edgeto itself.

You want to determine if there is a valid path that exists from vertex
source to vertex destination.

Given edges and the integers n, source, and destination, return true if
there is a valid path from source to destination, or false otherwise.

Example 1:
Input: n = 3, edges = [[0,1],[1,2],[2,0]], source = 0, destination = 2
Output: true
Explanation: There are two paths from vertex 0 to vertex 2:
- 0 → 1 → 2
- 0 → 2
*/

public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        // Store the edges
        var d = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < n; i++) {
            d.Add(i, new List<int>());
        }
        foreach (int[] e in edges) {
            d[e[0]].Add(e[1]);
            d[e[1]].Add(e[0]);
        }

        // Apply BFS
        HashSet<int> visited = new HashSet<int> {source};
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Any()) {
            int curr = queue.Dequeue();
            if (curr == destination)
                return true;
            // Add the adjacent vertices of the current node to the queue and mark them as visited
            foreach (int neighbor in d[curr]) {
                if (!visited.Contains(neighbor)) {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;   
    }
}