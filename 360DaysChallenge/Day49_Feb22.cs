𝗗𝗮𝘆 49 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 868. Binary Gap
Given a positive integer n, find and return the longest distance between any two adjacent 1's in the binary representation of n. If there are no two adjacent 1's, return 0.
Two 1's are adjacent if there are only 0's separating them (possibly no 0's). The distance between two 1's is the absolute difference between their bit positions. For example, the two 1's in "1001" have a distance of 3.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/binary-gap

𝗛𝗶𝗻𝘁:- Just do the right shift and find the maximum distance between two adjacent one's.


Code:

public class Solution {
    public int BinaryGap(int n) {
        int dist = 0;
        int count = -1;
        while(n != 0)
        {
            if(n % 2 != 0)
            {
                dist = Math.Max(dist, count);
                count = 0;
            }
            if(count != -1) count++;
            n = n >> 1;
        }
        return dist;
        
    }
}
