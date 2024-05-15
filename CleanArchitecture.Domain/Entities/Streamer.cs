using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class Streamer: BaseDomainModel
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public List<Video>? Videos { get; set; }
}