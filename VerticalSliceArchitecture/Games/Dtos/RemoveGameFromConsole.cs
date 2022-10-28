namespace VerticalSliceArchitecture.Games.Dtos
{
    using Domain;
    using Features.Exceptions;
    using MediatR;
    using Models;
    using ServiceManager;

    public class RemoveGameFromConsole
    {
        public class RemoveGameCommand : IRequest<Unit>
        {
            public int ConsoleId { get; set; }
            public int GameId { get; set; }
        }

        public class Handler : IRequestHandler<RemoveGameCommand, Unit>
        {
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

            public async Task<Unit> Handle(RemoveGameCommand request, CancellationToken cancellationToken)
            {
                GameConsole? console = await _serviceManager.Console.GetConsoleByIdAsync(request.ConsoleId);

                if (console == null)
                {
                    throw new NoConsoleExistsException(request.ConsoleId);
                }

                Game? game = await _serviceManager.Game.GetGameAsync(request.ConsoleId, request.GameId);

                if (game == null)
                {
                    throw new NoGameExistsException(request.ConsoleId, request.GameId);
                }

                _serviceManager.Game.DeleteGame(game);

                await _serviceManager.SaveAsync();

                return Unit.Value;
            }
        }
    }
}
