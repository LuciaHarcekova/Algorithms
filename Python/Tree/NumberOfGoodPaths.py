"""
2421. Number of Good Paths
Link: https://leetcode.com/problems/number-of-good-paths/

There is a tree (i.e. a connected, undirected graph with no cycles) consisting of n
nodes numbered from 0 to n - 1 and exactly n - 1 edges.

You are given a 0-indexed integer array vals of length n where vals[i] denotes the
value of the ith node. You are also given a 2D integer array edges where edges[i] = [ai, bi]
 denotes that there exists an undirected edge connecting nodes ai and bi.

A good path is a simple path that satisfies the following conditions:

The starting node and the ending node have the same value.
All nodes between the starting node and the ending node have values less than or equal
to the starting node (i.e. the starting node's value should be the maximum value along
the path).
Return the number of distinct good paths.

Note that a path and its reverse are counted as the same path. For example, 0 -> 1
is considered to be the same as 1 -> 0. A single node is also considered as a valid path.

Example 1:
Input: vals = [1,3,2,1,3], edges = [[0,1],[0,2],[2,3],[2,4]]
Output: 6
Explanation: There are 5 good paths consisting of a single node.
There is 1 additional good path: 1 -> 0 -> 2 -> 4.
(The reverse path 4 -> 2 -> 0 -> 1 is treated as the same as 1 -> 0 -> 2 -> 4.)
Note that 0 -> 2 -> 3 is not a good path because vals[2] > vals[0].

Example 2:
Input: vals = [1,1,2,2,3], edges = [[0,1],[1,2],[2,3],[2,4]]
Output: 7
Explanation: There are 5 good paths consisting of a single node.
There are 2 additional good paths: 0 -> 1 and 2 -> 3.

Example 3:
Input: vals = [1], edges = []
Output: 1
Explanation: The tree consists of only one node, so there is one good path.

Sources:
https://leetcode.com/discuss/interview-question/2260088/Special-Paths-or-Google-OA-or-July-2022-or-Graph
https://leetcode.com/problems/number-of-good-paths/solutions/2620529/python-explanation-with-picture-dsu/
"""

class Solution(object):

    def numberOfGoodPaths(self, vals, edges):
        """
        :type vals: List[int]
        :type edges: List[List[int]]
        :rtype: int
        """

        n = len(vals)

        # find the absolute parent <- union find
        parent = list(range(n))

        def findUnion(x):
            if parent[x] != x:
                parent[x] = findUnion(parent[x])
            return parent[x]

        # Create graph
        adjList = defaultdict(list)
        for u, v in edges:
            adjList[u].append(v)
            adjList[v].append(u)

        # each node represent path with just single value
        result = n

        # Dictionary for remembering the no. paths for value: [maxVal, maxValCount]
        dic = collections.defaultdict(dict)
        for i, v in enumerate(vals):
            dic[i][v] = 1

        for val, cur in sorted([v, i] for i, v in enumerate(vals)):
            for nxt in adjList[cur]:

                # Get in which union the nodes are placed
                curUnion = findUnion(cur)
                nxtUnion = findUnion(nxt)

                # Check if the value is smaller than the value of the current node
                if vals[nxt] <= val and nxtUnion != curUnion:
                    parent[curUnion] = nxtUnion
                    result += dic[curUnion][val] * dic[nxtUnion].get(val, 0)
                    dic[nxtUnion][val] = dic[nxtUnion].get(
                        val, 0) + dic[curUnion][val]

        return result
