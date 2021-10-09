using System;
using System.Threading;

namespace GameRockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string yesNo = string.Empty;

            while (yesNo.ToLower() != "n")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Rock Paper Scissors{Environment.NewLine}");
                Console.ResetColor();

                Console.WriteLine("Hi, Player 1");

                Random random = new Random();

                string changingPlayerName = string.Empty;
                string changingOpponentName = string.Empty;
                string playerName = string.Empty;
                string opponentName = string.Empty;
                string keyboardInput = string.Empty;

                int win = 0, lose = 0, draw = 0, totalGamesPlayed = 0;

                while (changingPlayerName.ToLower() != "n")
                {
                    Console.Write("Do you want to change your name? ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" [y] ");
                    Console.ResetColor();

                    Console.Write("/");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" [n] ");
                    Console.ResetColor();

                    Console.Write(": ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    changingPlayerName = Console.ReadLine();
                    Console.ResetColor();

                    if (changingPlayerName.ToLower() == "y" || changingPlayerName.ToLower() == "yes")
                    {
                        do
                        {
                            Console.Write("Enter new name: ");

                            Console.ForegroundColor = ConsoleColor.Green;
                            playerName = Console.ReadLine();
                            Console.ResetColor();

                            if (playerName.Length == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("you can't leave name empty\n".PadLeft(43, ' '));
                                Console.ResetColor();
                            }
                        }
                        while (playerName.Length == 0);

                        break;
                    }

                    else if (changingPlayerName.ToLower() == "n" || changingPlayerName.ToLower() == "no")
                    {
                        playerName = "Player 1";
                        break;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("y - change name".PadLeft(61, ' '));
                        Console.Write("n - leave default name\n".PadLeft(69, ' '));
                        Console.ResetColor();
                    }
                }

                Console.WriteLine();

                while (changingOpponentName.ToLower() != "n")
                {
                    Console.Write("Do you want to change opponent's name? ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" [y] ");
                    Console.ResetColor();

                    Console.Write("/");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" [n] ");
                    Console.ResetColor();

                    Console.Write(": ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    changingOpponentName = Console.ReadLine();
                    Console.ResetColor();

                    if (changingOpponentName.ToLower() == "y" || changingOpponentName.ToLower() == "yes")
                    {
                        do
                        {
                            Console.Write("Enter new name: ");

                            Console.ForegroundColor = ConsoleColor.Green;
                            opponentName = Console.ReadLine();
                            Console.ResetColor();

                            if (opponentName.Length == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("you can't leave name empty\n".PadLeft(43, ' '));
                                Console.ResetColor();
                            }
                        }
                        while (opponentName.Length == 0);

                        break;
                    }

                    else if (changingOpponentName.ToLower() == "n" || changingOpponentName.ToLower() == "no")
                    {
                        opponentName = "Player 2";
                        break;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("y - change name".PadLeft(67, ' '));
                        Console.Write("n - leave default name\n".PadLeft(75, ' '));
                        Console.ResetColor();
                    }
                }

                Console.Clear();

                while (keyboardInput != "<")
                {
                    Console.Clear();

                    Console.WriteLine("[1] rock     [2] scissors     [3] paper\n");
                    Console.WriteLine("[<] to end the game".PadLeft(49, ' '));
                    Console.Write("\nmake your choice: ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    keyboardInput = Console.ReadLine();
                    Console.ResetColor();

                    int enemyChoice = random.Next(1, 4);

                    switch (keyboardInput)
                    {
                        case "1":
                            if (keyboardInput == "1" && enemyChoice == 1)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: rock" +
                                                   " VS " +
                                                  $"{opponentName}: rock\n");
                                draw++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            else if (keyboardInput == "1" && enemyChoice == 2)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: rock" +
                                                   " VS " +
                                                  $"{opponentName}: scissors\n");
                                win++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            else if (keyboardInput == "1" && enemyChoice == 3)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: rock" +
                                                   " VS " +
                                                  $"{opponentName}: paper\n");
                                lose++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            continue;

                        case "2":
                            if (keyboardInput == "2" && enemyChoice == 1)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: scissors" +
                                                   " VS " +
                                                  $"{opponentName}: rock\n");
                                lose++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            else if (keyboardInput == "2" && enemyChoice == 2)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: scissors" +
                                                   " VS " +
                                                  $"{opponentName}: scissors\n");
                                draw++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            else if (keyboardInput == "2" && enemyChoice == 3)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: scissors" +
                                                   " VS " +
                                                  $"{opponentName}: paper\n");
                                win++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            continue;

                        case "3":
                            if (keyboardInput == "3" && enemyChoice == 1)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: paper" +
                                                   " VS " +
                                                  $"{opponentName}: rock\n");
                                win++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            else if (keyboardInput == "3" && enemyChoice == 2)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: paper" +
                                                   " VS " +
                                                  $"{opponentName}: scissors\n");
                                lose++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            else if (keyboardInput == "3" && enemyChoice == 3)
                            {
                                Console.WriteLine($"{Environment.NewLine}{playerName}: paper" +
                                                   " VS " +
                                                  $"{opponentName}: paper\n");
                                draw++;
                                totalGamesPlayed++;

                                GetStatistics(playerName, opponentName, win, lose, draw);
                                break;
                            }

                            continue;

                        case "<":
                            Console.Clear();

                            Console.WriteLine("Final statistics");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{playerName}: {win}");

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{opponentName}: {lose}");

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"Draw: {draw}");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"Total games played: {totalGamesPlayed}");
                            Console.ResetColor();

                            if (win > lose) Console.WriteLine($"{Environment.NewLine}You won, congradulations!\n");

                            else if (win < lose) Console.WriteLine($"{Environment.NewLine}{opponentName} won.\nMaybe next time luck will be on your side\n");

                            else Console.WriteLine($"{Environment.NewLine}Friendly draw\n");

                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("incorrect input".PadLeft(33, ' '));
                            Console.ResetColor();

                            Thread.Sleep(1000);
                            break;
                    }

                    if (keyboardInput == "<") break;
                }

                do
                {
                    Console.Write("Do you want to play again?");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" [y] ");
                    Console.ResetColor();

                    Console.Write("/");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" [n] ");
                    Console.ResetColor();

                    Console.Write(": ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    yesNo = Console.ReadLine();
                    Console.ResetColor();

                    if (yesNo.ToLower() == "y")
                    {
                        Console.Clear();
                        break; 
                    }

                    if (yesNo.ToLower() == "n")
                    {
                        Console.Clear();
                        break;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("y - play again".PadLeft(53, ' '));
                        Console.Write("n - exit\n".PadLeft(48, ' '));
                        Console.ResetColor();
                        continue;
                    }
                }
                while (yesNo.ToLower() != "y" || yesNo.ToLower() != "n");
            }
        }
        internal static void GetStatistics(string playerName, string opponentName, int win, int lose, int draw)
        {
            Console.WriteLine("Statistics");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{playerName}: {win}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{opponentName}: {lose}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Draw: {draw}");
            Console.ResetColor();

            Thread.Sleep(2000);
        }
    }
}
