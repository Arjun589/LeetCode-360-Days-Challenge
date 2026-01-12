Problem statement:- Given a rows x cols binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

Code and explanation by OG DSA Master:- Striver
Link:- https://www.youtube.com/watch?v=tOylVCugy9k

Code:- 

  public class Solution {
    public int LargestRectangleArea(int[] heights) {
        
        int max = int.MinValue;
        Stack<int> stack = new Stack<int>();
        
        for(int i = 0; i < heights.Length; i++)
        {
            if(stack.Count == 0 || heights[stack.Peek()] < heights[i] ) stack.Push(i);
            else
            {
                while(stack.Count != 0 && heights[stack.Peek()] >= heights[i])
                {
                    var item = stack.Pop();
                    var left = stack.Count == 0 ? -1 : stack.Peek();
                    int tempmax = heights[item] * (i - left - 1);
                    max = Math.Max(max, tempmax);
                }
                stack.Push(i);
            }
        }
        while(stack.Count != 0)
        {
            var item = stack.Pop();
            int right = heights.Length;
            int left = stack.Count == 0 ? -1 : stack.Peek();
            int tempmax = heights[item] * (right - left - 1);
            max = Math.Max(max, tempmax);
        }

        return max;
    }

    public int MaximalRectangle(char[][] matrix) {
        int[] heights = new int[matrix[0].Length];
        int max = 0;
        for(int i = 0; i < matrix.Length; i++)
        {
            for(int j = 0 ; j < matrix[0].Length; j++)
            {
                int num = (matrix[i][j]  == '0') ? 0 : 1;
                if(num == 0) heights[j] = 0;
                else heights[j] += num;
            }
            max = Math.Max(max, LargestRectangleArea(heights));
        }
        return max;
        
    }
}
