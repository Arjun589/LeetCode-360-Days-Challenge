//Problem statement link :- https://leetcode.com/problems/maximum-matrix-sum/description/?envType=daily-question&envId=2026-01-05
//Approach 1:- Little bit of observation is required
// link to understand the full logic https://leetcode.com/problems/maximum-matrix-sum/solutions/6076882/very-simple-visualization-of-problem-wit-iw9u

//Approach 2 : intituive but not optimal.
// Initial Intuition
// When I first looked at this problem, a few ideas came to mind:

// Cell-wise operations: I considered whether each cell requires an operation or not, and whether it's necessary to process all cells individually.

// Traversal strategy: My instinct was to approach the matrix row by row, applying operations as I go.

// Operation possibilities: For each cell, I imagined four potential actions:
// Flip the sign of the current cell and its left neighbor.
// Flip the current cell and the one above it.
// Flip both pairs in any order.
// Or skip the cell and move on.

// Sum tracking: I aimed to compute the sum of all cells after applying these operations, and then return the maximum possible result.

// Challenges Faced
// Time Limit Exceeded (TLE): This brute-force approach quickly becomes inefficient due to the exponential number of possibilities.

// Memoization complexity: It’s difficult to cache intermediate results because the value of each cell depends on its neighbors — especially those in previous rows and columns — making the state space too complex to manage effectively.


//Code for approach : 

class Solution {
    public long MaxMatrixSum(int[][] matrix) {
      int min = int.MaxValue;
      long sum = 0;
      int negCount = 0; 
      for(int i=0; i<matrix.Length; i++)
      for(int j=0; j<matrix[0].Length; j++)
      {
         if(matrix[i][j]<0)
         negCount++;
         int ab = Math.Abs(matrix[i][j]);
         min = Math.Min(min, ab);
         sum += ab;    
      }
      if(negCount%2==0)
          return sum; 
      return sum - 2*min;
    }
}
