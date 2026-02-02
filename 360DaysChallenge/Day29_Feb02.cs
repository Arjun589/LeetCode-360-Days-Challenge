𝗗𝗮𝘆 29 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3013. Divide an Array Into Subarrays With Minimum
You are given a 0-indexed array of integers nums of length n, and two positive integers k and dist.
The cost of an array is the value of its first element. For example, the cost of [1,2,3] is 1 while the cost of [3,4,1] is 3.
You need to divide nums into k disjoint contiguous subarrays, such that the difference between the starting index of the second subarray and the starting index of the kth subarray should be less than or equal to dist. In other words, if you divide nums into the subarrays nums[0..(i1 - 1)], nums[i1..(i2 - 1)], ..., nums[ik-1..(n - 1)], then ik-1 - i1 <= dist.
Return the minimum possible sum of the cost of these subarrays.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-ii

𝗛𝗶𝗻𝘁:- The problem asks to divide the array into k subarrays. The first element nums[0] is always the cost of the first subarray.find the k−1 smallest elements within a sliding window of size dist+1 that starts after the first element.
Approach:- https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-ii/solutions/7544813/binary-indexed-tree-bit-with-binary-lift-6fr8

Code:-
public class Solution {
    public long MinimumCost(int[] nums, int k, int dist) {
        int n = nums.Length, targetK = k - 1;
        int[] sorted = nums.Distinct().OrderBy(x => x).ToArray();
        int m = sorted.Length;
        long[] bitSum = new long[m + 1];
        int[] bitCount = new int[m + 1];
        var rankMap = sorted.Select((v, i) => new { v, i }).ToDictionary(x => x.v, x => x.i + 1);

        void Update(int r, int v, int c) {
            for (; r <= m; r += r & -r) {
                bitSum[r] += (long)v; bitCount[r] += c;
            }
        }

        int maxP = 1;
        while ((maxP << 1) <= m) maxP <<= 1;
        long minExtra = long.MaxValue;

        for (int i = 1; i < n; i++) {
            Update(rankMap[nums[i]], nums[i], 1);
            if (i > dist + 1) {
                int oldV = nums[i - dist - 1];
                Update(rankMap[oldV], -oldV, -1);
            }
            if (i >= targetK) {
                int idx = 0, cc = 0; long cs = 0;
                for (int p = maxP; p > 0; p >>= 1) {
                    if (idx + p <= m && cc + bitCount[idx + p] < targetK) {
                        idx += p; cc += bitCount[idx]; cs += bitSum[idx];
                    }
                }
                if (cc < targetK) cs += (long)(targetK - cc) * sorted[idx];
                minExtra = Math.Min(minExtra, cs);
            }
        }
        return nums[0] + minExtra;
    }
}
