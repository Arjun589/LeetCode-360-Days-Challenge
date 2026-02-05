𝗗𝗮𝘆 31 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3640. Trionic Array II
You are given an integer array nums of length n.
A trionic subarray is a contiguous subarray nums[l...r] (with 0 <= l < r < n) for which there exist indices l < p < q < r such that:
nums[l...p] is strictly increasing,
nums[p...q] is strictly decreasing,
nums[q...r] is strictly increasing.
Return the maximum sum of any trionic subarray in nums.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/trionic-array-ii

𝗛𝗶𝗻𝘁:- Identify strictly decreasing "bridge" segments and greedily extend them with the most profitable strictly increasing sequences to their left and right.
Use prefix sums to calculate the maximum contributions from these flanking segments while ensuring the required l < p < q < r boundaries are met.
Iterate through all potential middle segments and combine them with these optimal neighboring peaks to track and update the global maximum sum.


Approach:- https://leetcode.com/problems/trionic-array-ii/solutions/7550275/optimized-on-segment-based-approach-for-8s90f

Code:- 


using System;

public class Solution {
    public long MaxSumTrionic(int[] nums) {
        int n = nums.Length;
        long res = -1_000_000_000_000_000L; // -1e16

        for (int i = 1; i < n - 2; ) {
            int a = i, b = i;
            long net = nums[a];

            while (b + 1 < n && nums[b + 1] < nums[b]) {
                net += nums[++b];
            }
            if (b == a) { i++; continue; }

            int c = b;
            long left = 0, right = 0;
            long lx = long.MinValue, rx = long.MinValue;

            while (a - 1 >= 0 && nums[a - 1] < nums[a]) {
                left += nums[--a];
                lx = Math.Max(lx, left);
            }
            if (a == i) { i++; continue; }

            while (b + 1 < n && nums[b + 1] > nums[b]) {
                right += nums[++b];
                rx = Math.Max(rx, right);
            }
            if (b == c) { i++; continue; }

            res = Math.Max(res, lx + rx + net);
            i = b;
        }
        return res;
    }
}
