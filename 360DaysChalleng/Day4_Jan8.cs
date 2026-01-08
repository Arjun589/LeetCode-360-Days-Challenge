//Optimal approach is apprach 2;

//Apprach 2: - best approach
//Explaination :- https://youtu.be/4Ik4SPrRRmE?si=pevZLcYQACa9RF-M

//Code - 

public class Solution
{
    private int Func(int ind1, int ind2, int[] nums1, int[] nums2, int[,] dp)
    {
        int n1 = nums1.Length;
        int n2 = nums2.Length;

        if (ind1 == n1 || ind2 == n2) return (int)-1e9;

        if (dp[ind1, ind2] != -1) return dp[ind1, ind2];

        int takeBoth = nums1[ind1] * nums2[ind2] + Math.Max(0, Func(ind1 + 1, ind2 + 1, nums1, nums2, dp));
        int skip1 = Func(ind1 + 1, ind2, nums1, nums2, dp);
        int skip2 = Func(ind1, ind2 + 1, nums1, nums2, dp);

        dp[ind1, ind2] = Math.Max(takeBoth, Math.Max(skip1, skip2));
        return dp[ind1, ind2];
    }

    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length;
        int n2 = nums2.Length;

        int[,] dp = new int[n1, n2];
        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                dp[i, j] = -1;
            }
        }

        return Func(0, 0, nums1, nums2, dp);
    }
}
//Approach 1: - code below

// Intuition : - You have total 4 options to deal with each node, 
//1. take node from first array ( a. take node from second array b. dont take node from second array)) 
//2. whenever we are taking a node add it to respective list and move to next index
//3. edge cases when you are out of all nodes from first array and second array.
// this will fail because of TLE.


public class Solution {
    long product = int.MinValue;

    public int DotProduct(List<int> first, List<int> second)
    {
        int dotproduct = 0;
        int i = 0;
        while(i < first.Count)
        {
            dotproduct += (first[i] * second[i]);
            i++;
        }
        return dotproduct;
    }
    public long Helper(int index1,int index2, int[] n1, int[] n2, List<int> l1, List<int> l2)
    {
        
        if(index1 >= n1.Length && index2 >= n2.Length) 
        if(l1.Count == l2.Count && l1.Count != 0) return product = Math.Max(product, DotProduct(l1, l2));
        else return 1;
        long max = int.MinValue;
        //Take the element from the first array
        if(index1 < n1.Length)
        {
            l1.Add(n1[index1]);
            //Don't Take element from the second array
            max = Math.Max(max, Helper(index1 + 1, index2 + 1, n1, n2, l1, l2));
            //Take element from the second array
            if(index2 < n2.Length)
            {
                l2.Add(n2[index2]);
                max = Math.Max(max, Helper(index1 + 1, index2 + 1, n1, n2, l1, l2));
                l2.RemoveAt(l2.Count - 1);
            }
             l1.RemoveAt(l1.Count - 1);
        
        }
        


        //Not taking the element from first array
        //Not taking the element from second array
        max = Math.Max(max,Helper(index1 + 1, index2 + 1, n1, n2, l1, l2));
        //Taking the element from second array
         if(index2 < n2.Length)
            {
                l2.Add(n2[index2]);
                max = Math.Max(max,Helper(index1 + 1, index2 + 1, n1, n2, l1, l2));
                l2.RemoveAt(l2.Count - 1);
            }
        return max;
        
        
    }
    public int MaxDotProduct(int[] nums1, int[] nums2) {
        Helper(0,0, nums1, nums2, new List<int>(), new List<int>());
        return (int)product;
    }
}
