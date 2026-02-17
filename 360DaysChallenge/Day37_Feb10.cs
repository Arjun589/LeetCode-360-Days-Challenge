𝗗𝗮𝘆 37 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3719. Longest Balanced Subarray I
You are given an integer array nums.
A subarray is called balanced if the number of distinct even numbers in the subarray is equal to the number of distinct odd numbers.
Return the length of the longest balanced subarray.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/longest-balanced-subarray-i

𝗛𝗶𝗻𝘁:- 1.Try fixing a starting index and expanding the subarray to the right, while tracking frequencies of odd and even numbers separately.
2. Whenever the number of distinct odd values equals the number of distinct even values, update the maximum length.


public class Solution {
    public int LongestBalanced(int[] nums) {
        int len = 0;

        for (int i = 0; i < nums.Length; i++) {
            var odd = new Dictionary<int, int>();
            var even = new Dictionary<int, int>();

            for (int j = i; j < nums.Length; j++) {
                var dict = (nums[j] & 1) == 1 ? odd : even;
                dict[nums[j]] = dict.GetValueOrDefault(nums[j]) + 1;

                if (odd.Count == even.Count) {
                    len = Math.Max(len, j - i + 1);
                }
            }
        }

        return len;
    }
}
