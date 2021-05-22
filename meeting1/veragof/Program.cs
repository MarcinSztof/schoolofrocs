using System;

public class Solution
{
    static void Main(string[] args)
    {
        var test1 = new int[][] 
        {
            new int[]{4,7,8,6,4},
            new int[]{6,7,3,9,2},
            new int[]{3,8,1,2,3},
            new int[]{7,1,7,3,7},
            new int[]{2,9,8,9,3},
        };
        var test2 = new int[][]
        {
            new int[]{1,7,9,2},
            new int[]{8,6,3,2},
            new int[]{1,6,7,8},
            new int[]{2,9,8,2},
        };

        Console.WriteLine(MinPath(test1));
        Console.WriteLine(MinPath(test2));
        Console.ReadKey();
    }

    private static int MinPath(int[][] arr)
    {
        var x = arr[0].Length;
        var y = arr.Length;

        var sums = new int[x,y];
        sums[0,0] = arr[0][0];

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if(i == 0 && j == 0)
                {
                    continue;
                }
                var up = (i -1) < 0 ? int.MaxValue : sums[i-1, j];
                var left = (j - 1) < 0 ? int.MaxValue : sums[i, j-1];

                sums[i, j] = arr[i][j] + Min(left, up);
            }
        }

        return sums[x - 1, y - 1];
    }

    private static int Min(int a, int b) => a > b ? b : a;
}
