𝗗𝗮𝘆 36 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 1382. Balance a Binary Search Tree
Given the root of a binary search tree, return a balanced binary search tree with the same node values. If there is more than one answer, return any of them.
A binary search tree is balanced if the depth of the two subtrees of every node never differs by more than 1.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/balance-a-binary-search-tree

𝗛𝗶𝗻𝘁:- 1. Convert the skewed BST into a sorted list using In-order traversal
      2. Rebuild the tree by recursively picking the middle element


Code:-

public class Solution {
    private List<TreeNode> sortedNodes = new List<TreeNode>();

    public TreeNode BalanceBST(TreeNode root) {
        // 1. Convert the skewed BST into a sorted list using In-order traversal
        TransformToList(root);
        
        // 2. Rebuild the tree by recursively picking the middle element
        return BuildBalancedBST(0, sortedNodes.Count - 1);
    }

    private void TransformToList(TreeNode node) {
        if (node == null) return;

        TransformToList(node.left);
        sortedNodes.Add(node);
        TransformToList(node.right);
    }

    private TreeNode BuildBalancedBST(int start, int end) {
        if (start > end) return null;

        // Use the middle element as the root to maintain balance
        int mid = start + (end - start) / 2;
        TreeNode node = sortedNodes[mid];

        // Recursively construct left and right subtrees
        node.left = BuildBalancedBST(start, mid - 1);
        node.right = BuildBalancedBST(mid + 1, end);

        return node;
    }
}
