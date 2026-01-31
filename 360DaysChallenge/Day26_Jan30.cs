𝗗𝗮𝘆 26 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 2977. Minimum Cost to Convert String II
You are given two 0-indexed strings source and target, both of length n and consisting of lowercase English characters. You are also given two 0-indexed string arrays original and changed, and an integer array cost, where cost[i] represents the cost of converting the string original[i] to the string changed[i].
You start with the string source. In one operation, you can pick a substring x from the string, and change it to y at a cost of z if there exists any index j such that cost[j] == z, original[j] == x, and changed[j] == y. You are allowed to do any number of operations, but any pair of operations must satisfy either of these two conditions:
The substrings picked in the operations are source[a..b] and source[c..d] with either b < c or d < a. In other words, the indices picked in both operations are disjoint.
The substrings picked in the operations are source[a..b] and source[c..d] with a == c and b == d. In other words, the indices picked in both operations are identical.
Return the minimum cost to convert the string source to the string target using any number of operations. If it is impossible to convert source to target, return -1.
Note that there may exist indices i, j such that original[j] == original[i] and changed[j] == changed[i].

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-cost-to-convert-string-ii

𝗛𝗶𝗻𝘁:- use dynamic programming, where f[i] tracks the minimum cost to convert the prefix up to index i, transitioning by either matching characters or applying a precomputed word replacement.



    public class Trie {
    public Trie[] child = new Trie[26];
    public int id = -1;
}

public class Solution {
    private const int INF = int.MaxValue / 2;

    private int Add(Trie node, string word, ref int index) {
        foreach (char ch in word) {
            int i = ch - 'a';
            if (node.child[i] == null) {
                node.child[i] = new Trie();
            }
            node = node.child[i];
        }
        if (node.id == -1) {
            node.id = ++index;
        }
        return node.id;
    }

    private void Update(ref long x, long y) {
        if (x == -1 || y < x) {
            x = y;
        }
    }

    public long MinimumCost(string source, string target, string[] original,
                            string[] changed, int[] cost) {
        int n = source.Length;
        int m = original.Length;
        Trie root = new Trie();

        int p = -1;
        int[,] G = new int[m * 2, m * 2];

        for (int i = 0; i < m * 2; i++) {
            for (int j = 0; j < m * 2; j++) {
                G[i, j] = INF;
            }
            G[i, i] = 0;
        }

        for (int i = 0; i < m; i++) {
            int x = Add(root, original[i], ref p);
            int y = Add(root, changed[i], ref p);
            G[x, y] = Math.Min(G[x, y], cost[i]);
        }

        int size = p + 1;
        for (int k = 0; k < size; k++) {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    G[i, j] = Math.Min(G[i, j], G[i, k] + G[k, j]);
                }
            }
        }

        long[] f = new long[n];
        Array.Fill(f, -1);
        for (int j = 0; j < n; j++) {
            if (j > 0 && f[j - 1] == -1) {
                continue;
            }
            long baseVal = (j == 0 ? 0 : f[j - 1]);
            if (source[j] == target[j]) {
                Update(ref f[j], baseVal);
            }

            Trie u = root;
            Trie v = root;
            for (int i = j; i < n; i++) {
                u = u.child[source[i] - 'a'];
                v = v.child[target[i] - 'a'];
                if (u == null || v == null) {
                    break;
                }
                if (u.id != -1 && v.id != -1 && G[u.id, v.id] != INF) {
                    long newVal = baseVal + G[u.id, v.id];
                    Update(ref f[i], newVal);
                }
            }
        }

        return f[n - 1];
    }
}
