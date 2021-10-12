using System;
using System.Threading;

namespace GameRockPaperScissors
{
    public class Arbitrator
    {
        public static int Draw { get; private set; }
        public static int MatchesPlayed { get; private set; }
        public static int P1win { get; private set; }
        public static int P2win { get; private set; }

        public static void Judge(Player player1, Player player2)
        {
            if (player1.Choice.Equals(player2.Choice)) Draw++;
            else if (player2.Choice == Item.paper && player1.Choice == Item.rock) P1win++;
            else if (player2.Choice == Item.paper && player1.Choice == Item.scissors) P2win++;
            else if (player2.Choice == Item.rock && player1.Choice == Item.paper) P2win++;
            else if (player2.Choice == Item.rock && player1.Choice == Item.scissors) P1win++;
            else if (player2.Choice == Item.scissors && player1.Choice == Item.rock) P2win++;
            else if (player2.Choice == Item.scissors && player1.Choice == Item.paper) P1win++;

            MatchesPlayed++;
            Print.Text($"\n{Print.PrintItem((int)player1.Choice)}\n   VS\n{Print.PrintItem((int)player2.Choice)}\n");
            ShowStatistics(player1, player2);
            Thread.Sleep(2000);
        }

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

                if (P1win > P2win)
                    Print.Text($"\nYou won, congradulations!\n\n");
                else if (P1win < P2win)
                    Print.Text($"\n{player2.Name} won.\nMaybe next time luck will be on your side\n\n");
                else if (P1win.Equals(P2win))
                    Print.Text($"\nFriendly draw\n\n");
            }

            void MainStats()
            {
                Print.Text($"{player1.Name}: {P1win}\n", ConsoleColor.DarkGreen);
                Print.Text($"{player2.Name}: {P2win}\n", ConsoleColor.DarkRed);
                Print.Text($"Draw: {Draw}\n", ConsoleColor.Cyan);
            }
        }

        public static void ResetStatistics()
        {
            Draw = 0;
            MatchesPlayed = 0;
            P1win = 0;
            P2win = 0;
        }
    }
}
