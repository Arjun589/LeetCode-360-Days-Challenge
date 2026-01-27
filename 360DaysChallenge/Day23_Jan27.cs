𝗗𝗮𝘆 23 𝗼𝗳 𝟯𝟲𝟬 days of LeetCode Challenge.
  
𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗦𝘁𝗮𝘁𝗲𝗺𝗲𝗻𝘁 :-3650. Minimum Cost Path with Edge Reversals
You are given a directed, weighted graph with n nodes labeled from 0 to n - 1, and an array edges where edges[i] = [ui, vi, wi] represents a directed edge from node ui to node vi with cost wi.
Each node ui has a switch that can be used at most once: when you arrive at ui and have not yet used its switch, you may activate it on one of its incoming edges vi → ui reverse that edge to ui → vi and immediately traverse it.
The reversal is only valid for that single move, and using a reversed edge costs 2 * wi.
Return the minimum total cost to travel from node 0 to node n - 1. If it is not possible, return -1.

𝗣𝗿𝗼𝗯𝗹𝗲𝗺 𝗹𝗶𝗻𝗸:- https://leetcode.com/problems/minimum-cost-path-with-edge-reversals

𝗛𝗶𝗻𝘁:- Priority queue with visited checks and traversing through bfs

Approach:- 

This code implements Dijkstra’s Algorithm to find the cheapest path from node 0 to the final node in a weighted graph.

1. Graph Construction: It builds an adjacency list where original edges have weight W, but reverse directions are added with weight 2W.
2. Initialization: A MinDistances array tracks the lowest cost to reach each node (starting at 0, others at infinity) alongside a VisitedNodes tracker.
3. Priority Queue: It uses a PriorityQueue to always process the node with the lowest current cumulative distance first.
4. Optimal Pathing: For each node, it explores neighbors and updates their minimum distance if a shorter path is found.
5. Target Exit: If the algorithm dequeues the final node (TotalNodes - 1), it immediately returns that distance as the optimal cost.
6. Termination: If the queue empties without reaching the target, it returns -1, indicating the end node is unreachable.

Code:- 

public class Solution
{
    public int MinCost(int TotalNodes, int[][] Connections)
    {
        var Graph = new List<(int NodeIndex, int Weight)>[TotalNodes];
        for (int Index = 0; Index < TotalNodes; Index++)
        {
            Graph[Index] = new List<(int, int)>();
        }

        foreach (var Connection in Connections)
        {
            int NodeA = Connection[0];
            int NodeB = Connection[1];
            int Weight = Connection[2];

            Graph[NodeA].Add((NodeB, Weight));
            Graph[NodeB].Add((NodeA, 2 * Weight));
        }

        int[] MinDistances = new int[TotalNodes];
        bool[] VisitedNodes = new bool[TotalNodes];
        Array.Fill(MinDistances, int.MaxValue);
        MinDistances[0] = 0;

        var PriorityQueue = new PriorityQueue<(int Distance, int NodeIndex), int>();
        PriorityQueue.Enqueue((0, 0), 0);

        while (PriorityQueue.Count > 0)
        {
            var CurrentState = PriorityQueue.Dequeue();
            int CurrentDistance = CurrentState.Distance;
            int CurrentNode = CurrentState.NodeIndex;

            if (CurrentNode == TotalNodes - 1)
            {
                return CurrentDistance;
            }

            if (VisitedNodes[CurrentNode])
            {
                continue;
            }

            VisitedNodes[CurrentNode] = true;

            foreach (var Neighbor in Graph[CurrentNode])
            {
                int NeighborNode = Neighbor.NodeIndex;
                int EdgeWeight = Neighbor.Weight;

                if (CurrentDistance + EdgeWeight < MinDistances[NeighborNode])
                {
                    MinDistances[NeighborNode] = CurrentDistance + EdgeWeight;
                    PriorityQueue.Enqueue((MinDistances[NeighborNode], NeighborNode), MinDistances[NeighborNode]);
                }
            }
        }

        return -1;
    }
}
