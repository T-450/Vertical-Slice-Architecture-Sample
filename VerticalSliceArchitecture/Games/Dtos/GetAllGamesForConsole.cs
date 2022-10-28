namespace VerticalSliceArchitecture.Games.Dtos
{
    using AutoMapper;
    using Features.Exceptions;
    using GameConsoles.Models;
    using MediatR;
    using ServiceManager;

    public class GetAllGamesForConsole
    {
        public class GetGamesQuery : IRequest<IEnumerable<GameResult>>
        {
            public int ConsoleId { get; set; }
        }

        public class GameResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
        }

        public class Handler : IRequestHandler<GetGamesQuery, IEnumerable<GameResult>>
        {
            private readonly IMapper _mapper;
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager, IMapper mapper)
            {
                _serviceManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GameResult>> Handle(GetGamesQuery request,
                CancellationToken cancellationToken)
            {
                GameConsole? console = await _serviceManager.Console.GetConsoleByIdAsync(request.ConsoleId);

                if (console == null)
                {
                    throw new NoConsoleExistsException(request.ConsoleId);
                }

                var games = await _serviceManager.Game.GetAllGamesAsync(console.Id);

                var result = _mapper.Map<IEnumerable<GameResult>>(games);

                return result;
            }
        }
    }
}
