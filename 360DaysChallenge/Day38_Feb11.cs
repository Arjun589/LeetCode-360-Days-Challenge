𝗗𝗮𝘆 38 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :- 3721. Longest Balanced Subarray II
You are given an integer array nums.
A subarray is called balanced if the number of distinct even numbers in the subarray is equal to the number of distinct odd numbers.
Return the length of the longest balanced subarray.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/longest-balanced-subarray-ii
𝗛𝗶𝗻𝘁:- 1.Think in terms of a sliding left boundary and maintain a prefix “balance” of distinct odd vs distinct even values; when the left boundary moves past the first occurrence of a value, adjust the balance only until its next occurrence.
2. Use a segment tree with lazy propagation over prefix balances so you can range-update efficiently and query the rightmost index where the balance becomes zero (i.e., a balanced subarray).


Code:-

using System;
using System.Collections.Generic;

public class SegmentTreeNode
{
    public int MinimumValue;
    public int MaximumValue;
    public int LazyValue;

    public SegmentTreeNode()
    {
        MinimumValue = int.MaxValue;
        MaximumValue = int.MinValue;
        LazyValue = 0;
    }
}

public class SegmentTree
{
    public SegmentTreeNode[] TreeNodes;
    public int ItemCount;

    public SegmentTree(int[] initialValues)
    {
        ItemCount = initialValues.Length;
        TreeNodes = new SegmentTreeNode[4 * ItemCount];
        for (int Index = 0; Index < TreeNodes.Length; Index++)
            TreeNodes[Index] = new SegmentTreeNode();
        
        BuildTree(0, 0, ItemCount - 1, initialValues);
    }

    public void BuildTree(int NodeIndex, int RangeStart, int RangeEnd, int[] InitialValues)
    {
        if (RangeStart == RangeEnd)
        {
            TreeNodes[NodeIndex].MinimumValue = TreeNodes[NodeIndex].MaximumValue = InitialValues[RangeStart];
            return;
        }

        int MiddleIndex = (RangeStart + RangeEnd) / 2;
        BuildTree(2 * NodeIndex + 1, RangeStart, MiddleIndex, InitialValues);
        BuildTree(2 * NodeIndex + 2, MiddleIndex + 1, RangeEnd, InitialValues);

        TreeNodes[NodeIndex].MinimumValue = Math.Min(TreeNodes[2 * NodeIndex + 1].MinimumValue, TreeNodes[2 * NodeIndex + 2].MinimumValue);
        TreeNodes[NodeIndex].MaximumValue = Math.Max(TreeNodes[2 * NodeIndex + 1].MaximumValue, TreeNodes[2 * NodeIndex + 2].MaximumValue);
    }

    public void PushDown(int NodeIndex, int RangeStart, int RangeEnd)
    {
        if (TreeNodes[NodeIndex].LazyValue == 0) return;

        TreeNodes[NodeIndex].MinimumValue += TreeNodes[NodeIndex].LazyValue;
        TreeNodes[NodeIndex].MaximumValue += TreeNodes[NodeIndex].LazyValue;

        if (RangeStart != RangeEnd)
        {
            TreeNodes[2 * NodeIndex + 1].LazyValue += TreeNodes[NodeIndex].LazyValue;
            TreeNodes[2 * NodeIndex + 2].LazyValue += TreeNodes[NodeIndex].LazyValue;
        }

        TreeNodes[NodeIndex].LazyValue = 0;
    }

    public void UpdateRange(int UpdateStart, int UpdateEnd, int NodeIndex, int RangeStart, int RangeEnd, int AdjustmentValue)
    {
        PushDown(NodeIndex, RangeStart, RangeEnd);

        if (RangeStart > UpdateEnd || RangeEnd < UpdateStart || RangeStart > RangeEnd)
            return;

        if (RangeStart >= UpdateStart && RangeEnd <= UpdateEnd)
        {
            TreeNodes[NodeIndex].LazyValue += AdjustmentValue;
            PushDown(NodeIndex, RangeStart, RangeEnd);
            return;
        }

        int MiddleIndex = (RangeStart + RangeEnd) / 2;
        UpdateRange(UpdateStart, UpdateEnd, 2 * NodeIndex + 1, RangeStart, MiddleIndex, AdjustmentValue);
        UpdateRange(UpdateStart, UpdateEnd, 2 * NodeIndex + 2, MiddleIndex + 1, RangeEnd, AdjustmentValue);

        TreeNodes[NodeIndex].MinimumValue = Math.Min(TreeNodes[2 * NodeIndex + 1].MinimumValue, TreeNodes[2 * NodeIndex + 2].MinimumValue);
        TreeNodes[NodeIndex].MaximumValue = Math.Max(TreeNodes[2 * NodeIndex + 1].MaximumValue, TreeNodes[2 * NodeIndex + 2].MaximumValue);
    }

    public int FindRightMostZero(int NodeIndex, int RangeStart, int RangeEnd)
    {
        PushDown(NodeIndex, RangeStart, RangeEnd);
        int CurrentMinimum = TreeNodes[NodeIndex].MinimumValue;
        int CurrentMaximum = TreeNodes[NodeIndex].MaximumValue;

        if (CurrentMinimum > 0 || CurrentMaximum < 0)
            return -1;

        if (RangeStart == RangeEnd)
            return RangeStart;

        int MiddleIndex = (RangeStart + RangeEnd) / 2;
        int RightResult = FindRightMostZero(2 * NodeIndex + 2, MiddleIndex + 1, RangeEnd);
        if (RightResult != -1)
            return RightResult;

        return FindRightMostZero(2 * NodeIndex + 1, RangeStart, MiddleIndex);
    }
}

public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int ArrayLength = nums.Length;
        Dictionary<int, int> ValueToIndexMap = new Dictionary<int, int>();
        int[] NextOccurrenceIndices = new int[ArrayLength];
        
        for (int Index = 0; Index < ArrayLength; Index++)
            NextOccurrenceIndices[Index] = ArrayLength;

        for (int Index = ArrayLength - 1; Index >= 0; Index--)
        {
            if (ValueToIndexMap.ContainsKey(nums[Index]))
                NextOccurrenceIndices[Index] = ValueToIndexMap[nums[Index]];

            ValueToIndexMap[nums[Index]] = Index;
        }

        int[] BalancePrefixSums = new int[ArrayLength];
        HashSet<int> EncounteredValues = new HashSet<int>();

        for (int Index = 0; Index < ArrayLength; Index++)
        {
            if (Index > 0)
                BalancePrefixSums[Index] = BalancePrefixSums[Index - 1];

            if (EncounteredValues.Contains(nums[Index]))
                continue;

            if (nums[Index] % 2 == 0)
                BalancePrefixSums[Index]--;
            else
                BalancePrefixSums[Index]++;

            EncounteredValues.Add(nums[Index]);
        }

        SegmentTree BalanceTree = new SegmentTree(BalancePrefixSums);
        int MaxBalancedLength = BalanceTree.FindRightMostZero(0, 0, ArrayLength - 1) + 1;

        for (int Index = 1; Index < ArrayLength; Index++)
        {
            int UpdateEndRange = NextOccurrenceIndices[Index - 1] - 1;
            int AdjustmentValue = ((nums[Index - 1] % 2 == 0) ? 1 : -1);

            BalanceTree.UpdateRange(Index, UpdateEndRange, 0, 0, ArrayLength - 1, AdjustmentValue);
            int RightMostZeroIndex = BalanceTree.FindRightMostZero(0, 0, ArrayLength - 1);

            if (RightMostZeroIndex != -1)
                MaxBalancedLength = Math.Max(MaxBalancedLength, RightMostZeroIndex - Index + 1);
        }

        return MaxBalancedLength;
    }
}

