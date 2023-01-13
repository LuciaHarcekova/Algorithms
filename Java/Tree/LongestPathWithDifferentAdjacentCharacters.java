/*
2246. Longest Path With Different Adjacent Characters
Link: https://leetcode.com/problems/longest-path-with-different-adjacent-characters/

You are given a tree (i.e. a connected, undirected graph that has no cycles) rooted at
node 0 consisting of n nodes numbered from 0 to n - 1. The tree is represented by a
0-indexed array parent of size n, where parent[i] is the parent of node i. Since node
0 is the root, parent[0] == -1.

You are also given a string s of length n, where s[i] is the character assigned to node i.

Return the length of the longest path in the tree such that no pair of adjacent nodes on
the path have the same character assigned to them.

Example 1:
Input: parent = [-1,0,0,1,1,2], s = "abacbe"
Output: 3
Explanation: The longest path where each two adjacent nodes have different characters in
the tree is the path: 0 -> 1 -> 3. The length of this path is 3, so 3 is returned.
It can be proven that there is no longer path that satisfies the conditions. 


Example 2:
Input: parent = [-1,0,0,0], s = "aabc"
Output: 3
Explanation: The longest path where each two adjacent nodes have different characters is
the path: 2 -> 0 -> 3. The length of this path is 3, so 3 is returned.
*/

class Solution {
    
    int longestPath = 0;

    public int longestPath(int[] parent, String s) {

        // Build tree
        int n = parent.length;
        List<Integer>[] tree = new ArrayList[n];
        for (int i=0; i<n; i++) tree[i] = new ArrayList();
        for (int i=1; i<n; i++) tree[parent[i]].add(i);
        
        // Calculate
        dfs(tree, s, 0);

        return longestPath;
    }

    // Calculate the length of the longest path in the tree such that no pair of
    // adjacent nodes on the path have the same character assigned to them.
    private int dfs(List<Integer>[] tree, String s, int i) {
        int tmpMax = 1;
        for (int child : tree[i]) {
            int path = dfs(tree, s, child);
            // only if characters are different
            if (s.charAt(child) != s.charAt(i)) {
                // check 2 longest paths from the current node
                if (tmpMax != 1) {
                    longestPath = Math.max(tmpMax + path, longestPath);
                }
                tmpMax = Math.max(path + 1, tmpMax);
            }
        }
        longestPath = Math.max(longestPath, tmpMax);
        return tmpMax;
    }
}