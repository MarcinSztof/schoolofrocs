using System;

namespace MinSumPathProblem
{
    public class MinPathSumNestesLoops
    {
        public int MinPathSum(int[][] board)
        {
            var board2d = Utils.To2D(board);
            var sums = new int[board2d.GetLength(0), board2d.GetLength(1)];
            AssignsMinSumPathToCells(board2d, sums);
            return sums[board2d.GetLength(0) - 1, board2d.GetLength(1) - 1];
        }


        private void AssignsMinSumPathToCells(int[,] board, int[,] sums)
        {
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (y == 0 && x == 0)
                    {
                        sums[y, x] = board[y, x];
                        continue;
                    }

                    if (y == 0)
                    {
                        sums[y, x] = board[y, x] + sums[y, x - 1];
                        continue;
                    }

                    if (x == 0)
                    {
                        sums[y, x] = board[y, x] + sums[y - 1, x];
                        continue;
                    }

                    sums[y, x] = Math.Min(board[y, x] + sums[y - 1, x], board[y, x] + sums[y, x - 1]);
                }
            }
        }
    }
}
