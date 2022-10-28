namespace VerticalSliceArchitecture.Games.Dtos
{
    using AutoMapper;
    using Domain;
    using Features.Exceptions;
    using MediatR;
    using Models;
    using ServiceManager;

    public class UpdateGameForConsole
    {
        public class UpdateGameCommand : IRequest<Unit>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
            public int ConsoleId { get; set; }
        }

        public class UpdateGameResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
            public int ConsoleId { get; set; }
        }

        public class Handler : IRequestHandler<UpdateGameCommand>
        {
            private readonly IMapper _mapper;
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager, IMapper mapper)
            {
                _serviceManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
            {
                GameConsole? console = await _serviceManager.Console.GetConsoleByIdAsync(request.ConsoleId);

                if (console == null)
                {
                    throw new NoConsoleExistsException(request.ConsoleId);
                }

                Game? game = await _serviceManager.Game.GetGameAsync(request.ConsoleId, request.Id);

                if (game == null)
                {
                    throw new NoGameExistsException(request.ConsoleId, request.Id);
                }

                game.Name = request.Name;
                game.Publisher = request.Publisher;

                await _serviceManager.SaveAsync();

                return Unit.Value;
            }
        }
    }
}
