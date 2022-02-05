using AutoMapper;
using MyShow.Data.Entities;

namespace MyShow.Data.Services.Maze;

public class MazeProfile : Profile
{
    public MazeProfile()
    {
        CreateMap<MazeEpisode, Episode>();
        CreateMap<MazeTvShow, TvShow>();
    }
}
