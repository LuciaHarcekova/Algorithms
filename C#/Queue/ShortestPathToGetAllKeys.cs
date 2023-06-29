/*
864. Shortest Path to Get All Keys
Link: https://leetcode.com/problems/shortest-path-to-get-all-keys/description/

You are given an m x n grid grid where:
'.' is an empty cell.
'#' is a wall.
'@' is the starting point.
Lowercase letters represent keys.
Uppercase letters represent locks.
You start at the starting point and one move consists of walking one space in 
one of the four cardinal directions. You cannot walk outside the grid, or walk into a wall.

If you walk over a key, you can pick it up and you cannot walk over a lock unless 
you have its corresponding key.

For some 1 <= k <= 6, there is exactly one lowercase and one uppercase letter of 
the first k letters of the English alphabet in the grid. This means that there is 
exactly one key for each lock, and one lock for each key; and also that the letters 
used to represent the keys and locks were chosen in the same order as the English 
alphabet.

Return the lowest number of moves to acquire all keys. If it is impossible, return -1.

Example 1:
Input: grid = ["@.a..","###.#","b.A.B"]
Output: 8
Explanation: Note that the goal is to obtain all the keys not to open all the locks.

Example 2:
Input: grid = ["@..aA","..B#.","....b"]
Output: 6

Example 3:
Input: grid = ["@Aa"]
Output: -1
*/

public class Solution {

   public class State {
        public int keys, i, j;
        public State(int keys, int i, int j) {
            this.keys = keys;
            this.i = i;
            this.j = j;
        }
    }

    public int ShortestPathAllKeys(string[] grid) {
        int x = -1, y = -1, m = grid.Length, n = grid[0].Length, totalKeys = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                char c = grid[i][j];
                if (c == '@') {
                    x = i;
                    y = j;
                }
                if (c >= 'a' && c <= 'f') {
                    totalKeys ++;
                }
            }
        }
        
        State start = new State(0, x, y);
        Queue<State> q = new Queue<State>();
        HashSet<string> visited = new HashSet<string>();
        visited.Add(0 + " " + x + " " + y);
        q.Enqueue(start);
        int[][] dirs = new int[][] {
            new int[] {0, 1}, 
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {-1, 0}};
        int step = 0;
        while (q.Any()) {
            int size = q.Count();
            while (size-- > 0) {
                State cur = q.Dequeue();
                if (cur.keys == (1 << totalKeys) - 1) {
                    return step;
                }
                foreach (int[] dir in dirs) {
                    int i = cur.i + dir[0];
                    int j = cur.j + dir[1];
                    int keys = cur.keys;
                    if (i >= 0 && i < m && j >= 0 && j < n) {
                        char c = grid[i][j];
                        if (c == '#') {
                            continue;
                        }
                        if (c >= 'a' && c <= 'f') {
                            keys |= 1 << (c - 'a');
                        }
                        if (c >= 'A' && c <= 'F' && ((keys >> (c - 'A')) & 1) == 0) {
                            continue;
                        }
                        if (!visited.Contains(keys + " " + i + " " + j)) {
                            visited.Add(keys + " " + i + " " + j);
                            q.Enqueue(new State(keys, i, j));
                        }
                    }
                }
            }
            step++;
        }
        return -1;
    }
}