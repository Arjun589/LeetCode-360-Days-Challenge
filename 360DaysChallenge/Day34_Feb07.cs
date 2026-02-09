𝗗𝗮𝘆 34 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 1653. Minimum Deletions to Make String Balanced
You are given a string s consisting only of characters 'a' and 'b'​​​​.
You can delete any number of characters in s to make s balanced. s is balanced if there is no pair of indices (i,j) such that i < j and s[i] = 'b' and s[j]= 'a'.
Return the minimum number of deletions needed to make s balanced.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-deletions-to-make-string-balanced

Approach:- https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/solutions/7559064/b-ks-solution-100-beats-very-simple-solu-4b6z

Code:-


public class Solution {
    public int MinimumDeletions(string s) {
        int b_before_a = 0, deletion = 0;
        for(int i = 0; i < s.Length; i++) {
            if(s[i] == 'b') b_before_a += 1;
            else if(b_before_a > 0 ) {
                b_before_a -= 1;
                deletion += 1;
            }
        }   
        return deletion;
    }
}

