𝗗𝗮𝘆 17 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-3315. Construct the Minimum Bitwise Array II
You are given an array nums consisting of n prime integers.
You need to construct an array ans of length n, such that, for each index i, the bitwise OR of ans[i] and ans[i] + 1 is equal to nums[i], i.e. ans[i] OR (ans[i] + 1) == nums[i].
Additionally, you must minimize each value of ans[i] in the resulting array.
If it is not possible to find such a value for ans[i] that satisfies the condition, then set ans[i] = -1.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/construct-the-minimum-bitwise-array-ii

𝗛𝗶𝗻𝘁:- Identify the lowest unset bit (the first 0 from the right) and manipulating the bits around it.

Approach;-
To understand this one liner, you need to see what happens to the binary bits of an odd number when you add 1 and apply the Lowest Set Bit trick.
The goal is to flip the highest 1 in the trailing block of 1s. For example, in 10111, we want to flip the 1 in the 4s place to get 10011.
The Step by Step Breakdown
Let us use n = 11 (binary 1011) as our example:
1. n + 1 (The Carrying Phase)
Binary 1011 + 1 = 1100. Adding 1 turns all the trailing 1s into 0s and turns the first 0 from the right into a 1. This 1 marks the boundary of where the trailing ones used to be.
2. ((n + 1) & -(n + 1)) (The Isolation Phase)
This is a famous bitwise trick. It isolates the lowest set bit (the rightmost 1) of a number. In our example: 1100 AND (...0100) = 0100 (which is 4 in decimal). This value is always a power of 2 that represents the bit just above the original trailing ones.
3. / 2 or >> 1 (The Alignment Phase)
We take that isolated bit (4) and divide it by 2 to get 2 (binary 0010). This shifts our focus back down by one bit, landing exactly on the highest bit of the original trailing 1s.
4. n - ... (The Flipping Phase)
Finally, we take the original n (11) and subtract that power of two (2). 11 minus 2 = 9. Binary: 1011 minus 0010 = 1001. Result: 9. (Check: 9 OR 10 = 11. Correct!)

Why this works for all cases
Because the input nums are primes (and we handle 2 separately), they are all odd. Every odd number ends in at least one 1. By finding the first 0 (via n + 1) and then moving back one step, we are guaranteed to find the specific bit that, when flipped to 0, allows the x + 1 operation to fill it back in during the OR operation.

Code:- 
public class Solution {
    public int[] MinBitwiseArray(IList<int> nums) {
        int[] ans = new int[nums.Count];
        for(int i = 0; i < nums.Count; i++) {
            int n = nums[i];
            if(n != 2) ans[i] = n - (((n + 1) & -(n + 1)) >> 1);
            else ans[i] = -1;
        }  
        return ans;
    }
}
