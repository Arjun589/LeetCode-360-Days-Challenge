𝗗𝗮𝘆 43 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 190. Reverse Bits
Reverse bits of a given 32 bits signed integer.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/reverse-bits

𝗛𝗶𝗻𝘁:- 1.Iterate through all 32 bit positions, extract each bit of n using right shift and & 1.
2. Build the reversed number by left-shifting the result and OR-ing the extracted bit each time.

Code:- 

public class Solution {
    public int ReverseBits(int n) {
        int rev = 0;
        for(int i = 0; i < 32; i++) {
            rev = (rev << 1) | ((n >> i) & 1);
        }
        return rev;
    }
}
