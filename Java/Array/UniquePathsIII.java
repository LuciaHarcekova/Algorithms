/*
980. Unique Paths III
Link: https://leetcode.com/problems/unique-paths-iii/

You are given an m x n integer array grid where grid[i][j] could be:
    1 representing the starting square. There is exactly one starting square.
    2 representing the ending square. There is exactly one ending square.
    0 representing empty squares we can walk over.
    -1 representing obstacles that we cannot walk over.
Return the number of 4-directional walks from the starting square to the
ending square, that walk over every non-obstacle square exactly once.

Example 1:
Input: grid = [[1,0,0,0],[0,0,0,0],[0,0,2,-1]]
Output: 2
Explanation: We have the following two paths: 
1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2)
2. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2)

Example 2:
Input: grid = [[1,0,0,0],[0,0,0,0],[0,0,0,2]]
Output: 4
Explanation: We have the following four paths: 
1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2),(2,3)
2. (0,0),(0,1),(1,1),(1,0),(2,0),(2,1),(2,2),(1,2),(0,2),(0,3),(1,3),(2,3)
3. (0,0),(1,0),(2,0),(2,1),(2,2),(1,2),(1,1),(0,1),(0,2),(0,3),(1,3),(2,3)
4. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2),(2,3)

Example 3:
Input: grid = [[0,1],[2,0]]
Output: 0
Explanation: There is no path that walks over every empty square exactly once.
Note that the starting and ending square can be anywhere in the grid.

Approach:
1. Find out the starting position (tagged by 1 in the grid).
2. In the same time we count the number of cells we need to walked over (tagged by 0 in the grid).
3. Iterativelly explore the grid from the starting position and check if we walk through all possible cells and are in the ending squere.

We we try to explore a cell,
it will change 0 to -2 and do a dfs in 4 direction.

If we hit the target and pass all empty cells, increment the result.
*/

class Solution {
    
    private final int[][] MOVES = new int[][] {
			{0, 1}, {0, -1}, {-1, 0}, {1, 0}
	};

    private int result = 0;
	private int emptyCells = 0;

    public int uniquePathsIII(int[][] grid) {
		int row = 0;
        int col = 0;

        // Find the beginning and calculate the empty cells we can walk over
		for (int i = 0; i < grid.length; i++) {
			for (int j = 0; j < grid[i].length; j++) {
				if (grid[i][j] == 0) {
					emptyCells++;
				} else if (grid[i][j] == 1) {
					row = i;
					col = j;
				}
			}
		}

        // explore the different paths
		explore(grid, row, col, 0);

		return result;
	}

	private void explore(int[][] grid, int row, int col, int walked) {
		// check if we are out of grid or at obstacle cell
        if (row < 0 || row >= grid.length || 
            col < 0 || col >= grid[row].length ||
            grid[row][col] < 0) {
			return;
		}

        // check if we are at the end and walk through all other possible cells
		if (grid[row][col] == 2 && walked == emptyCells + 1) {
			result++;
			return;
		}

        // tag cell as visited
		int val = grid[row][col];
		grid[row][col] = -2;

        // check the path through all neighbours
		for (int[] next : MOVES) {
			explore(grid, row + next[0], col + next[1], walked + 1);
		}

		grid[row][col] = val;
	}
}