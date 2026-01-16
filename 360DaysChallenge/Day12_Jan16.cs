𝗗𝗮𝘆 12 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-2975. Maximum Square Area by Removing Fences From a Field
There is a large (m - 1) x (n - 1) rectangular field with corners at (1, 1) and (m, n) containing some horizontal and vertical fences given in arrays hFences and vFences respectively.
Horizontal fences are from the coordinates (hFences[i], 1) to (hFences[i], n) and vertical fences are from the coordinates (1, vFences[i]) to (m, vFences[i]).
Return the maximum area of a square field that can be formed by removing some fences (possibly none) or -1 if it is impossible to make a square field.
Since the answer may be large, return it modulo 109 + 7.
Note: The field is surrounded by two horizontal fences from the coordinates (1, 1) to (1, n) and (m, 1) to (m, n) and two vertical fences from the coordinates (1, 1) to (m, 1) and (1, n) to (m, n). These fences cannot be removed.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/maximum-square-area-by-removing-fences-from-a-field

𝗛𝗶𝗻𝘁:- There can be many solutions, I went with brute force approach to find the possible lengths and possible widths.

Code:- 


public class Solution {
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {
        HashSet<int> possibleHeights = new();
        HashSet<int> possibleWidths = new();

        // Add full height as possible
        possibleHeights.Add(m - 1);

        // Collect possible vertical distances from horizontal fences
        for (int i = 0; i < hFences.Length; i++) {
            int starting = hFences[i] - 1;
            int ending = m - hFences[i];

            for (int j = i + 1; j < hFences.Length; j++) {
                int diff = Math.Abs(hFences[i] - hFences[j]);
                possibleHeights.Add(diff);
            }

            possibleHeights.Add(starting);
            possibleHeights.Add(ending);
        }

        int res = -1;

        // Add full width as possible
        possibleWidths.Add(n - 1);

        if (possibleHeights.Contains(n - 1)) {
            res = Math.Max(res, n - 1);
        }

        // Collect possible horizontal distances from vertical fences
        for (int i = 0; i < vFences.Length; i++) {
            int starting = vFences[i] - 1;
            int ending = n - vFences[i];

            for (int j = i + 1; j < vFences.Length; j++) {
                int diff = Math.Abs(vFences[i] - vFences[j]);
                if (possibleHeights.Contains(diff)) {
                    res = Math.Max(res, diff);
                }
                possibleWidths.Add(diff);
            }

            if (possibleHeights.Contains(starting)) {
                res = Math.Max(res, starting);
            }
            possibleWidths.Add(starting);

            if (possibleHeights.Contains(ending)) {
                res = Math.Max(res, ending);
            }
            possibleWidths.Add(ending);
        }

        if (res == -1) return -1;

        int mod = 1000000007;
        return (int)(((long)res * res) % mod);
    }
}
