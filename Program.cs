using System;
using System.IO;
using System.Threading;

namespace GameRockPaperScissors
{
    class Program
    {
        private static Random random = new Random();
        private static Player player1;
        private static Player player2;
        private static int draw;
        private static int matchesPlayed;
        static void Main(string[] args)
        {
            string input = string.Empty;

            Print($"Rock Paper Scissors\n\n", ConsoleColor.DarkYellow);
            Print("Enter your name or press ENTER: ");

            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ResetColor();

            if (input.Length > 0)
                player1 = new Player(input);
            else player1 = new Player("Player");

            input = string.Empty;
            while (input.ToLower() != "n")
            {
                //using .txt file with library of different names
                string[] names = File.ReadAllLines(@"D:\codeBase\c#\GameRockPaperScissors\libraryOfWords.txt");
                //string[] names = File.ReadAllLines(@"D:\GameRockPaperScissors\libraryOfWords.txt");
                //randomly choose name for opponent
                player2 = new Player(names[random.Next(0, names.Length - 1)].Trim());

                input = string.Empty;
                while (input != "<")
                {
                    Console.Clear();

                    Print("[1] rock     [2] scissors     [3] paper\n\n");
                    Print("[<] to end the game".PadLeft(49, ' ') + "\n");
                    Print("\nmake your choice: ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    Console.ResetColor();

                    int playerTurn = random.Next(1, 4);

                    switch (input)
                    {
                        case "1":
                            player1.NextTurn(playerChoice.rock);
                            PlayerTurn(playerTurn);
                            continue;

                        case "2":
                            player1.NextTurn(playerChoice.scissors);
                            PlayerTurn(playerTurn);
                            continue;

                        case "3":
                            player1.NextTurn(playerChoice.paper);
                            PlayerTurn(playerTurn);
                            continue;

                        case "<":
                            break;
                    }

                    if (input == "<")
                    {
                        Console.Clear();

                        Print("Final statistics\n");
                        Print($"{player1.Name}: {player1.Wins}\n", ConsoleColor.DarkGreen);
                        Print($"{player2.Name}: {player2.Wins}\n", ConsoleColor.DarkRed);
                        Print($"Draw: {draw}\n", ConsoleColor.Cyan);
                        Print($"Total games played: {matchesPlayed}\n", ConsoleColor.DarkYellow);

                        if
                            (player1.Wins > player2.Wins) Console.WriteLine($"\nYou won, congradulations!\n");
                        else if (player1.Wins < player2.Wins)
                            Print($"\n{player2.Name} won.\nMaybe next time luck will be on your side\n\n");
                        else if (player1.Wins.Equals(player2.Wins))
                            Print($"\nFriendly draw\n\n");
                        break;
                    }
                }

                input = string.Empty;
                while (input.ToLower() != "y" && input.ToLower() != "n")
                {
                    Print("Do you want to play again?");
                    Print(" [y] ", ConsoleColor.Green);
                    Print("/");
                    Print(" [n] ", ConsoleColor.Green);
                    Print(": ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    Console.ResetColor();
                }
            }
        }
        internal static void ShowStatistics()
        {
            Print("Statistics\n");
            Print($"{player1.Name}: {player1.Wins}\n", ConsoleColor.DarkGreen);
            Print($"{player2.Name}: {player2.Wins}\n", ConsoleColor.DarkRed);
            Print($"Draw: {draw}\n", ConsoleColor.Cyan);

            Thread.Sleep(2000);
        }

        public static void Print(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PlayerTurn(int playerTurn)
        {
            if (playerTurn == 1)
            {
                draw++;
                player2.NextTurn(playerChoice.rock);
            }

            else if (playerTurn == 2)
            {
                player1.PlayerWon();
                player2.NextTurn(playerChoice.scissors);
            }

            else if (playerTurn == 3)
            {
                player2.PlayerWon();
                player2.NextTurn(playerChoice.paper);
            }

            matchesPlayed++;
            Print($"\n{player1.Name}: {player1.Turn} VS {player2.Name}: {player2.Turn}\n\n");
            ShowStatistics();
        }
    }
}
