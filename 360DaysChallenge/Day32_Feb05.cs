𝗗𝗮𝘆 32 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3013. Divide an Array Into Subarrays With Minimum
You are given a 0-indexed array of integers nums of length n, and two positive integers k and dist.
The cost of an array is the value of its first element. For example, the cost of [1,2,3] is 1 while the cost of [3,4,1] is 3.
You need to divide nums into k disjoint contiguous subarrays, such that the difference between the starting index of the second subarray and the starting index of the kth subarray should be less than or equal to dist. In other words, if you divide nums into the subarrays nums[0..(i1 - 1)], nums[i1..(i2 - 1)], ..., nums[ik-1..(n - 1)], then ik-1 - i1 <= dist.
Return the minimum possible sum of the cost of these subarrays.
  
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/transformed-array/description

𝗛𝗶𝗻𝘁:- For each index i, calculate a new circular index by shifting i by nums[i] steps, using modulo arithmetic to handle both positive and negative offsets.
Populate the result array by fetching the value at each calculated index, ensuring the logic wraps around the array boundaries correctly.


Code:-

public class Solution {
    public int[] ConstructTransformedArray(int[] nums) {
        int n = nums.Length;
        int[] result = new int[n];
        for(int i = 0; i<n; i++){
            int index = i;
            if(nums[i] == 0) index = i;
            else if(nums[i] > 0) index = (i + nums[i]);
            else index = (i+ n - (Math.Abs(nums[i])) % n);
            index = (index) % n;
            result[i] = nums[index]; 
                    }
        return result;        
    }
}
