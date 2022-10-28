namespace VerticalSliceArchitecture.Consoles.Features.Services
{
    using GameConsoles.Models;

    public interface IConsoleService
    {
        Task<IEnumerable<GameConsole>> GetAllConsolesAsync();
        Task<GameConsole> GetConsoleByIdAsync(int consoleId);
    }
}
