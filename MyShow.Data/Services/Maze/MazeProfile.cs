using AutoMapper;
using MyShow.Data.Entities;

namespace MyShow.Data.Services.Maze;

public class MazeProfile : Profile
{
    public MazeProfile()
    {
        CreateMap<MazeEpisode, Episode>()
            .ForMember(destination => destination.Id, option => option.Ignore());
        CreateMap<MazeTvShow, TvShow>()
            .ForMember(destination => destination.Id, option => option.Ignore())
            .ForMember(destination => destination.NextEpisode, option => option.MapFrom(source => source.Embedded.NextEpisode));
    }
}
