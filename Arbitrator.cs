using System;
using System.Threading;

namespace GameRockPaperScissors
{
    public class Arbitrator
    {
        public static int Draw { get; private set; }
        public static int MatchesPlayed { get; private set; }

        public static void ShowStatistics(Player player1, Player player2, bool final = false)
        {
            if (!final)
            {
                Print.Text("Statistics\n");
                MainStats();
            }
            else
            {
                Print.Text("Final statistics\n");
                MainStats();
                Print.Text($"Total games played: {MatchesPlayed}\n", ConsoleColor.DarkYellow);

                if (player1.Wins > player2.Wins)
                    Print.Text($"\nYou won, congradulations!\n\n");
                else if (player1.Wins < player2.Wins)
                    Print.Text($"\n{player2.Name} won.\nMaybe next time luck will be on your side\n\n");
                else if (player1.Wins.Equals(player2.Wins))
                    Print.Text($"\nFriendly draw\n\n");
            }

            void MainStats()
            {
                Print.Text($"{player1.Name}: {player1.Wins}\n", ConsoleColor.DarkGreen);
                Print.Text($"{player2.Name}: {player2.Wins}\n", ConsoleColor.DarkRed);
                Print.Text($"Draw: {Draw}\n", ConsoleColor.Cyan);
            }
        }

        public static void Judge(Player player1, Player player2)
        {
            if (player1.Choice.Equals(player2.Choice)) Draw++;
            else if (player2.Choice == Item.paper && player1.Choice == Item.rock)
                player1.Won();
            else if (player2.Choice == Item.paper && player1.Choice == Item.scissors)
                player2.Won();
            else if (player2.Choice == Item.rock && player1.Choice == Item.paper)
                player2.Won();
            else if (player2.Choice == Item.rock && player1.Choice == Item.scissors)
                player1.Won();
            else if (player2.Choice == Item.scissors && player1.Choice == Item.rock)
                player2.Won();
            else if (player2.Choice == Item.scissors && player1.Choice == Item.paper)
                player1.Won();

            MatchesPlayed++;
            Print.Text($"\n{Print.PrintItem((int)player1.Choice)}\n   VS\n{Print.PrintItem((int)player2.Choice)}\n");
            ShowStatistics(player1, player2);
            Thread.Sleep(2000);
        }

        public static void ResetStatistics()
        {
            Draw = 0;
            MatchesPlayed = 0;
        }
    }
}
