𝗗𝗮𝘆 13 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.
  
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-3047. Find the Largest Area of Square Inside Two Rectangles.
There exist n rectangles in a 2D plane with edges parallel to the x and y axis. You are given two 2D integer arrays bottomLeft and topRight where bottomLeft[i] = [a_i, b_i] and topRight[i] = [c_i, d_i] represent the bottom-left and top-right coordinates of the ith rectangle, respectively.
You need to find the maximum area of a square that can fit inside the intersecting region of at least two rectangles. Return 0 if such a square does not exist.
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/find-the-largest-area-of-square-inside-two-rectangles
𝗛𝗶𝗻𝘁:- This problem is easy bit need to spend some time to observe the rectangle in 2d Plane, use paper and pen to visualise and then solve.

Approach :- check x1,x2, y1, y2 for overlappings, if any see length y2-y1 and width x2 - x1 and take min because for square to form of let's say width 4 and len 2 we can form max square of size 2.
  
code:- 
public class Solution {
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight) {
        long maxSquare = 0;

        for (int i = 0; i < bottomLeft.Length - 1; i++) {
            for (int j = i + 1; j < bottomLeft.Length; j++) {
                int x1 = Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                int y1 = Math.Max(bottomLeft[i][1], bottomLeft[j][1]);
                int x2 = Math.Min(topRight[i][0], topRight[j][0]);
                int y2 = Math.Min(topRight[i][1], topRight[j][1]);

                if (x1 < x2 && y1 < y2) {
                    int side = Math.Min(x2 - x1, y2 - y1);
                    maxSquare = Math.Max(maxSquare, (long)side * side);
                }
            }
        }

        return maxSquare;
    }
}
