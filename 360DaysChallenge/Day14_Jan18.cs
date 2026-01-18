𝗗𝗮𝘆 14 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-1895. Largest Magic Square
A k x k magic square is a k x k grid filled with integers such that every row sum, every column sum, and both diagonal sums are all equal. The integers in the magic square do not have to be distinct. Every 1 x 1 grid is trivially a magic square.
Given an m x n integer grid, return the size (i.e., the side length k) of the largest magic square that can be found within this grid.
  
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/largest-magic-square

𝗛𝗶𝗻𝘁:- Hint: Use 2D prefix sums for rows, columns, and both diagonals to validate any square's "magic" property in linear time. Iterate through the grid starting from the largest possible side length k down to 1.

explaination :- 
1.A magic square of size k by k is a grid where all rows, all columns, and both the main diagonal and anti-diagonal sum up to the same value. Every 1 by 1 grid is automatically a magic square.
2. To avoid recalculating sums repeatedly, create four 2D arrays to store running totals for the entire grid:
Row Prefix Sums: Stores cumulative sums for each row.
Column Prefix Sums: Stores cumulative sums for each column.
Diagonal Prefix Sums: Stores cumulative sums for diagonals running from top-left to bottom-right.
Anti-Diagonal Prefix Sums: Stores cumulative sums for diagonals running from top-right to bottom-left.
3. Iterate Through Possible Sizes
Start checking from the largest possible side length k, which is the minimum of the grid's height or width. Check every possible k by k square in the grid. If you find a magic square of size k, return k immediately since you are searching from largest to smallest.
4. Validate Each Square
For a specific k by k square starting at row r and column c:
Determine the target sum using the first row.
Use the prefix sum arrays to calculate the sum of every other row and column in O(1) time.
Use the diagonal prefix sum arrays to calculate the sum of the two diagonals in O(1) time.
If all these sums equal the target sum, the square is magic.
5. The time complexity is O(m * n * min(m, n)) because you check every cell as a potential top-left corner and validate the square in linear time. The space complexity is O(m * n) to store the prefix sum arrays.

Code:

public class Solution {
    public int LargestMagicSquare(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        int[,] rowSum = new int[m, n + 1];
        int[,] colSum = new int[m + 1, n];
        int[,] diagSum = new int[m + 1, n + 1];
        int[,] antiDiagSum = new int[m + 1, n + 1];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                rowSum[i, j + 1] = rowSum[i, j] + grid[i][j];
                colSum[i + 1, j] = colSum[i, j] + grid[i][j];
                diagSum[i + 1, j + 1] = diagSum[i, j] + grid[i][j];
                antiDiagSum[i + 1, j] = antiDiagSum[i, j + 1] + grid[i][j];
            }
        }

        for (int k = Math.Min(m, n); k > 1; k--) {
            for (int i = 0; i <= m - k; i++) {
                for (int j = 0; j <= n - k; j++) {
                    if (IsMagic(grid, i, j, k, rowSum, colSum, diagSum, antiDiagSum)) {
                        return k;
                    }
                }
            }
        }
        return 1;
    }

    private bool IsMagic(int[][] grid, int r, int c, int k, 
                         int[,] rs, int[,] cs, int[,] ds, int[,] ads) {
        int target = rs[r, c + k] - rs[r, c];

        for (int i = r + 1; i < r + k; i++) {
            if (rs[i, c + k] - rs[i, c] != target) return false;
        }

        for (int j = c; j < c + k; j++) {
            if (cs[r + k, j] - cs[r, j] != target) return false;
        }

        if (ds[r + k, c + k] - ds[r, c] != target) return false;
        if (ads[r + k, c] - ads[r, c + k] != target) return false;

        return true;
    }
}
