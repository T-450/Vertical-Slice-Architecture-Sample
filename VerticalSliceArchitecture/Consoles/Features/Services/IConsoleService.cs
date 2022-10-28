namespace VerticalSliceArchitecture.Consoles.Features.Services
{
    using Domain;

    public interface IConsoleService
    {
        Task<IEnumerable<GameConsole>> GetAllConsolesAsync();
        Task<GameConsole> GetConsoleByIdAsync(int consoleId);
    }
}
