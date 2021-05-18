public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        var n = grid.Length;
        var m = grid[0].Length;

        var sumCache = new int?[n, m];
        sumCache[n - 1, m - 1] = grid[n - 1][m - 1];

        for (var j = m - 1; j >= 0; j--)
        {
            for (var i = n - 1; i >= 0; i--)
            {
                var currentSum = sumCache[i, j];

                if (i > 0)
                {
                    UpdateSum(grid, sumCache, currentSum.Value, i - 1, j);
                }

                if (j > 0)
                {
                    UpdateSum(grid, sumCache, currentSum.Value, i, j - 1);
                }
            }
        }

        return sumCache[0, 0].Value;
    }

    private void UpdateSum(int[][] grid, int?[,] sumCache, int currentSum, int i0, int j0)
    {
        var nextSum = sumCache[i0, j0];
        var newNextSum = grid[i0][j0] + currentSum;

        if (nextSum == null || newNextSum < nextSum)
        {
            sumCache[i0, j0] = newNextSum;
        }
    }
}
