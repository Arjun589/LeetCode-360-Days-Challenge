𝗗𝗮𝘆 34 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 110. Balanced Binary Tree, Given a binary tree, determine if it is height-balanced.
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/balanced-binary-tree

𝗛𝗶𝗻𝘁:- Find the Height the left and right subtree using bfs.


Code:-

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int MaxHeight(TreeNode root)
    {
        if(root == null) return 0;
        int maxi = int.MinValue;
        maxi = 1 + Math.Max(MaxHeight(root.left) , MaxHeight(root.right));
        return maxi;
    }
    public bool IsBalanced(TreeNode root) {
        if(root == null) return true;
        if(!(Math.Abs(MaxHeight(root.left) - MaxHeight(root.right)) <= 1)) return false;
        return IsBalanced(root.left) && IsBalanced(root.right);        
    }
}
