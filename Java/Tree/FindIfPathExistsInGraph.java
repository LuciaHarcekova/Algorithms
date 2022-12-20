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

class Solution {
    public boolean validPath(int n, int[][] edges, int source, int destination) {
        // Store the edges
        Map<Integer, List<Integer>> d = new HashMap<>();
        IntStream.range(0, n).forEach(u -> d.put(u, new ArrayList<>()));
        for (int[] e : edges) {
            d.get(e[0]).add(e[1]);
            d.get(e[1]).add(e[0]);
        }

        // Apply BFS
        Set<Integer> visited = new HashSet<>(){{ add(source); }};
        Queue<Integer> queue = new LinkedList<>(){{ add(source); }};
        while (!queue.isEmpty()) {
            if (queue.peek() == destination)
                return true;
            // Add the adjacent vertices of the current node to the queue and mark them as visited
            /*
               for (Integer neighbor : d.get(queue.poll())) {
                if (!visited.contains(neighbor)) {
                    visited.add(neighbor);
                    queue.offer(neighbor);
                }
            }
            */
            d.get(queue.poll())
                .stream()
                .filter(visited::add)
                .forEach(queue::offer);
        }

        return false;   
    }
}