using System;
using System.IO;

namespace GameRockPaperScissors
{
    class Program
    {
        private static Random random = new Random();
        private static Player player1;
        private static Player player2;
        static void Main(string[] args)
        {
            string input = string.Empty;

            Print.Text($"Rock Scissors Paper\n\n", ConsoleColor.DarkYellow);
            Print.Text("Enter your name or press ENTER: ");

            Console.ForegroundColor = ConsoleColor.Green;
            string playerName = Console.ReadLine();
            Console.ResetColor();

            while (input.ToLower() != "n")
            {
                if (playerName.Length > 0)
                    player1 = new Player(playerName);
                else player1 = new Player("Player");

                //using .txt file with library of different names
                string[] names = File.ReadAllLines(@"D:\GameRockPaperScissors\libraryOfWords.txt");
                //randomly choose name for opponent
                player2 = new Player(names[random.Next(0, names.Length - 1)].Trim());

                input = string.Empty;
                while (input != "<")
                {
                    Console.Clear();

                    Print.RockScissorsPaper();
                    Print.Text("\n[1] rock    [2] scissors    [3] paper\n");
                    Print.Text("[<] to end the game".PadLeft(47, ' ') + "\n");
                    Print.Text("\nmake your choice: ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    Console.ResetColor();

                    //show final statistics and stop the game
                    if (input == "<")
                    {
                        Console.Clear();
                        Arbitrator.ShowStatistics(player1, player2, final: true);
                        Arbitrator.ResetStatistics();
                        break;
                    }

                    //continue playing
                    int.TryParse(input, out int choice);
                    if (choice > 0 && choice <= 3)
                    {
                        player1.PlayerChoice((Item)choice);
                        //generating opponent's answer
                        player2.PlayerChoice((Item)random.Next(1, 4));
                        Arbitrator.Judge(player1, player2);
                    }
                }

                input = string.Empty;
                while (input.ToLower() != "y" && input.ToLower() != "n")
                {
                    Print.Text("Do you want to play again?");
                    Print.Text(" [y] ", ConsoleColor.Green);
                    Print.Text("/");
                    Print.Text(" [n] ", ConsoleColor.Green);
                    Print.Text(": ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    Console.ResetColor();
                }
            }
        }
    }
}
