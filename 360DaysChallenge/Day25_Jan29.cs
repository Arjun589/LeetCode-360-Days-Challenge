𝗗𝗮𝘆 25 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 32976. Minimum Cost to Convert String I
You are given two 0-indexed strings source and target, both of length n and consisting of lowercase English letters. You are also given two 0-indexed character arrays original and changed, and an integer array cost, where cost[i] represents the cost of changing the character original[i] to the character changed[i].
You start with the string source. In one operation, you can pick a character x from the string and change it to the character y at a cost of z if there exists any index j such that cost[j] == z, original[j] == x, and changed[j] == y.
Return the minimum cost to convert the string source to the string target using any number of operations. If it is impossible to convert source to target, return -1.
Note that there may exist indices i, j such that original[j] == original[i] and changed[j] == changed[i].

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-cost-to-convert-string-i

𝗛𝗶𝗻𝘁:- Optimal Floyd-Warshall + Linear Pass 

Approach:- https://leetcode.com/problems/minimum-cost-to-convert-string-i/solutions/7534113/optimal-floyd-warshall-linear-pass-c-by-1sde1


// Floyd-Warshall 
public class Solution {
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
        const long INF = long.MaxValue / 2;
        long[,] minCost = new long[26, 26];

        // Initialize graph: self = 0, others = INF
        for (int i = 0; i < 26; i++) {
            for (int j = 0; j < 26; j++) {
                minCost[i, j] = (i == j) ? 0 : INF;
            }
        }

        // Add transformation edges (take minimum if multiple)
        for (int i = 0; i < original.Length; i++) {
            int u = original[i] - 'a';
            int v = changed[i] - 'a';
            minCost[u, v] = Math.Min(minCost[u, v], cost[i]);
        }

        // Floyd-Warshall: compute shortest path between all pairs
        for (int k = 0; k < 26; k++) {
            for (int i = 0; i < 26; i++) {
                for (int j = 0; j < 26; j++)  {
                    if (minCost[i, k] < INF && minCost[k, j] < INF) minCost[i, j] = Math.Min(minCost[i, j], minCost[i, k] + minCost[k, j]);
                }
            }
        }

        // Compute total cost position by position
        long total = 0;
        for (int i = 0; i < source.Length; i++) {
            int u = source[i] - 'a';
            int v = target[i] - 'a';

            if (minCost[u, v] >= INF) return -1;
            total += minCost[u, v];
        }

        return total;
    }
}
