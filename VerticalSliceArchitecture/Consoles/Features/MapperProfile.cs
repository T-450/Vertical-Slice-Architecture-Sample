namespace VerticalSliceArchitecture.Consoles.Features
{
    using AutoMapper;
    using Domain;
    using Dtos;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GameConsole, GetAllConsoles.ConsoleResult>();
        }
    }
}
