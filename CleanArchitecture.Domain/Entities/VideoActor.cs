using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class VideoActor : BaseDomainModel
{
    public int ActorId { get; set; }
    public int VideoId { get; set; }
}