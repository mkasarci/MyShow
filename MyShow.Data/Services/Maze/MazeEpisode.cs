using System.Text.Json.Serialization;

namespace MyShow.Data.Services.Maze;

public class MazeEpisode
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Season { get; set; }
    public int Number { get; set; }

    [JsonPropertyName("airstamp")]
    public DateTime AirDate { get; set; }
}
