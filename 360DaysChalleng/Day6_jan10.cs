//Problem statement:- Given two strings s1 and s2, return the lowest ASCII sum of deleted characters to make two strings equal.
// Example 1:

// Input: s1 = "sea", s2 = "eat"
// Output: 231
// Explanation: Deleting "s" from "sea" adds the ASCII value of "s" (115) to the sum.
// Deleting "t" from "eat" adds 116 to the sum.
// At the end, both strings are equal, and 115 + 116 = 231 is the minimum sum possible to achieve this.

//link:- https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings

//Approach:- 
// By looking at lowest/ minimum sum and different options to process each node i got idea this is dp.
// look at possible ways
// it s1[i] == s2[j] no need to remove anything, just move i + 1, j+1;
//else we have two options whether to delete character from s1 or s2, try two ways and add the sum to your answer
//return min sum

//base case; if(both of strings are completed or any one of them is completed 
//look for what is not completed and add it to your sum.




public class Solution {
    public int helper(int i, int j,string s1, string s2, int[][] dp)
    {
        int sum = 0;
        if(i >= s1.Length || j >= s2.Length) 
        {
            while(i < s1.Length) {sum += s1[i]; i++;}
            while (j < s2.Length) { sum += s2[j]; j ++;}
            return sum;
        }
        if(dp[i][j] != - 1) return dp[i][j];
        if(s1[i] == s2[j]) return dp[i][j] = helper(i+1, j+1, s1, s2, dp);
        return dp[i][j] = Math.Min((int) s1[i] + helper(i + 1, j, s1, s2, dp), (int) s2[j] + helper(i, j+1, s1,s2, dp));

    }
    public int MinimumDeleteSum(string s1, string s2) {
        int[][] dp = new int[s1.Length][];
        for(int i = 0; i < s1.Length; i++)
        {
            dp[i] = new int[s2.Length];
            Array.Fill(dp[i], -1);
        }
        return helper(0, 0, s1, s2, dp);
    }
}
