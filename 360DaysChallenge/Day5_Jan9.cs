//Problem statement:- Given the root of a binary tree, the depth of each node is the shortest distance to the root.
// Return the smallest subtree such that it contains all the deepest nodes in the original tree.
// A node is called the deepest if it has the largest depth possible among any node in the entire tree.
// The subtree of a node is a tree consisting of that node, plus the set of all descendants of that node.

//Problem link:- https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes

//There are so many approaches:- 
1. Base case
   - If the root is `null`, return `null`.

2. Level order traversal (BFS) 
   - Use a queue to traverse the tree level by level.  
   - Keep a dictionary `cp` (child → parent) to record each node’s parent.  
   - At each level, overwrite `deepestnodes` with the nodes currently in the queue.  
   - When BFS finishes, `deepestnodes` contains all nodes at the deepest level.

3. Identify deepest nodes
   - Take the leftmost and rightmost nodes from `deepestnodes`.  
   - If there’s only one deepest node, return it directly (it’s the subtree root).

4. Find common ancestor 
   - While the parents of `leftmost` and `rightmost` are different, move both upward using the `cp` dictionary.  
   - Eventually, they meet at the **lowest common ancestor (LCA)** of all deepest nodes.

5. Return result 
   - Return that common ancestor node, which is the root of the smallest subtree containing all deepest nodes.

 


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
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        if(root == null) return null;
        Queue<TreeNode> queue = new ();
        Dictionary<TreeNode,TreeNode> cp = new();        
        queue.Enqueue(root);
        cp[root] = null;
        List<TreeNode> deepestnodes = new ();
        while(queue.Count != 0)
        {
            deepestnodes = new List<TreeNode>(queue);
            int len = queue.Count;
            for(int i = 0; i < len ; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                    cp[node.left] = node;
                }
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                    cp[node.right] = node;
                }
            }
        }

        var leftmost = deepestnodes[0];
        var rightmost = deepestnodes[deepestnodes.Count - 1];
        if(leftmost == rightmost) return leftmost;
        while(cp[leftmost] != cp[rightmost])
        {
            leftmost = cp[leftmost];
            rightmost = cp[rightmost];
        }
        return cp[leftmost]; // cp[rightmost]
    }
}
