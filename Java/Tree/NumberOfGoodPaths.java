/*
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
*/

class Solution {

    int[] parent;

    public int numberOfGoodPaths(int[] vals, int[][] edges) {

        // Save number of nodes
        int n = vals.length;

        // Create the map with neighbors nodes
        List<Integer>[] tree = new ArrayList[n];
        for (int i=0; i<n; i++) {
            tree[i] = new ArrayList();
        }
        for (int []arr : edges) {
            tree[arr[0]].add(arr[1]);
            tree[arr[1]].add(arr[0]);
        }

        // Create map for saving paths for nodes
        Map<Integer, Map<Integer, Integer>> dic = new HashMap<>();
        for (int i = 0; i<n; i++) {
            Map<Integer, Integer> arr = dic.getOrDefault(vals[i], new HashMap<>());
            arr.put(i, 1);
            dic.put(vals[i], arr);
        }

        // Array to save in which union individual nodes are
        parent = IntStream.iterate(0, i -> i + 1).limit(n).toArray();

        // Save and sort values with their positions
        HashMap<Integer, Integer> valDict = new HashMap<Integer, Integer>();
        for (int i = 0; i < n; i++) valDict.put(i, vals[i]); 
 
        LinkedHashMap<Integer, Integer> sortedValDict = valDict.entrySet()
            .stream()             
            .sorted(Map.Entry.comparingByValue())
            .collect(Collectors.toMap(e -> e.getKey(), 
                                        e -> e.getValue(), 
                                        (e1, e2) -> null,
                                        () -> new LinkedHashMap<Integer, Integer>()));

        // Looking for paths
        int result = n;

        for (Map.Entry<Integer, Integer> entry: sortedValDict.entrySet()) {
            for (int nxt : tree[entry.getKey()]) {
               
                // Get in which union the nodes are placed
                int root_cur = findUnion(entry.getKey());
                int root_nxt = findUnion(nxt);

                if (vals[nxt] <= entry.getValue() && root_nxt != root_cur) {
                    parent[root_cur] = root_nxt;
                    var tmp = dic.get(entry.getValue());
					result += tmp.get(root_cur) * tmp.getOrDefault(root_nxt, 0);
                    tmp.put(root_nxt, tmp.getOrDefault(root_nxt, 0) + tmp.getOrDefault(root_cur, 0));
                    dic.put(entry.getValue(), tmp);
                }
            }
        }

        return result;
    }

    public int findUnion(int x) {
        if (parent[x] != x) parent[x] = findUnion(parent[x]);
        return parent[x];
    }
}