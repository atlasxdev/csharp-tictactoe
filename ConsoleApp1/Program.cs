class TicTacToe
{
    private static void Main(string[] args)
    {
        string[][] GameBoard = [[" ", " | ", " ", " | ", " "], // 0
                                ["-", " + ", "-", " + ", "-"], // 1
                                [" ", " | ", " ", " | ", " "], // 2
                                ["-", " + ", "-", " + ", "-"], // 3
                                [" ", " | ", " ", " | ", " "]]; // 4

        bool isGameFinished = false;
        bool isPlayerOneTurn = true;
        int numberOfTurns = 8;

        Console.WriteLine("Hello world!");

        PrintGameBoard(GameBoard);

        while (!isGameFinished)
        {
            Console.WriteLine($"Your move player {(isPlayerOneTurn ? "X" : "O")}");
            Console.WriteLine("Enter a position from 1-9:");
            string playerPos = Console.ReadLine();

            if (numberOfTurns == 0)
            {
                ResetGameBoard(GameBoard);
            }

            if (int.TryParse(playerPos, out int position) && position >= 1 && position <= 9)
            {
                bool result = PlaceMarker(GameBoard, position, isPlayerOneTurn);
                Console.Clear();
                if (!result)
                {
                    Console.WriteLine("Position is already taken. Try again!");
                    PrintGameBoard(GameBoard);
                }
                else
                {
                    bool isGameHasResult = CheckWinningPositions(GameBoard, isPlayerOneTurn ? "X" : "O");
                    PrintGameBoard(GameBoard);
                    if (isGameHasResult == true) break;
                    isPlayerOneTurn = !isPlayerOneTurn;
                    numberOfTurns--;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid position from 1-9. Try again!");
            }
        }

        bool CheckWinningPositions(string[][] gameBoard, string marker)
        {
            // row winning conditions met 
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i][0] == marker && gameBoard[i][2] == marker && gameBoard[i][4] == marker)
                {
                    Console.WriteLine($"Player {marker} WINS!");
                    isGameFinished = true;
                    return true;
                }
            }

            // column winning conditions met
            for (int i = 0; i < gameBoard.Length; i++)
            {
                for(int j = 0; j < gameBoard[i].Length; j++)
                {
                    if (gameBoard[0][j] == marker && gameBoard[2][j] == marker && gameBoard[4][j] == marker)
                    {
                        Console.WriteLine($"Player {marker} WINS!");
                        return true;
                    }
                }
            }

            // diagonal winning conditions met
            if (gameBoard[0][0] == marker && gameBoard[2][2] == marker && gameBoard[4][4] == marker
                || gameBoard[0][4] == marker && gameBoard[2][2] == marker && gameBoard[4][0] == marker)
            {
                Console.WriteLine($"Player {marker} WINS!");
                return true;
            }

            return false;
        }

        bool PlaceMarker(string[][] gameBoard, int position, bool playerTurn)
        {
            int row = (position - 1) / 3 * 2;
            int col = (position - 1) % 3 * 2;

            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[row][col] == " ")
                {
                    gameBoard[row][col] = playerTurn ? "X" : "O";
                    return true;
                }
            }
            return false;
        }

        void PrintGameBoard(string[][] gameBoard)
        {
            foreach (string[] row in gameBoard)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        void ResetGameBoard(string[][] gameBoard)
        {

            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0) gameBoard[i][j] = " ";
                    else if (i % 2 == 1 && j % 2 == 1) gameBoard[i][j] = " + ";
                    else if (i % 2 == 1) gameBoard[i][j] = "-";
                    else gameBoard[i][j] = " | ";
                }
            }
            Console.WriteLine("The game board has been reset. Let’s try again!");
            isPlayerOneTurn = true;
            numberOfTurns = 8;
        }
    }
}