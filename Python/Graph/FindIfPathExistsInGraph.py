"""
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

Sorces:
https://stackoverflow.com/questions/12905999/how-to-create-key-or-append-an-element-to-key
"""

import collections

class Solution(object):
    def validPath(self, n, edges, source, destination):
        """
        :type n: int
        :type edges: List[List[int]]
        :type source: int
        :type destination: int
        :rtype: bool
        """
        visited = [False]*n
        d = collections.defaultdict(list)

		# Store the edges
        for u, v in edges:
            d[u].append(v)
            d[v].append(u)

        # Apply BFS
        queue = [source]
        while queue:
            curr = queue.pop(0) 
            if curr == destination: 
                return True
            # Add the adjacent vertices of the current node to the queue and mark them as visited
            for x in d[curr]:
                if not visited[x]:
                    visited[x] = True
                    queue.append(x)

        return False  