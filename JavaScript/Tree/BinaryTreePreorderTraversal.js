/*
144. Binary Tree Preorder Traversal
Link: https://leetcode.com/problems/binary-tree-preorder-traversal/

Given the root of a binary tree, return the preorder traversal of its nodes' values.
*/

// Other solution:
// return root ? [root.val, ...preorderTraversal(root.left), ...preorderTraversal(root.right)] : [];

/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number[]}
 */
var preorderTraversal = function (root) {
    const result = [];

    const traverse = (node) => {
        if (node === null) 
            return;
        
        result.push(node.val);
        traverse(node.left);
        traverse(node.right);
    };

    traverse(root);

    return result;
};
