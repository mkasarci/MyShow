using System.Text.Json.Serialization;

namespace MyShow.Data.Services.Maze;

public class MazeImage
{
    [JsonPropertyName("medium")]
    public string Uri { get; set; }
}
