𝗗𝗮𝘆 20 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-1877. Minimize Maximum Pair Sum in Array, 
sum of a pair (a,b) is equal to a + b. The maximum pair sum is the largest pair sum in a list of pairs.
For example, if we have pairs (1,5), (2,3), and (4,4), the maximum pair sum would be max(1+5, 2+3, 4+4) = max(6, 5, 8) = 8.
Given an array nums of even length n, pair up the elements of nums into n / 2 pairs such that:
Each element of nums is in exactly one pair, and
The maximum pair sum is minimized.
Return the minimized maximum pair sum after optimally pairing up the elements.
  
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimize-maximum-pair-sum-in-array

𝗛𝗶𝗻𝘁:- frequency counting with two pointer approach.

Approach : - https://leetcode.com/problems/minimize-maximum-pair-sum-in-array/solutions/4297260/beats-100-two-pointers-no-sorting-time-o-0vse

Code:-

public class Solution {
    public int MinPairSum(int[] nums) {
        int[] freq = new int[100001]; 
        
        foreach (int num in nums) {
            freq[num]++;
        }

        int left = 1; // Smallest possible number in nums
        int right = 100000; // Largest possible number in nums
        int maxPairSum = 0;

        while (left <= right) {
            if (freq[left] == 0) {
                left++;
                continue;
            }
            
            if (freq[right] == 0) {
                right--;
                continue;
            }
            
            // Pair the smallest available number with the largest available number
            maxPairSum = Math.Max(maxPairSum, left + right);
            
            freq[left]--;
            freq[right]--;
        }

        return maxPairSum;
    }
}

