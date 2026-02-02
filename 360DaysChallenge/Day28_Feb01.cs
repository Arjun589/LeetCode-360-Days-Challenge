𝗗𝗮𝘆 28 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.
  
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3010. Divide an Array Into Subarrays With Minimum
You are given an array of integers nums of length n.
The cost of an array is the value of its first element. For example, the cost of [1,2,3] is 1 while the cost of [3,4,1] is 3.
You need to divide nums into 3 disjoint contiguous subarrays.
Return the minimum possible sum of the cost of these subarrays.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i

Approach:- find the two smallest values in an array (excluding the first element) using a single-pass comparison loop. It returns the sum of the first element plus these two smallest values, effectively minimizing the total cost.

Code:-

public class Solution {
    public int MinimumCost(int[] A) {
        int a = 51;
        int b = 51;

        for (int i = 1; i < A.Length; i++) {
            if (A[i] < a) {
                b = a;
                a = A[i];
            } else if (A[i] < b)
                b = A[i];

            if (a == 1 && b == 1) break;
        }

        return A[0] + a + b;
    }
}
