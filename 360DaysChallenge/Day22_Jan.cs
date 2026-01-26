𝗗𝗮𝘆 22 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-1200. Minimum Absolute Difference
Given an array of distinct integers arr, find all pairs of elements with the minimum absolute difference of any two elements.
Return a list of pairs in ascending order(with respect to pairs), each pair [a, b] follows 1. a, b are from arr. 2. a < b 3.  b - a equals to the minimum absolute difference of any two elements in arr.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-absolute-difference

Approach:- 
sort and find the min diff.
traverse and see which and all pairs have this diff. (as the diff is minimum you don't need to check rightside right i.e: for i you need to check only i + 1)


                                                      
public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(arr);
        int min = int.MaxValue;
        for(int i = 0; i < arr.Length - 1; i++)
        {
            int diff = arr[i+1] - arr[i];
            min = Math.Min(diff, min);
        }

        for(int i = 0; i < arr.Length - 1; i++)
        {
            int diff = arr[i+1] - arr[i];
            if(diff == min)
            {
                res.Add(new List<int>() {arr[i], arr[i+1]});
            }
        }

        return res;

    }
}
