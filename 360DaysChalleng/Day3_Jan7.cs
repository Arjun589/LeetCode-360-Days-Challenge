//Problem statement:- Given the root of a binary tree, split the binary tree into two subtrees by removing one edge such that the product of the sums of the subtrees is maximized.
// Return the maximum product of the sums of the two subtrees. Since the answer may be too large, return it modulo 109 + 7.
// Note that you need to maximize the answer before taking the mod and not after taking it.
//Link:- https://leetcode.com/problems/maximum-product-of-splitted-binary-tree

//Approach 1:- 
// 1. Find the total sum of tree and meanwhile store at total sum of subtree with it's root node in the dictionary
//2. logic is to remove the subtree from total tree and find the maximum product of two subtrees.
//3. iterate through the dictionary and do product of two subtrees and store the maximum.

public class Solution {
    Dictionary<TreeNode, long> Nodesum = new Dictionary<TreeNode, long>();
    int total = 0;
    public long NodeSum(TreeNode root, int sum)
    {
        if(root == null) return sum;
        var left = NodeSum(root.left, 0);
        var right = NodeSum(root.right, 0);
        Nodesum[root] = root.val + left + right;
        total += root.val;
        return Nodesum[root];
    }
    public int MaxProduct(TreeNode root) {
        long mod = 1000000007;
        NodeSum(root, 0);
        long max = 0;
        foreach(var node in Nodesum)
        {   
            var left = total - node.Value;
            var value = node.Value;
            max = Math.Max(left * value , max);
        }
        return (int)(max % mod);
    }
}
