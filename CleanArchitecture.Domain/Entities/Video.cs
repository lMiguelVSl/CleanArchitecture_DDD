using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

public class Video
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int StreamerId { get; set; }
    public virtual Streamer? Streamer { get; set; }
}