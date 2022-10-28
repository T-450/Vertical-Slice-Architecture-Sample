namespace VerticalSliceArchitecture.Games.Dtos
{
    using AutoMapper;
    using Features.Exceptions;
    using GameConsoles.Models;
    using MediatR;
    using Models;
    using ServiceManager;

    public class AddGameToConsole
    {
        //Input
        public class AddGameCommand : IRequest<GameResult>
        {
            public string Name { get; set; }
            public string Publisher { get; set; }
            public int ConsoleId { get; set; }
        }

        //Output
        public class GameResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
            public int ConsoleId { get; set; }
        }

        //Handler
        public class Handler : IRequestHandler<AddGameCommand, GameResult>
        {
            private readonly IMapper _mapper;
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager, IMapper mapper)
            {
                _serviceManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<GameResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
            {
                GameConsole? console = await _serviceManager.Console.GetConsoleByIdAsync(request.ConsoleId);

                if (console == null)
                {
                    throw new NoConsoleExistsException(request.ConsoleId);
                }

                var game = new Game { Name = request.Name, Publisher = request.Publisher, ConsoleId = request.ConsoleId };

                _serviceManager.Game.AddGameToConsole(request.ConsoleId, game);

                await _serviceManager.SaveAsync();

                var result = _mapper.Map<GameResult>(game);

                return result;
            }
        }
    }
}
