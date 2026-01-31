𝗗𝗮𝘆 27 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 744. Find Smallest Letter Greater Than Target
You are given an array of characters letters that is sorted in non-decreasing order, and a character target. There are at least two different characters in letters.
Return the smallest character in letters that is lexicographically greater than target. If such a character does not exist, return the first character in letters.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/find-smallest-letter-greater-than-target

𝗛𝗶𝗻𝘁:- simple traverse and check in current letter > target and less than previous answer if any.

Code:

public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        char ans = '.';
        foreach(char ch in letters)
        {
            if(ch > target && (ans == '.' || ch < ans)) ans = ch;
        }
        return ans == '.' ? letters[0] : ans;
    }
}

