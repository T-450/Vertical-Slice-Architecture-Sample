namespace VerticalSliceArchitecture.Games.Models
{
    using GameConsoles.Models;

    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int ConsoleId { get; set; }
        public GameConsole Console { get; set; }
    }
}
