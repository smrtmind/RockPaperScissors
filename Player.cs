namespace GameRockPaperScissors
{
    public class Player
    {
        public string Name { get; private set; }
        public Item Choice { get; private set; }

        public Player(string name) => Name = name;

        public void PlayerChoice(Item choice) => Choice = choice;
    }
}
