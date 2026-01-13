𝗗𝗮𝘆 9 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- Separate Squares I
You are given a 2D integer array squares. Each squares[i] = [xi, yi, li] represents the coordinates of the bottom-left point and the side length of a square parallel to the x-axis.
Find the minimum y-coordinate value of a horizontal line such that the total area of the squares above the line equals the total area of the squares below the line.
Answers within 10-5 of the actual answer will be accepted.
Note: Squares may overlap. Overlapping areas should be counted multiple times.
  
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/separate-squares-i

𝗛𝗶𝗻𝘁:- You need to find the coordinate (0,y) between min y and max y, which search you would use to do it, second - find out the higher and lower total area of squares with reference to y = c line. (This is a very interesting problem, It took some time to get the correct solution but the time is totally worth it)

yt video explanation by some youtuber :- https://www.youtube.com/watch?v=CBmJx5Ad3rs

Code


public class Solution {
    private double Helper(double line, int[][] squares) {
        double aAbove = 0, aBelow = 0;
        
        foreach (var square in squares) {
            int y = square[1], l = square[2];
            double total = (double) l * l;
            
            if (line <= y) {
                aAbove += total;
            } else if (line >= y + l) {
                aBelow += total;
            } else {
                double aboveHeight = (y + l) - line;
                double belowHeight = line - y;
                aAbove += l * aboveHeight;
                aBelow += l * belowHeight;
            }
        }
        
        return aAbove - aBelow;
    }

    public double SeparateSquares(int[][] squares) {
        double lo = 0, hi = 2e9;
        
        for (int i = 0; i < 100; i++) { // Increased iterations for precision
            double mid = (lo + hi) * 0.5;
            double diff = Helper(mid, squares);
            
            if (diff > 1e-9) { // Added small tolerance to avoid precision issues
                lo = mid;
            } else {
                hi = mid;
            }
        }
        
        return hi;
    }
}
