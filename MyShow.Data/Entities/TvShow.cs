namespace MyShow.Data.Entities;

public class TvShow
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUri { get; set; }
    public ICollection<Episode> Episodes { get; set; }
    public int ApiId { get; set; }
}