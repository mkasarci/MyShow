using System.Text.Json.Serialization;

namespace MyShow.Data.Services.Maze;

public class MazeTvShow
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public MazeImage Image { get; set; }

    [JsonPropertyName("_embedded")]
    public MazeEmbedded Embedded { get; set; }
}
