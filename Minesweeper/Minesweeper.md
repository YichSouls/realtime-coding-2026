Minesweeper

Problem Description

You are given a two-dimensional Minesweeper board and the position of a cell that the player clicks.

Each cell on the board contains one of the following characters:

* 'M': an unrevealed mine.
* 'E': an unrevealed empty cell.
* 'B': a revealed blank cell with no adjacent mines.
* '1' to '8': a revealed cell showing the number of adjacent mines.
* 'X': a revealed mine.

A cell can have up to eight adjacent cells: horizontally, vertically, and diagonally.

Update the board according to the following rules:

1. If the player clicks on a mine ('M'), change it to 'X'. The game ends.
2. If the player clicks on an empty cell ('E') that has one or more adjacent mines:
    * Reveal the cell.
    * Replace it with the number of adjacent mines, represented as a character from '1' to '8'.
3. If the player clicks on an empty cell ('E') that has no adjacent mines:
    * Change it to 'B'.
    * Recursively reveal all adjacent unrevealed empty cells.
4. Already revealed cells must not be changed or processed again.

Return the updated board.

⸻

Function Signature

updateBoard(board, click)

Parameters

* board: a two-dimensional array of characters representing the current Minesweeper board.
* click: an array containing two integers:
    * click[0] is the clicked row.
    * click[1] is the clicked column.

Return Value

Return the board after processing the click.

The board may also be updated in place.

⸻

Constraints

1 <= number of rows <= 50
1 <= number of columns <= 50
board[row][column] is one of:
'M', 'E', 'B', '1', '2', '3', '4', '5', '6', '7', or '8'
0 <= click[0] < number of rows
0 <= click[1] < number of columns

You may assume that the clicked cell is either 'M' or 'E'.

⸻

Example 1

Input

board = [
  ['E', 'E', 'E', 'E', 'E'],
  ['E', 'E', 'M', 'E', 'E'],
  ['E', 'E', 'E', 'E', 'E'],
  ['E', 'E', 'E', 'E', 'E']
]
click = [3, 0]

Output

[
  ['B', '1', 'E', '1', 'B'],
  ['B', '1', 'M', '1', 'B'],
  ['B', '1', '1', '1', 'B'],
  ['B', 'B', 'B', 'B', 'B']
]

Explanation

The player clicks the cell at row 3, column 0.

This cell is empty and has no adjacent mines, so it becomes 'B'.

Its adjacent empty cells are then revealed recursively.

Cells with no adjacent mines become 'B'.

Cells next to the mine become '1'.

The mine remains unrevealed because the recursive exploration stops when it reaches a cell with one or more adjacent mines.

⸻

Example 2

Input

board = [
  ['B', '1', 'E', '1', 'B'],
  ['B', '1', 'M', '1', 'B'],
  ['B', '1', '1', '1', 'B'],
  ['B', 'B', 'B', 'B', 'B']
]
click = [1, 2]

Output

[
  ['B', '1', 'E', '1', 'B'],
  ['B', '1', 'X', '1', 'B'],
  ['B', '1', '1', '1', 'B'],
  ['B', 'B', 'B', 'B', 'B']
]

Explanation

The player clicks directly on a mine.

The mine is changed from 'M' to 'X', and no other cells are modified.

⸻

Example 3

Input

board = [
  ['E', 'M'],
  ['E', 'E']
]
click = [1, 1]

Output

[
  ['E', 'M'],
  ['E', '1']
]

Explanation

The clicked cell has one adjacent mine.

It is therefore changed from 'E' to '1'.

The recursive reveal does not continue because the cell has at least one neighboring mine.

⸻

Test Cases

Test Case 1: Single Mine

Input

board = [
  ['M']
]
click = [0, 0]

Expected Output

[
  ['X']
]

⸻

Test Case 2: Single Empty Cell

Input

board = [
  ['E']
]
click = [0, 0]

Expected Output

[
  ['B']
]

The cell has no adjacent mines, so it becomes a revealed blank cell.

⸻

Test Case 3: Empty Board Without Mines

Input

board = [
  ['E', 'E'],
  ['E', 'E']
]
click = [0, 0]

Expected Output

[
  ['B', 'B'],
  ['B', 'B']
]

All cells are connected empty cells with no adjacent mines, so the entire board is revealed.

⸻

Test Case 4: Clicked Cell Next to One Mine

Input

board = [
  ['M', 'E'],
  ['E', 'E']
]
click = [1, 1]

Expected Output

[
  ['M', 'E'],
  ['E', '1']
]

The clicked cell is diagonally adjacent to one mine.

⸻

Test Case 5: Clicked Cell Next to Multiple Mines

Input

board = [
  ['M', 'E', 'M'],
  ['E', 'E', 'E'],
  ['E', 'M', 'E']
]
click = [1, 1]

Expected Output

[
  ['M', 'E', 'M'],
  ['E', '3', 'E'],
  ['E', 'M', 'E']
]

The center cell has three adjacent mines, so it becomes '3'.

⸻

Test Case 6: Reveal Stops at Numbered Cells

Input

board = [
  ['E', 'E', 'E', 'E'],
  ['E', 'E', 'E', 'E'],
  ['E', 'E', 'M', 'E'],
  ['E', 'E', 'E', 'E']
]
click = [0, 0]

Expected Output

[
  ['B', 'B', 'B', 'B'],
  ['B', '1', '1', '1'],
  ['B', '1', 'M', 'E'],
  ['B', '1', 'E', 'E']
]

The empty area is revealed recursively.

Cells adjacent to the mine display '1', but the recursive exploration does not continue through those numbered cells.

Therefore, some cells on the other side of the mine remain unrevealed.

⸻

Test Case 7: Mine in a Corner

Input

board = [
  ['M', 'E', 'E'],
  ['E', 'E', 'E'],
  ['E', 'E', 'E']
]
click = [2, 2]

Expected Output

[
  ['M', '1', 'B'],
  ['1', '1', 'B'],
  ['B', 'B', 'B']
]

⸻

Test Case 8: Rectangular Board

Input

board = [
  ['E', 'E', 'E', 'E', 'E'],
  ['E', 'M', 'E', 'M', 'E']
]
click = [0, 2]

Expected Output

[
  ['E', 'E', '2', 'E', 'E'],
  ['E', 'M', 'E', 'M', 'E']
]

The clicked cell is adjacent to two mines, so it becomes '2'.

No recursive reveal occurs.

⸻

Follow-up Questions

1. Would you solve this problem using depth-first search or breadth-first search?
2. How do you ensure that the same cell is not processed multiple times?
3. What is the time complexity of your solution?
4. What is the space complexity of a recursive DFS solution?
5. Could a recursive DFS cause a stack overflow on a large board?
6. How would you rewrite the solution using an explicit queue?
7. How would the problem change if a cell had only four neighbors instead of eight?
8. How would you implement the flagging behavior of a complete Minesweeper game?