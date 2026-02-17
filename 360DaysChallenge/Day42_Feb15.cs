𝗗𝗮𝘆 42 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 67. Add Binary
Given two binary strings a and b, return their sum as a binary string.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/add-binary

𝗛𝗶𝗻𝘁:- 1.Simulate manual binary addition from right to left, keeping a carry and adding corresponding digits from both strings.
2. Continue while either string has digits left or carry is non-zero, store each bit, then reverse the result at the end.

Code:-

public class Solution {
    public string AddBinary(string a, string b) {
        var sum = new List<int>();
        for (int i = a.Length - 1, j = b.Length - 1, carry = 0; i >= 0 || j >= 0 || carry > 0;)
        {
            var firstDigit = i >= 0 ? a[i--] - '0' : 0;
            var secondDigit = j >= 0 ? b[j--] - '0' : 0;
            var sumDigit = firstDigit + secondDigit + carry;
            carry = sumDigit / 2;
            sum.Add(sumDigit % 2);
        }
        sum.Reverse();
        return String.Concat(sum);
    }
}
