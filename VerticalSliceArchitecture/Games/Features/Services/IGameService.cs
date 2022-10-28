namespace VerticalSliceArchitecture.Games.Features.Services
{
    using Models;

    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllGamesAsync(int consoleId);
        Task<Game> GetGameAsync(int consoleId, int gameId);
        void AddGameToConsole(int consoleId, Game game);
        void DeleteGame(Game game);
    }
}
