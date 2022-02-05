using AutoMapper;
using MyShow.Data.Services.Maze;

namespace MyShow.Data;

public class ObjectMapper
{
    private static readonly Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<MazeProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper => mapper.Value;
}
