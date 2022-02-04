namespace MyShow.Data.Entities;

public class TvShow
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public List<Episode> Episodes { get; set; }
}