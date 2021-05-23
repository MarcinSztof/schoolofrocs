using System;
using System.Linq;

namespace MinSumPathProblem
{
    public class MinPathSumRecursive
    {
        public int MinPathSum(int[][] board)
        {
            var board2d = Utils.To2D(board);
            //same size 2d array of int? initialized with nulls
            var memoBoard = Utils.To2D(
                Enumerable.Repeat(0, board2d.GetLength(0)).Select(x => Enumerable.Repeat(0, board2d.GetLength(1)).Select(x => (int?)null).ToArray()).ToArray());
            return GetMinSumPathTo(board2d.GetLength(1) - 1, board2d.GetLength(0) - 1, board2d, memoBoard);
        }

        private int GetMinSumPathTo(int x, int y, int[,] board, int?[,] sumsMemo)
        {
            if (sumsMemo[y, x] != null)
                return sumsMemo[y, x].Value;

            var curCellValue = board[y, x];
            var minSum = (y, x) switch
            {
                (0, 0) => curCellValue,
                (0, _) => GetMinSumPathTo(x - 1, y, board, sumsMemo) + curCellValue,
                (_, 0) => GetMinSumPathTo(x, y - 1, board, sumsMemo) + curCellValue,
                _ => Math.Min(GetMinSumPathTo(x - 1, y, board, sumsMemo), GetMinSumPathTo(x, y - 1, board, sumsMemo)) + curCellValue
            };

            sumsMemo[y, x] = minSum;

            return minSum;
        }
    }
}
