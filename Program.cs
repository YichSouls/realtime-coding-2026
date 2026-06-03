int?[,] gameBoard = null!;

void CreateGameBoard(int boardDimension = 3)
{
    gameBoard = new int?[boardDimension, boardDimension];
}

bool TrackPlayerMove(bool isX, int row, int col)
{
    int playerNumber = isX ? 1 : 0;
    gameBoard[row, col] = playerNumber;
    return IsPlayerWin(playerNumber);
}

bool IsPlayerWin(int playerNumber)
{
    int n = gameBoard.GetLength(0);

    // 检查每一行
    for (int row = 0; row < n; row++)
    {
        bool win = true;
        for (int col = 0; col < n; col++)
            if (gameBoard[row, col] != playerNumber) { win = false; break; }
        if (win) return true;
    }

    // 检查每一列
    for (int col = 0; col < n; col++)
    {
        bool win = true;
        for (int row = 0; row < n; row++)
            if (gameBoard[row, col] != playerNumber) { win = false; break; }
        if (win) return true;
    }

    // 检查主对角线（左上→右下）
    bool mainDiag = true;
    for (int i = 0; i < n; i++)
        if (gameBoard[i, i] != playerNumber) { mainDiag = false; break; }
    if (mainDiag) return true;

    // 检查副对角线（右上→左下）
    bool antiDiag = true;
    for (int i = 0; i < n; i++)
        if (gameBoard[i, n - 1 - i] != playerNumber) { antiDiag = false; break; }
    if (antiDiag) return true;

    return false;
}

// Example game
CreateGameBoard();
bool xsWon, osWon;

xsWon = TrackPlayerMove(true,  0, 0); Console.WriteLine($"xsWon: {xsWon}"); // false
osWon = TrackPlayerMove(false, 0, 1); Console.WriteLine($"osWon: {osWon}"); // false
xsWon = TrackPlayerMove(true,  1, 0); Console.WriteLine($"xsWon: {xsWon}"); // false
osWon = TrackPlayerMove(false, 1, 1); Console.WriteLine($"osWon: {osWon}"); // false
xsWon = TrackPlayerMove(true,  2, 0); Console.WriteLine($"xsWon: {xsWon}"); // true