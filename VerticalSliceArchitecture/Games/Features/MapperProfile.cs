namespace VerticalSliceArchitecture.Games.Features
{
    using AutoMapper;
    using Dtos;
    using Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Game, AddGameToConsole.GameResult>();
            CreateMap<Game, GetAllGamesForConsole.GameResult>();
            CreateMap<Game, UpdateGameForConsole.UpdateGameResult>();
        }
    }
}
