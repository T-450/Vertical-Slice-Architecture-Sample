namespace VerticalSliceArchitecture.Consoles.Features
{
    using AutoMapper;
    using Dtos;
    using GameConsoles.Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GameConsole, GetAllConsoles.ConsoleResult>();
        }
    }
}
