𝗗𝗮𝘆 39 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3713. Longest Balanced Substring I
You are given a string s consisting of lowercase English letters.
A substring of s is called balanced if all distinct characters in the substring appear the same number of times.
Return the length of the longest balanced substring of s.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/longest-balanced-substring-i

𝗛𝗶𝗻𝘁:- 1.Try fixing a starting index and expand the substring to the right while maintaining a frequency array of characters.
2. After each extension, check whether all non-zero frequencies are equal; if so, update the maximum length.


Code:-

public class Solution
{
    private bool IsValid(int[] FrequencyArray)
    {
        int TargetCount = 0;

        for (int Index = 0; Index < FrequencyArray.Length; Index++)
        {
            if (FrequencyArray[Index] == 0)
                continue;

            if (TargetCount == 0)
                TargetCount = FrequencyArray[Index];
            else if (FrequencyArray[Index] != TargetCount)
                return false;
        }

        return true;
    }

    public int LongestBalanced(string InputString)
    {
        int MaxLength = int.MinValue;

        for (int StartIndex = 0; StartIndex < InputString.Length; StartIndex++)
        {
            int[] FrequencyArray = new int[26];

            for (int EndIndex = StartIndex; EndIndex < InputString.Length; EndIndex++)
            {
                FrequencyArray[InputString[EndIndex] - 'a']++;

                if (IsValid(FrequencyArray))
                    MaxLength = Math.Max(MaxLength, EndIndex - StartIndex + 1);
            }
        }

        return MaxLength;
    }
}
