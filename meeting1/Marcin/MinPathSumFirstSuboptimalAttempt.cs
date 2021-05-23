namespace MinSumPathProblem
{
    public class MinPathSumFirstSuboptimalAttempt
    {
        public int MinPathSum(int[][] board)
        {
            var sumAcc = int.MaxValue;
            TryMoveAndSave(Utils.To2D(board), (0, 0), 0, ref sumAcc);
            return sumAcc;
        }

        public void TryMoveAndSave(int[,] board, (int X, int Y) coordinate, int currentSum, ref int lastMinSum)
        {
            var newSum = currentSum + board[coordinate.Y, coordinate.X];

            if (lastMinSum < newSum)
                return;

            // if reached the end, save new min sum and return
            if (coordinate.X == board.GetLength(1) - 1 && coordinate.Y == board.GetLength(0) - 1)
            {
                lastMinSum = newSum;
                return;
            }

            // try move right
            if (board.GetLength(1) > coordinate.X + 1)
                TryMoveAndSave(board, (coordinate.X + 1, coordinate.Y), newSum, ref lastMinSum);

            // try move left
            if (board.GetLength(0) > coordinate.Y + 1)
                TryMoveAndSave(board, (coordinate.X, coordinate.Y + 1), newSum, ref lastMinSum);
        }
    }
}
