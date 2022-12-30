/*
797. All Paths From Source to Target
Link: https://leetcode.com/problems/all-paths-from-source-to-target/

Given a directed acyclic graph (DAG) of n nodes labeled from 0 to n - 1,
find all possible paths from node 0 to node n - 1 and return them in any
order.

The graph is given as follows: graph[i] is a list of all nodes you can visit
from node i (i.e., there is a directed edge from node i to node graph[i][j]).

Example 1:
Input: graph = [[1,2],[3],[3],[]]
Output: [[0,1,3],[0,2,3]]
Explanation: There are two paths: 0 -> 1 -> 3 and 0 -> 2 -> 3.

Example 2:
Input: graph = [[4,3,1],[3,2,4],[3],[4],[]]
Output: [[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]]
*/

class Solution {
    public List<List<Integer>> allPathsSourceTarget(int[][] graph) { 
        List<Integer> currentPath = new ArrayList<>(){{ add(0); }};
        List<List<Integer>> result = findPaths(graph, new ArrayList<>(), currentPath, 0);
        return result;
    }

    private List<List<Integer>> findPaths(int[][] graph, List<List<Integer>> result, List<Integer> currentPath, int curr) {
        // If we are in final n-1 node, we found add the path to result
        if (curr == graph.length - 1) {
            result.add(new ArrayList<>(currentPath));
            return result;
        } else {
            // Check the path through all neighbours
            for (int neighbor : graph[curr]) {
                // Add the neighbour to path to be considered 
                currentPath.add(neighbor); 
                findPaths(graph, result, currentPath, neighbor);
                currentPath.remove(currentPath.size() - 1);
            }
        }
        return result;
    }
}