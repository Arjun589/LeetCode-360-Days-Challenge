𝗗𝗮𝘆 33 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3634. Minimum Removals to Balance Array
You are given an integer array nums and an integer k.
An array is considered balanced if the value of its maximum element is at most k times the minimum element.
You may remove any number of elements from nums​​​​​​​ without making it empty.
Return the minimum number of elements to remove so that the remaining array is balanced.
Note: An array of size 1 is considered balanced as its maximum and minimum are equal, and the condition always holds true.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-removals-to-balance-array

𝗛𝗶𝗻𝘁:- Sorting the array and using the sliding window.

Code:- 

public class Solution {
    public int MinRemoval(int[] nums, int k) {
        Array.Sort(nums);
        int i = 0;
        int maxLen = 0;
        
        for (int j = 0; j < nums.Length; j++) {
            while ((long)nums[j] > (long)nums[i] * k) {
                i++;
            }
            maxLen = Math.Max(maxLen, j - i + 1);
        }
        
        return nums.Length - maxLen;
    }
}
