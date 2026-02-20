𝗗𝗮𝘆 47 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- Special binary strings are binary strings with the following two properties:
The number of 0's is equal to the number of 1's.
Every prefix of the binary string has at least as many 1's as 0's.
You are given a special binary string s.
A move consists of choosing two consecutive, non-empty, special substrings of s, and swapping them. Two strings are consecutive if the last character of the first string is exactly one index before the first character of the second string.
Return the lexicographically largest resulting string possible after applying the mentioned operations on the string.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/special-binary-string

𝗛𝗶𝗻𝘁:-1. Break the string into its smallest "special" units (where the number of 1s first equals the number of 0s).
2. Recursively process the inside of each unit (everything between the first 1 and last 0) to ensure its internal parts are also optimized.
3. Sort the processed units in descending lexicographical order and join them back together to create the largest possible binary number.


Code:-

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string MakeLargestSpecial(string s) {
        if (string.IsNullOrEmpty(s)) return "";

        List<string> res = new List<string>();
        int count = 0, i = 0;

        for (int j = 0; j < s.Length; j++) {
            if (s[j] == '1') count++;
            else count--;

            if (count == 0) {
                res.Add("1" + MakeLargestSpecial(s.Substring(i + 1, j - i - 1)) + "0");
                i = j + 1;
            }
        }

        res.Sort((a, b) => b.CompareTo(a));
        return string.Join("", res);
    }
}
