𝗗𝗮𝘆 52 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 1356. Sort Integers by The Number of 1 Bits
You are given an integer array arr. Sort the integers in the array in ascending order by the number of 1's in their binary representation and in case of two or more integers have the same number of 1's you have to sort them in ascending order.
Return the array after sorting it.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits

𝗛𝗶𝗻𝘁:- 1. write a function to find no of 1 bits in a number
2. Pass it to the comparator in a sort method.


Code:-
public class Solution {
    public int NoOfBits(int n)
    {
        int count = 0;
        while(n!=0)
        {
            count += n & 1;
            n = n >> 1;
        }
        return count;
    }

    public int[] SortByBits(int[] arr) {
        Array.Sort(arr, (a, b) =>
        {
            int bitsA = NoOfBits(a);
            int bitsB = NoOfBits(b);

            if (bitsA != bitsB)
                return bitsA.CompareTo(bitsB);

            return a.CompareTo(b); 
        });
        return arr;        
    }
}

