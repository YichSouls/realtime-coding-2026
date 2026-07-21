// // TicTacToe game implementation

// TicTacToe game = new TicTacToe();
// game.CreateGameBoard();

// bool xsWon, osWon;
// xsWon = game.TrackPlayerMove(true,  0, 0); Console.WriteLine($"xsWon: {xsWon}"); // false
// osWon = game.TrackPlayerMove(false, 0, 1); Console.WriteLine($"osWon: {osWon}"); // false
// xsWon = game.TrackPlayerMove(true,  1, 0); Console.WriteLine($"xsWon: {xsWon}"); // false
// osWon = game.TrackPlayerMove(false, 1, 1); Console.WriteLine($"osWon: {osWon}"); // false
// xsWon = game.TrackPlayerMove(true,  2, 0); Console.WriteLine($"xsWon: {xsWon}"); // true

// // StringAlignment implementation
// StringAlignment alignment = new StringAlignment();
// String str1 = "hi mister";
// String str2 = "hello mister";
// int minDistance = alignment.ComputeMinDistance(str1, str2);
// Console.WriteLine($"Minimum distance between '{str1}' and '{str2}' is: {minDistance}");

// string str3 = "abbbcddd";
// string str4 = "bbbddd";
// int minDistance2 = alignment.ComputeMinDistance(str3, str4);
// Console.WriteLine($"Minimum distance between '{str3}' and '{str4}' is: {minDistance2}");

// GameOfLife implementation
new GameOfLifeTests().RunAll();