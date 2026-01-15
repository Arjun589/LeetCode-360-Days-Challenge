𝗗𝗮𝘆 11 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 2943. Maximize Area of Square Hole in Grid
-> You are given the two integers, n and m and two integer arrays, hBars and vBars. The grid has n + 2 horizontal and m + 2 vertical bars, creating 1 x 1 unit cells. The bars are indexed starting from 1.
You can remove some of the bars in hBars from horizontal bars and some of the bars in vBars from vertical bars. Note that other bars are fixed and cannot be removed.
Return an integer denoting the maximum area of a square-shaped hole in the grid, after removing some bars (possibly none).
  
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/maximize-area-of-square-hole-in-grid

𝗛𝗶𝗻𝘁:- can we try to find out the maxlength of square and maxwidth of square after removing the bars from the total bars.

Code:- 

public class Solution {
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        int maxlen = 0;
        int maxwidth = 0;
        int prev = 0;
        Array.Sort(hBars);
        Array.Sort(vBars);
        for(int i =0; i< hBars.Length; i++)
        {
            int distance = 2;
            if(i != 0 && hBars[i] == hBars[i-1] + 1)
            {
                
                distance += prev - 1;
            }
            prev = distance;
            maxlen = Math.Max(maxlen, distance);
        }
        Console.WriteLine(maxlen);
        prev = 0;
        for(int i =0; i< vBars.Length; i++)
        {
            int distance = 2;
            if(i != 0 && vBars[i] == vBars[i-1] + 1)
            {
                distance += prev - 1;
            }
            prev = distance;
            maxwidth = Math.Max(maxwidth, distance);
        }
        Console.WriteLine(maxwidth);

        int square = Math.Min(maxwidth, maxlen); // because as it is a square length and breadth has to be equal size.
        return square * square;
    }
}
