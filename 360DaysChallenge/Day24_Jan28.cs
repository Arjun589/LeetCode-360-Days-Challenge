𝗗𝗮𝘆 24 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3651. Minimum Cost Path with Teleportations
You are given a m x n 2D integer array grid and an integer k. You start at the top-left cell (0, 0) and your goal is to reach the bottom‐right cell (m - 1, n - 1).
There are two types of moves available:
Normal move: You can move right or down from your current cell (i, j), i.e. you can move to (i, j + 1) (right) or (i + 1, j) (down). The cost is the value of the destination cell.
Teleportation: You can teleport from any cell (i, j), to any cell (x, y) such that grid[x][y] <= grid[i][j]; the cost of this move is 0. You may teleport at most k times.
Return the minimum total cost to reach cell (m - 1, n - 1) from (0, 0).

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-cost-path-with-teleportations



Approach:- 
Grid Initialization: It identifies the maximum value present in the grid to set up auxiliary arrays for teleportation costs.
Initial DP Pass: The code calculates the base walking cost from the bottom-right back to the top-left, assuming only downward and rightward moves are possible.
Teleportation Logic: It uses MinCostByValue and MinPrefixCost to track the cheapest way to reach any cell with a value less than or equal to the current cell's value.
Teleportation Steps: A loop runs for the number of allowed teleports, updating the minimum costs by choosing the best option between walking or jumping to a cell with a compatible value.
Cost Updates: During each teleportation pass, it updates the cost for every cell by comparing the previous walk cost with the new potential teleport cost.
Result: After all teleportation iterations are finished, it returns the value at the starting cell, which now contains the minimum cost for the entire trip.

Code:- 

public class Solution
{
    public int MinCost(int[][] Grid, int MaxTeleports)
    {
        int RowCount = Grid.Length;
        int ColumnCount = Grid[0].Length;
        int MaxValue = 0;

        for (int RowIndex = 0; RowIndex < RowCount; RowIndex++)
            for (int ColIndex = 0; ColIndex < ColumnCount; ColIndex++)
                MaxValue = Math.Max(MaxValue, Grid[RowIndex][ColIndex]);

        int[,] MinCosts = new int[RowCount, ColumnCount];
        int[] MinCostByValue = new int[MaxValue + 1];
        int[] MinPrefixCost = new int[MaxValue + 1];

        for (int ValueIndex = 0; ValueIndex <= MaxValue; ValueIndex++)
            MinCostByValue[ValueIndex] = int.MaxValue;

        MinCostByValue[Grid[RowCount - 1][ColumnCount - 1]] = 0;

        for (int ColIndex = ColumnCount - 2; ColIndex >= 0; ColIndex--)
        {
            MinCosts[RowCount - 1, ColIndex] = MinCosts[RowCount - 1, ColIndex + 1] + Grid[RowCount - 1][ColIndex + 1];
            MinCostByValue[Grid[RowCount - 1][ColIndex]] = Math.Min(MinCostByValue[Grid[RowCount - 1][ColIndex]], MinCosts[RowCount - 1, ColIndex]);
        }

        for (int RowIndex = RowCount - 2; RowIndex >= 0; RowIndex--)
        {
            MinCosts[RowIndex, ColumnCount - 1] = MinCosts[RowIndex + 1, ColumnCount - 1] + Grid[RowIndex + 1][ColumnCount - 1];
            MinCostByValue[Grid[RowIndex][ColumnCount - 1]] = Math.Min(MinCostByValue[Grid[RowIndex][ColumnCount - 1]], MinCosts[RowIndex, ColumnCount - 1]);

            for (int ColIndex = ColumnCount - 2; ColIndex >= 0; ColIndex--)
            {
                MinCosts[RowIndex, ColIndex] = Math.Min(
                    MinCosts[RowIndex + 1, ColIndex] + Grid[RowIndex + 1][ColIndex],
                    MinCosts[RowIndex, ColIndex + 1] + Grid[RowIndex][ColIndex + 1]
                );
                MinCostByValue[Grid[RowIndex][ColIndex]] = Math.Min(MinCostByValue[Grid[RowIndex][ColIndex]], MinCosts[RowIndex, ColIndex]);
            }
        }

        for (int TeleportStep = 0; TeleportStep < MaxTeleports; TeleportStep++)
        {
            MinPrefixCost[0] = MinCostByValue[0];
            for (int ValueIndex = 1; ValueIndex <= MaxValue; ValueIndex++)
                MinPrefixCost[ValueIndex] = Math.Min(MinPrefixCost[ValueIndex - 1], MinCostByValue[ValueIndex]);

            for (int ColIndex = ColumnCount - 2; ColIndex >= 0; ColIndex--)
            {
                MinCosts[RowCount - 1, ColIndex] = Math.Min(
                    MinPrefixCost[Grid[RowCount - 1][ColIndex]],
                    MinCosts[RowCount - 1, ColIndex + 1] + Grid[RowCount - 1][ColIndex + 1]
                );
                MinCostByValue[Grid[RowCount - 1][ColIndex]] = Math.Min(MinCostByValue[Grid[RowCount - 1][ColIndex]], MinCosts[RowCount - 1, ColIndex]);
            }

            for (int RowIndex = RowCount - 2; RowIndex >= 0; RowIndex--)
            {
                MinCosts[RowIndex, ColumnCount - 1] = Math.Min(
                    MinPrefixCost[Grid[RowIndex][ColumnCount - 1]],
                    MinCosts[RowIndex + 1, ColumnCount - 1] + Grid[RowIndex + 1][ColumnCount - 1]
                );
                MinCostByValue[Grid[RowIndex][ColumnCount - 1]] = Math.Min(MinCostByValue[Grid[RowIndex][ColumnCount - 1]], MinCosts[RowIndex, ColumnCount - 1]);

                for (int ColIndex = ColumnCount - 2; ColIndex >= 0; ColIndex--)
                {
                    int WalkCost = Math.Min(
                        MinCosts[RowIndex + 1, ColIndex] + Grid[RowIndex + 1][ColIndex],
                        MinCosts[RowIndex, ColIndex + 1] + Grid[RowIndex][ColIndex + 1]
                    );

                    MinCosts[RowIndex, ColIndex] = Math.Min(WalkCost, MinPrefixCost[Grid[RowIndex][ColIndex]]);
                    MinCostByValue[Grid[RowIndex][ColIndex]] = Math.Min(MinCostByValue[Grid[RowIndex][ColIndex]], MinCosts[RowIndex, ColIndex]);
                }
            }
        }

        return MinCosts[0, 0];
    }
}
