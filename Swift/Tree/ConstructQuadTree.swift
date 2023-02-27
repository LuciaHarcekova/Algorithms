/*
427. Construct Quad Tree
Link: https://leetcode.com/problems/construct-quad-tree/

Given a n * n matrix grid of 0's and 1's only. We want to represent the grid with a Quad-Tree.

Return the root of the Quad-Tree representing the grid.

Notice that you can assign the value of a node to True or False when isLeaf is False, and both
are accepted in the answer.

A Quad-Tree is a tree data structure in which each internal node has exactly four children.
Besides, each node has two attributes:

val: True if the node represents a grid of 1's or False if the node represents a grid of 0's.
isLeaf: True if the node is leaf node on the tree or False if the node has the four children.
class Node {
    public boolean val;
    public boolean isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;
}
We can construct a Quad-Tree from a two-dimensional area using the following steps:

If the current grid has the same value (i.e all 1's or all 0's) set isLeaf True and set val to
the value of the grid and set the four children to Null and stop.
If the current grid has different values, set isLeaf to False and set val to any value and divide
the current grid into four sub-grids as shown in the photo.
Recurse for each of the children with the proper sub-grid.

Quad-Tree format:
The output represents the serialized format of a Quad-Tree using level order traversal, where null
signifies a path terminator where no node exists below.
It is very similar to the serialization of the binary tree. The only difference is that the node is
represented as a list [isLeaf, val].
If the value of isLeaf or val is True we represent it as 1 in the list [isLeaf, val] and if the value
of isLeaf or val is False we represent it as 0.

Example 1:
Input: grid = [[0,1],[1,0]]
Output: [[0,1],[1,0],[1,1],[1,1],[1,0]]

Example 2:
Input: grid = [[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],
[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0]]
Output: [[0,1],[1,1],[0,1],[1,1],[1,0],null,null,null,null,[1,0],[1,0],[1,1],[1,1]]
Explanation: All values in the grid are not the same. We divide the grid into four sub-grids.
The topLeft, bottomLeft and bottomRight each has the same value.
The topRight have different values so we divide it into 4 sub-grids where each has the same value.
*/

/**
 * Definition for a QuadTree node.
 * public class Node {
 *     public var val: Bool
 *     public var isLeaf: Bool
 *     public var topLeft: Node?
 *     public var topRight: Node?
 *     public var bottomLeft: Node?
 *     public var bottomRight: Node?
 *     public init(_ val: Bool, _ isLeaf: Bool) {
 *         self.val = val
 *         self.isLeaf = isLeaf
 *         self.topLeft = nil
 *         self.topRight = nil
 *         self.bottomLeft = nil
 *         self.bottomRight = nil
 *     }
 * }
 */

class Solution {
    func construct(_ grid: [[Int]]) -> Node? {
        return construct_sub_tree(grid, 0, 0, grid.count)
    }
    
    func construct_sub_tree(_ grid: [[Int]], _ l: Int, _ w: Int, _ n: Int) -> Node? {

        // If it's leaf construct leaf node
        if isLeaf(grid, l, w, n) {
            return Node(grid[l][w] == 1, true)
        }

        // If it's internal node recursively inspects all 4 areas 
        var root = Node(false, false)
        root.topLeft = construct_sub_tree(grid, l, w, n / 2)
        root.topRight = construct_sub_tree(grid, l, w + (n / 2), n / 2)
        root.bottomLeft = construct_sub_tree(grid, l + (n / 2), w , n / 2)
        root.bottomRight = construct_sub_tree(grid, l + (n / 2), w + (n / 2), n / 2)
        return root
    }

    func isLeaf(_ grid: [[Int]], _ x: Int, _ y: Int, _ length: Int) -> Bool {
        for i in x ..< (x + length) {
            for j in y ..< (y + length) {
                if grid[i][j] != grid[x][y] {
                    return false
                }
            }
        }
        return true
    }
}