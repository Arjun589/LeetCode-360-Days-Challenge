𝗗𝗮𝘆 18 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3507. Minimum Pair Removal to Sort Array I
Given an array nums, you can perform the following operation any number of times: Select the adjacent pair with the minimum sum in nums. If multiple such pairs exist, choose the leftmost one.
Replace the pair with their sum.
Return the minimum number of operations needed to make the array non-decreasing.
An array is said to be non-decreasing if each element is greater than or equal to its previous element (if it exists).

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-pair-removal-to-sort-array-i

𝗛𝗶𝗻𝘁:- Simulate the process exactly as described using a loop: find the smallest adjacent sum (breaking ties by index), merge the pair into one element, and repeat until the array is non-decreasing.

Code:

public class Solution {
    public int MinimumPairRemoval(int[] nums) {
     List<int> current = new List<int>(nums);
        int ops = 0;

        while (!IsSorted(current)) {
            int minSum = int.MaxValue;
            int targetIdx = -1;

            // Find the leftmost minimum sum pair
            for (int i = 0; i < current.Count - 1; i++) {
                int sum = current[i] + current[i + 1];
                if (sum < minSum) {
                    minSum = sum;
                    targetIdx = i;
                }
            }

            // Perform the merge
            int newSum = current[targetIdx] + current[targetIdx + 1];
            current.RemoveAt(targetIdx); // Remove first element
            current.RemoveAt(targetIdx); // Remove second element (now at targetIdx)
            current.Insert(targetIdx, newSum);
            
            ops++;
        }

        return ops;
    }

    private bool IsSorted(List<int> list) {
        for (int i = 0; i < list.Count - 1; i++) {
            if (list[i] > list[i + 1]) return false;
        }
        return true;
    }
}
