𝗗𝗮𝘆 15 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-3314. Construct the Minimum Bitwise Array I
You are given an array nums consisting of n prime integers.
You need to construct an array ans of length n, such that, for each index i, the bitwise OR of ans[i] and ans[i] + 1 is equal to nums[i], i.e. ans[i] OR (ans[i] + 1) == nums[i].
Additionally, you must minimize each value of ans[i] in the resulting array.
If it is not possible to find such a value for ans[i] that satisfies the condition, then set ans[i] = -1.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/construct-the-minimum-bitwise-array-i

𝗛𝗶𝗻𝘁:- Brute force will work, as constraints are small.

Code:- 
  public class Solution {
    public int[] MinBitwiseArray(IList<int> nums) {
        int[] res = new int[nums.Count];
        for(int i= 0; i < nums.Count; i++)
        {
            if(nums[i] % 2 == 0) res[i] = -1;
            else
            {
                int ans = 1;
                while(ans <= nums[i])
                {
                    if((ans | (ans+1)) == nums[i])
                    {
                        res[i] = ans;
                        break;
                    }
                    ans++;
                }
            }
        }
        
        return res;
    }
}
