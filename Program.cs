using System;
using System.IO;
using System.Threading;

namespace GameRockPaperScissors
{
    class Program
    {
        private static Random random = new Random();
        private static string playerName = string.Empty;
        private static string opponentName = string.Empty;
        private static int[] statistics;
        static void Main(string[] args)
        {
            string input = string.Empty;

            Print($"Rock Paper Scissors\n\n", ConsoleColor.DarkYellow);
            Print("Enter your name or press ENTER: ");

            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ResetColor();

            if (input.Length > 0)
                playerName = input;
            else playerName = "Player";

            input = string.Empty;
            while (input.ToLower() != "n")
            {
                statistics = new int[4];
                //using .txt file with library of different names
                string[] names = File.ReadAllLines(@"D:\GameRockPaperScissors\libraryOfWords.txt");
                //randomly choose name for opponent
                opponentName = names[random.Next(0, names.Length - 1)].Trim();

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

                    int enemyChoice = random.Next(1, 4);

                    switch (input)
                    {
                        case "1":
                            if (input == "1" && enemyChoice == 1)
                            {
                                statistics[0]++;
                                statistics[3]++;

                                Print($"\n{playerName}: rock VS {opponentName}: rock\n\n");
                                ShowStatistics();
                                break;
                            }

                            else if (input == "1" && enemyChoice == 2)
                            {
                                statistics[1]++;
                                statistics[3]++;

                                Print($"\n{playerName}: rock VS {opponentName}: scissors\n\n");
                                ShowStatistics();
                                break;
                            }

                            else if (input == "1" && enemyChoice == 3)
                            {
                                statistics[2]++;
                                statistics[3]++;

                                Print($"\n{playerName}: rock VS {opponentName}: paper\n\n");
                                ShowStatistics();
                                break;
                            }

                            continue;

                        case "2":
                            if (input == "2" && enemyChoice == 1)
                            {
                                statistics[2]++;
                                statistics[3]++;

                                Print($"\n{playerName}: scissors VS {opponentName}: rock\n\n");
                                ShowStatistics();
                                break;
                            }

                            else if (input == "2" && enemyChoice == 2)
                            {
                                statistics[0]++;
                                statistics[3]++;

                                Print($"\n{playerName}: scissors VS {opponentName}: scissors\n\n");
                                ShowStatistics();
                                break;
                            }

                            else if (input == "2" && enemyChoice == 3)
                            {
                                statistics[1]++;
                                statistics[3]++;

                                Print($"\n{playerName}: scissors VS {opponentName}: paper\n\n");
                                ShowStatistics();
                                break;
                            }

                            continue;

                        case "3":
                            if (input == "3" && enemyChoice == 1)
                            {
                                statistics[1]++;
                                statistics[3]++;

                                Print($"\n{playerName}: paper VS {opponentName}: rock\n\n");
                                ShowStatistics();
                                break;
                            }

                            else if (input == "3" && enemyChoice == 2)
                            {
                                statistics[2]++;
                                statistics[3]++;

                                Print($"\n{playerName}: paper VS {opponentName}: scissors\n\n");
                                ShowStatistics();
                                break;
                            }

                            else if (input == "3" && enemyChoice == 3)
                            {
                                statistics[0]++;
                                statistics[3]++;

                                Print($"\n{playerName}: paper VS {opponentName}: paper\n\n");
                                ShowStatistics();
                                break;
                            }

                            continue;

                        case "<":
                            Console.Clear();

                            Print("Final statistics\n");
                            Print($"{playerName}: {statistics[1]}\n", ConsoleColor.DarkGreen);
                            Print($"{opponentName}: {statistics[2]}\n", ConsoleColor.DarkRed);
                            Print($"Draw: {statistics[0]}\n", ConsoleColor.Cyan);
                            Print($"Total games played: {statistics[3]}\n", ConsoleColor.DarkYellow);

                            if 
                                (statistics[1] > statistics[2]) Console.WriteLine($"\nYou won, congradulations!\n");
                            else if (statistics[1] < statistics[2]) 
                                Print($"\n{opponentName} won.\nMaybe next time luck will be on your side\n\n");
                            else 
                                Print($"\nFriendly draw\n\n");

                            break;
                    }

                    if (input == "<") break;
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
            Print($"{playerName}: {statistics[1]}\n", ConsoleColor.DarkGreen);
            Print($"{opponentName}: {statistics[2]}\n", ConsoleColor.DarkRed);
            Print($"Draw: {statistics[0]}\n", ConsoleColor.Cyan);

            Thread.Sleep(2000);
        }

        public static void Print(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
