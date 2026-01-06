//Approach :- 1. Traverse the tree using BFS or DFS, in case of BFS 
// 2. Each level add a sum and compare for max value
// 3. if val is greater then update the max value and level, we will not update if it is same value because we want to return lowest level with maximum value.
//return level.

public class Solution {
    public int MaxLevelSum(TreeNode root) {
        int maxsum = int.MinValue;
        int level = 0;
        int currlevel = 0;
        if(root == null) return level;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count != 0)
        {
            int len = queue.Count;
            int sum = 0;
            for(int i = 0 ; i < len; i++)
            {
                var front = queue.Dequeue();
                sum += front.val;
                if(front.left != null) queue.Enqueue(front.left);
                if(front.right != null) queue.Enqueue(front.right);
            }
            currlevel += 1;
            if(sum > maxsum)
            {
                maxsum = sum;
                level = currlevel;
            }
        }

        return level;
        
    }
}
