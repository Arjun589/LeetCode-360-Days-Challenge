𝗗𝗮𝘆 44 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 1401. Binary Watch
A binary watch has 4 LEDs on the top to represent the hours (0-11), and 6 LEDs on the bottom to represent the minutes (0-59). Each LED represents a zero or one, with the least significant bit on the right.
For example, the below binary watch reads "4:51".
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/binary-watch

𝗛𝗶𝗻𝘁:- Iterate through all possible hours (0–11) and minutes (0–59) using nested loops. 
Check if the total number of set bits in the binary forms of both values equals turnedOn.

Code:- 

using System;
using System.Collections.Generic;

public class Solution {
    public IList<string> ReadBinaryWatch(int turnedOn) {
        List<string> result = new List<string>();

        for (int h = 0; h < 12; h++) {
            for (int m = 0; m < 60; m++) {
                if (BitCount(h) + BitCount(m) == turnedOn) {
                    result.Add($"{h}:{m:D2}");
                }
            }
        }

        return result;
    }

    private int BitCount(int n) {
        int count = 0;
        while (n > 0) {
            n &= (n - 1);
            count++;
        }
        return count;
    }
}
