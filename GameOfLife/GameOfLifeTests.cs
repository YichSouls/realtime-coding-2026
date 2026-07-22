class GameOfLifeTests
{
    private readonly GameOfLife _game = new GameOfLife();

    public void RunAll()
    {
        RunTest("Test 1: Single Dead Cell",
            input:    [[0]],
            expected: [[0]]);

        RunTest("Test 2: Single Live Cell",
            input:    [[1]],
            expected: [[0]]);

        RunTest("Test 3: Horizontal Blinker",
            input:    [[0,0,0],[1,1,1],[0,0,0]],
            expected: [[0,1,0],[0,1,0],[0,1,0]]);

        RunTest("Test 4: Stable Block",
            input:    [[1,1],[1,1]],
            expected: [[1,1],[1,1]]);

        RunTest("Test 5: All Dead Cells",
            input:    [[0,0,0],[0,0,0],[0,0,0]],
            expected: [[0,0,0],[0,0,0],[0,0,0]]);

        RunTest("Test 6: Overpopulation",
            input:    [[1,1,1],[1,1,1],[1,1,1]],
            expected: [[1,0,1],[0,0,0],[1,0,1]]);

        RunTest("Test 7: Rectangular Board",
            input:    [[0,1,1,0],[1,1,0,0]],
            expected: [[1,1,1,0],[1,1,1,0]]);

        // Example 1 from problem
        RunTest("Example 1",
            input:    [[0,1,0],[0,0,1],[1,1,1],[0,0,0]],
            expected: [[0,0,0],[1,0,1],[0,1,1],[0,1,0]]);

        // Example 2 from problem
        RunTest("Example 2",
            input:    [[1,1],[1,0]],
            expected: [[1,1],[1,1]]);
    }

    private void RunTest(string name, int[][] input, int[][] expected)
    {
        // Deep copy input since the method mutates in place
        int[][] board = input.Select(row => row.ToArray()).ToArray();

        int[][] result = _game.CalculateNextGeneration(board);

        bool pass = BoardsEqual(result, expected);
        Console.WriteLine($"[{(pass ? "PASS" : "FAIL")}] {name}");

        if (!pass)
        {
            Console.WriteLine("  Expected:");
            PrintBoard(expected);
            Console.WriteLine("  Got:");
            PrintBoard(result);
        }
    }

    private static bool BoardsEqual(int[][] a, int[][] b)
    {
        if (a.Length != b.Length) return false;
        for (int r = 0; r < a.Length; r++)
        {
            if (a[r].Length != b[r].Length) return false;
            for (int c = 0; c < a[r].Length; c++)
                if (a[r][c] != b[r][c]) return false;
        }
        return true;
    }

    private static void PrintBoard(int[][] board)
    {
        foreach (var row in board)
            Console.WriteLine("    [" + string.Join(", ", row) + "]");
    }
}