"""
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
"""

class Solution(object):
    def allPathsSourceTarget(self, graph):
        """
        :type graph: List[List[int]]
        :rtype: List[List[int]]
        """
        def find_paths(curr_node, curr_path):
            if curr_node == len(graph) - 1:
                result.append(curr_path)
            else:
                for neighbour in graph[curr_node]:
                    find_paths(neighbour, curr_path + [neighbour])
        result = []
        find_paths(0, [0])
        return result