using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class Video: BaseDomainModel
{
    public string? Name { get; set; }
    public int StreamerId { get; set; }
    public virtual Streamer? Streamer { get; set; }
    public virtual ICollection<Actor> Actors { get; set; } = new HashSet<Actor>();
    public virtual Director Director { get; set; }
}