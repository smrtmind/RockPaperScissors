using System;

namespace GameRockPaperScissors
{
    public class Print
    {
        public static void Text(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string Rock()
        {
            return @"    __   " + "\n" +
                   @"   / _\_ " + "\n" +
                   @"  | .  .\" + "\n" +
                   @"  /  \ _/" + "\n" +
                   @"  \_|_/  " + "\n";
        }

        public static string Scissors()
        {
            return @"      " + "\n" +
                   @"  \  /" + "\n" +
                   @"   \/ " + "\n" +
                   @"   /\ " + "\n" +
                   @"  O  O" + "\n";
        }

        public static string Paper()
        {
            return @" ______" + "\n" +
                   @" |....|" + "\n" +
                   @" |....|" + "\n" +
                   @" |....|" + "\n" + 
                   @" |____|" + "\n";
        }

        public static void RockScissorsPaper()
        {
            Text(@"    __           " + @"            " + @"______" + "\n" +
                 @"   / _\_         " + @"\  /        " + @"|....|" + "\n" +
                 @"  | .  .\        " + @" \/         " + @"|....|" + "\n" +
                 @"  /  \ _/        " + @" /\         " + @"|....|" + "\n" +
                 @"  \_|_/          " + @"O  O        " + @"|____|" + "\n", ConsoleColor.DarkYellow);
        }

        public static string PrintItem(int choice)
        {
            if (choice == 1) return Rock();
            if (choice == 2) return Scissors();
            else return Paper();
        }
    }
}
