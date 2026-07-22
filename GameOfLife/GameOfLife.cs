class GameOfLife
{
    public int rows;
    public int cols;

    public int[][] CalculateNextGeneration(int[][] currentGeneration)
    {
        // shadow copy next G
        // for r in rows
        // for c in cols
        // count live neighbors
        // apply rules to determine next state

        rows = currentGeneration.Length;
        cols = currentGeneration[0].Length;

        int[][] nextGeneration = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            nextGeneration[i] = new int[cols];
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                int liveNeighbors = CountNeighbors(r, c, currentGeneration);
                nextGeneration[r][c] = currentGeneration[r][c];

                if (currentGeneration[r][c] == 1)
                {
                    // Underpopulation
                    if (liveNeighbors < 2)
                    {
                        nextGeneration[r][c] = 0;
                    }
                    // Survival
                    if (liveNeighbors == 2 || liveNeighbors == 3)
                    {
                        nextGeneration[r][c] = 1;
                    }
                    // Overpopulation
                    if (liveNeighbors > 3)
                    {
                        nextGeneration[r][c] = 0;
                    }
                }
                else
                {
                    // Reproduction
                    if (liveNeighbors == 3)
                    {
                        nextGeneration[r][c] = 1;
                    }
                }
            }
        }

        return nextGeneration;
    }

    public int CountNeighbors(int row, int col, int[][] currentGeneration)
    {
        int[] dx = [-1, -1, -1, 0, 1, 1, 1, 0];
        int[] dy = [-1, 0, 1, 1, 1, 0, -1, -1];

        int liveNeighbor = 0;
        for (int i = 0; i < 8; i++)
        {
            int neighborR = row + dx[i];
            int neighborC = col + dy[i];

            if (neighborR >= 0 && neighborR < rows && neighborC >= 0 && neighborC < cols)
            {
                liveNeighbor += currentGeneration[neighborR][neighborC];
            }
        }

        return liveNeighbor;
    }
}