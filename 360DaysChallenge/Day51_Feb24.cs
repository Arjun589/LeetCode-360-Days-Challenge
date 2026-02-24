𝗗𝗮𝘆 51 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 1022. Sum of Root To Leaf Binary Numbers
You are given the root of a binary tree where each node has a value 0 or 1. Each root-to-leaf path represents a binary number starting with the most significant bit.
For example, if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 13.
For all leaves in the tree, consider the numbers represented by the path from the root to that leaf. Return the sum of these numbers.
The test cases are generated so that the answer fits in a 32-bits integer.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers

𝗛𝗶𝗻𝘁:- Basic DFS by forming all the binary string then convert it to decimal number and add it to the sum.

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
    int sum = 0;
    public void dosomething(TreeNode root, string bs)
    {
        if(root == null) return;
        if(root.left == null && root.right == null)
        {
            bs = bs + (char)('0' + root.val);
            System.Console.WriteLine(bs);
            sum += Convert.ToInt32(bs, 2);
            return;
        }
        dosomething(root.left, bs + (char)('0' + root.val));
        dosomething(root.right, bs + (char)('0' + root.val));
        return;
        
    }
    public int SumRootToLeaf(TreeNode root) {
        dosomething(root, "");
        return sum;
    }
}
