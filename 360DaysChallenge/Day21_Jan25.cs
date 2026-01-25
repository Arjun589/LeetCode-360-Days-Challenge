𝗗𝗮𝘆 21 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-1984. Minimum Difference Between Highest and Lowest of K Scores
You are given a 0-indexed integer array nums, where nums[i] represents the score of the ith student. You are also given an integer k.
Pick the scores of any k students from the array so that the difference between the highest and the lowest of the k scores is minimized.
Return the minimum possible difference.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores

𝗛𝗶𝗻𝘁:- Think if sorting helps.


Code:- 


  public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        Array.Sort(nums);
        int min = int.MaxValue;
        for(int i = 0; i + k - 1 < nums.Length; i++)
        {
            int diff = Math.Abs(nums[i] - nums[i+k-1]);
            min = Math.Min(min, diff);
        }
        
        return min;
    }
}
