namespace VerticalSliceArchitecture.Consoles.Dtos
{
    using AutoMapper;
    using MediatR;
    using ServiceManager;

    public class GetAllConsoles
    {
        //Input
        public class GetConsolesQuery : IRequest<IEnumerable<ConsoleResult>> { }

        //Output
        public class ConsoleResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Manufacturer { get; set; }
        }

        //Handler
        public class Handler : IRequestHandler<GetConsolesQuery, IEnumerable<ConsoleResult>>
        {
            private readonly IMapper _mapper;
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager, IMapper mapper)
            {
                _serviceManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ConsoleResult>> Handle(GetConsolesQuery request,
                CancellationToken cancellationToken)
            {
                var consoles = await _serviceManager.Console.GetAllConsolesAsync();
                var results = _mapper.Map<IEnumerable<ConsoleResult>>(consoles);
                return results;
            }
        }
    }
}
