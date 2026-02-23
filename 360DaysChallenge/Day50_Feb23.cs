𝗗𝗮𝘆 50 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 1461. Check If a String Contains All Binary Codes of 
Given a binary string s and an integer k, return true if every binary code of length k is a substring of s. Otherwise, return false.
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k

𝗛𝗶𝗻𝘁:- Don't try to solve the problems with the steps it required, instead try to find the unique substrings with length k and match with expected substring 2 ^ k.

Code:-

public class Solution {
    public bool HasAllCodes(string s, int k) {
        HashSet<string> hash = new ();
        for(int i = 0; i <= s.Length - k; i++)
        {
            string se = "";
            for(int j = i; j < i + k; j++)
            {
                se += s[j];
            }
            hash.Add(se);
        }
        int size = (int)Math.Pow(2,k);
        return size == hash.Count;
    }
}

