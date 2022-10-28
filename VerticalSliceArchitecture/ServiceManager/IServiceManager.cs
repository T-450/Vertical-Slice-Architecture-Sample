namespace VerticalSliceArchitecture.ServiceManager
{
    using Consoles.Features.Services;
    using Games.Features.Services;

    public interface IServiceManager
    {
        IConsoleService Console { get; }
        IGameService Game { get; }
        Task SaveAsync();
    }
}
