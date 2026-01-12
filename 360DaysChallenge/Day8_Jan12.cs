𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- Minimum Time Visiting All Points,

On a 2D plane, there are n points with integer coordinates points[i] = [xi, yi]. Return the minimum time in seconds to visit all the points in the order given by points.

You can move according to these rules:

-> In 1 second, you can either:

-> move vertically by one unit,

-> move horizontally by one unit, or

-> move diagonally sqrt(2) units (in other words, move one unit vertically then one unit horizontally in 1 second).

-> You have to visit the points in the same order as they appear in the array.

-> You are allowed to pass through points that appear later in the order, but these do not count as visits.



𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-time-visiting-all-points
Video explaination from youtube :- https://www.youtube.com/watch?v=_5bonINg9Aw

public class Solution {
    public int MinTimeToVisitAllPoints(int[][] points) {
        int minimum = 0;
        for(int i = 1; i < points.Length; i++)
        {
            //we are planning to move from (a,b) to (x,y), First move diagonally and then move horizantal or vertical.
            int a = points[i-1][0], b = points[i-1][1];
            int x = points[i][0], y = points[i][1];
            minimum += Math.Max(Math.Abs(a-x), Math.Abs(b-y));
        }

        return minimum;
    }
}
