𝗗𝗮𝘆 48 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 762. Prime Number of Set Bits in Binary Representation
Given two integers left and right, return the count of numbers in the inclusive range [left, right] having a prime number of set bits in their binary representation.
Recall that the number of set bits an integer has is the number of 1's present when written in binary.
For example, 21 written in binary is 10101, which has 3 set bits.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation

𝗛𝗶𝗻𝘁:-1. Follow the steps, Find set bits for each number and check prime.

Code:-

public class Solution {
    public int CountPrimeSetBits(int left, int right) {
        int count = 0;
       HashSet<int> primes = new HashSet<int>
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31
        };

        for(int i = left; i <= right ; i++)
        {
            int setbits = 0;
            int temp = i;
            while(temp != 0)
            {
                if(temp % 2 == 1) setbits += 1;
                temp = temp >> 1;
            }
            if(primes.Contains(setbits)) count += 1;
        }

        return count;
        
    }
}
