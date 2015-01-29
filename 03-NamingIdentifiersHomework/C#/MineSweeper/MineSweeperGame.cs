using System;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeperGame
    {
        public class PlayerScore
        {
            private string playerName;
            private int points;

            public PlayerScore()
            {
            }

            public PlayerScore(string playerName, int points)
            {
                this.PlayerName = playerName;
                this.Points = points;
            }

            public string PlayerName
            {
                get
                {
                    return this.playerName;
                }

                set
                {
                    this.playerName = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }
        }

        public static void Main(string[] args)
        {
            string command;
            char[,] gameField = CreateGameField();
            char[,] minesField = PlaceMines();
            int pointsCounter = 0;
            bool gameIsOver = true;
            List<PlayerScore> topPlayerScores = new List<PlayerScore>(6);
            int gameFieldRow = 0;
            int gameFieldCol = 0;
            const int maxPoints = 35;
            bool hasMaxPoints = false;

            do
            {
                if (gameIsOver)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawGameField(gameField);
                    gameIsOver = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out gameFieldRow) && 
                        int.TryParse(command[2].ToString(), out gameFieldCol) && 
                        gameFieldRow <= gameField.GetLength(0) && 
                        gameFieldCol <= gameField.GetLength(1)) 
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintTopPlayers(topPlayerScores);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        minesField = PlaceMines();
                        DrawGameField(gameField);
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (minesField[gameFieldRow, gameFieldCol] != '*')
                        {
                            if (minesField[gameFieldRow, gameFieldCol] == '-')
                            {
                                RevealPosition(gameField, minesField, gameFieldRow, gameFieldCol);
                                pointsCounter++;
                            }

                            if (maxPoints == pointsCounter)
                            {
                                hasMaxPoints = true;
                            }
                            else
                            {
                                DrawGameField(gameField);
                            }
                        }
                        else
                        {
                            gameIsOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (gameIsOver)
                {
                    DrawGameField(minesField);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", pointsCounter);
                    string nickName = Console.ReadLine();
                    PlayerScore currentPlayerScore = new PlayerScore(nickName, pointsCounter);
                    if (topPlayerScores.Count < 5)
                    {
                        topPlayerScores.Add(currentPlayerScore);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayerScores.Count; i++)
                        {
                            if (topPlayerScores[i].Points < currentPlayerScore.Points)
                            {
                                topPlayerScores.Insert(i, currentPlayerScore);
                                topPlayerScores.RemoveAt(topPlayerScores.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayerScores.Sort((p1, p2) => p2.PlayerName.CompareTo(p1.PlayerName));
                    topPlayerScores.Sort((p1, p2) => p2.Points.CompareTo(p1.Points));
                    PrintTopPlayers(topPlayerScores);

                    gameField = CreateGameField();
                    minesField = PlaceMines();
                    pointsCounter = 0;
                    gameIsOver = false;
                }

                if (hasMaxPoints)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawGameField(minesField);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    PlayerScore points = new PlayerScore(name, pointsCounter);
                    topPlayerScores.Add(points);
                    PrintTopPlayers(topPlayerScores);
                    gameField = CreateGameField();
                    minesField = PlaceMines();
                    pointsCounter = 0;
                    hasMaxPoints = false;
                    gameIsOver = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintTopPlayers(List<PlayerScore> players)
        {
            Console.WriteLine("\nTo4KI:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, players[i].PlayerName, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void RevealPosition(char[,] gameField, char[,] minesField, int row, int col)
        {
            char neighbourMinesCount = CountNeighbourMines(minesField, row, col);
            minesField[row, col] = neighbourMinesCount;
            gameField[row, col] = neighbourMinesCount;
        }

        private static void DrawGameField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int gameFieldRows = 5;
            int gameFieldCols = 10;
            char[,] gameField = new char[gameFieldRows, gameFieldCols];
            for (int i = 0; i < gameFieldRows; i++)
            {
                for (int j = 0; j < gameFieldCols; j++)
                {
                    gameField[i, j] = '?';
                }
            }

            return gameField;
        }

        private static char[,] PlaceMines()
        {
            int minesFieldRows = 5;
            int minesFieldCols = 10;
            char[,] minesField = new char[minesFieldRows, minesFieldCols];

            for (int i = 0; i < minesFieldRows; i++)
            {
                for (int j = 0; j < minesFieldCols; j++)
                {
                    minesField[i, j] = '-';
                }
            }

            List<int> minesPositions = new List<int>();
            while (minesPositions.Count < 15)
            {
                Random random = new Random();
                int nextMinePosition = random.Next(50);
                if (!minesPositions.Contains(nextMinePosition))
                {
                    minesPositions.Add(nextMinePosition);
                }
            }

            foreach (int minePosition in minesPositions)
            {
                int col = minePosition / minesFieldCols;
                int row = minePosition % minesFieldCols;
                if (row == 0 && minePosition != 0)
                {
                    col--;
                    row = minesFieldCols;
                }
                else
                {
                    row++;
                }

                minesField[col, row - 1] = '*';
            }

            return minesField;
        }

        private static char CountNeighbourMines(char[,] minesField, int inputRow, int inputCol)
        {
            int neighbourMinesCount = 0;
            int minesFieldRow = minesField.GetLength(0);
            int minesFieldCol = minesField.GetLength(1);

            if (inputRow - 1 >= 0)
            {
                if (minesField[inputRow - 1, inputCol] == '*')
                {
                    neighbourMinesCount++;
                }
            }

            if (inputRow + 1 < minesFieldRow)
            {
                if (minesField[inputRow + 1, inputCol] == '*')
                {
                    neighbourMinesCount++;
                }
            }

            if (inputCol - 1 >= 0)
            {
                if (minesField[inputRow, inputCol - 1] == '*')
                {
                    neighbourMinesCount++;
                }
            }

            if (inputCol + 1 < minesFieldCol)
            {
                if (minesField[inputRow, inputCol + 1] == '*')
                {
                    neighbourMinesCount++;
                }
            }

            if ((inputRow - 1 >= 0) && (inputCol - 1 >= 0))
            {
                if (minesField[inputRow - 1, inputCol - 1] == '*')
                {
                    neighbourMinesCount++;
                }
            }

            if ((inputRow - 1 >= 0) && (inputCol + 1 < minesFieldCol))
            {
                if (minesField[inputRow - 1, inputCol + 1] == '*')
                {
                    neighbourMinesCount++;
                }
            }

            if ((inputRow + 1 < minesFieldRow) && (inputCol - 1 >= 0))
            {
                if (minesField[inputRow + 1, inputCol - 1] == '*')
                {
                    neighbourMinesCount++;
                }
            }

            if ((inputRow + 1 < minesFieldRow) && (inputCol + 1 < minesFieldCol))
            {
                if (minesField[inputRow + 1, inputCol + 1] == '*')
                {
                    neighbourMinesCount++;
                }
            }

            return char.Parse(neighbourMinesCount.ToString());
        }
    }
}