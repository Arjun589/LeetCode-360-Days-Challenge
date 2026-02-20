𝗗𝗮𝘆 46 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.



𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 696. Count Binary Substrings

Given a binary string s, return the number of non-empty substrings that have the same number of 0's and 1's, and all the 0's and all the 1's in these substrings are grouped consecutively.

Substrings that occur multiple times are counted the number of times they occur.



𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/count-binary-substrings



𝗛𝗶𝗻𝘁:-1. Traverse the string once and count lengths of consecutive same-character runs (e.g., "001110" → 2,3,1).

2. For every adjacent pair of runs, add min(previousRunLength, currentRunLength) to the result.


Code:- 




public class Solution
{
    public int CountBinarySubstrings(string InputString)
    {
        int PreviousRunLength = 0;
        int CurrentRunLength = 1;
        int TotalSubstrings = 0;

        for (int Index = 1; Index < InputString.Length; Index++)
        {
            if (InputString[Index] == InputString[Index - 1])
                CurrentRunLength++;
            else
            {
                PreviousRunLength = CurrentRunLength;
                CurrentRunLength = 1;
            }

            if (PreviousRunLength >= CurrentRunLength)
                TotalSubstrings++;
        }

        return TotalSubstrings;
    }
}
