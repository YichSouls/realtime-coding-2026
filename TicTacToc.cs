class TicTacToe
{
    private int?[,] gameBoard = null!;

    public void CreateGameBoard(int boardDimension = 3)
    {
        gameBoard = new int?[boardDimension, boardDimension];
    }

    public bool TrackPlayerMove(bool isX, int row, int col)
    {
        int playerNumber = isX ? 1 : 0;
        gameBoard[row, col] = playerNumber;
        return IsPlayerWin(playerNumber);
    }

    private bool IsPlayerWin(int playerNumber)
    {
        int n = gameBoard.GetLength(0);

        for (int row = 0; row < n; row++)
        {
            bool win = true;
            for (int col = 0; col < n; col++)
                if (gameBoard[row, col] != playerNumber) { win = false; break; }
            if (win) return true;
        }

        for (int col = 0; col < n; col++)
        {
            bool win = true;
            for (int row = 0; row < n; row++)
                if (gameBoard[row, col] != playerNumber) { win = false; break; }
            if (win) return true;
        }

        bool mainDiag = true;
        for (int i = 0; i < n; i++)
            if (gameBoard[i, i] != playerNumber) { mainDiag = false; break; }
        if (mainDiag) return true;

        bool antiDiag = true;
        for (int i = 0; i < n; i++)
            if (gameBoard[i, n - 1 - i] != playerNumber) { antiDiag = false; break; }
        if (antiDiag) return true;

        return false;
    }
}