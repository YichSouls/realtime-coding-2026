Conway’s Game of Life

Problem Description

You are given a two-dimensional grid representing the current state of Conway’s Game of Life.

Each cell in the grid can be in one of two states:

* 1 represents a live cell.
* 0 represents a dead cell.

Every cell interacts with its eight possible neighbors:

* horizontal neighbors,
* vertical neighbors,
* diagonal neighbors.

The next state of each cell is determined by the following rules:

1. Underpopulation
    A live cell with fewer than two live neighbors becomes dead.
2. Survival
    A live cell with two or three live neighbors remains alive.
3. Overpopulation
    A live cell with more than three live neighbors becomes dead.
4. Reproduction
    A dead cell with exactly three live neighbors becomes alive.

All cells must be updated simultaneously. This means that the next state of a cell must be calculated using the original state of the grid, not using cells that have already been updated.

Implement a function that updates the grid to its next state.

Function Signature

gameOfLife(board)

Parameters

* board: a two-dimensional array of integers.
* Each value is either 0 or 1.
* board[row][column] represents the state of one cell.

Return Value

Update board in place.

The function does not need to return a new grid.

Constraints

1 <= number of rows <= 100
1 <= number of columns <= 100
board[i][j] is either 0 or 1

Cells outside the grid are considered dead.

Additional Requirement

Your solution should update the board in place.

You may use a small number of additional variables, but you should not create another grid of the same size as the input board.

⸻

Example 1

Input

board = [
  [0, 1, 0],
  [0, 0, 1],
  [1, 1, 1],
  [0, 0, 0]
]

Output

[
  [0, 0, 0],
  [1, 0, 1],
  [0, 1, 1],
  [0, 1, 0]
]

Explanation

Consider the cell at row 1, column 0.

It is currently dead, but it has exactly three live neighbors:

board[0][1]
board[2][0]
board[2][1]

Therefore, it becomes alive in the next generation.

The cell at row 0, column 1 is alive but has only one live neighbor, so it dies because of underpopulation.

⸻

Example 2

Input

board = [
  [1, 1],
  [1, 0]
]

Output

[
  [1, 1],
  [1, 1]
]

Explanation

The dead cell at row 1, column 1 has exactly three live neighbors, so it becomes alive.

Each existing live cell has exactly two live neighbors, so all three live cells remain alive.

⸻

Test Cases

Test Case 1: Single Dead Cell

Input

board = [
  [0]
]

Expected Output

[
  [0]
]

⸻

Test Case 2: Single Live Cell

Input

board = [
  [1]
]

Expected Output

[
  [0]
]

A single live cell has no live neighbors, so it dies.

⸻

Test Case 3: Horizontal Blinker

Input

board = [
  [0, 0, 0],
  [1, 1, 1],
  [0, 0, 0]
]

Expected Output

[
  [0, 1, 0],
  [0, 1, 0],
  [0, 1, 0]
]

This pattern is called a blinker. It alternates between a horizontal line and a vertical line.

⸻

Test Case 4: Stable Block

Input

board = [
  [1, 1],
  [1, 1]
]

Expected Output

[
  [1, 1],
  [1, 1]
]

Every live cell has exactly three live neighbors, so the board remains unchanged.

⸻

Test Case 5: All Dead Cells

Input

board = [
  [0, 0, 0],
  [0, 0, 0],
  [0, 0, 0]
]

Expected Output

[
  [0, 0, 0],
  [0, 0, 0],
  [0, 0, 0]
]

⸻

Test Case 6: Overpopulation

Input

board = [
  [1, 1, 1],
  [1, 1, 1],
  [1, 1, 1]
]

Expected Output

[
  [1, 0, 1],
  [0, 0, 0],
  [1, 0, 1]
]

The center cell and the non-corner edge cells have too many live neighbors and die. Each corner cell has exactly three live neighbors and remains alive.

⸻

Test Case 7: Rectangular Board

Input

board = [
  [0, 1, 1, 0],
  [1, 1, 0, 0]
]

Expected Output

[
  [1, 1, 1, 0],
  [1, 1, 1, 0]
]

⸻

Follow-up Questions

1. What is the time complexity of your solution?
2. What is the space complexity?
3. How can you update the board in place while still preserving the original state of every cell?
4. How would your solution change if the board were infinite?
5. How would you efficiently simulate a large sparse board containing only a small number of live cells?