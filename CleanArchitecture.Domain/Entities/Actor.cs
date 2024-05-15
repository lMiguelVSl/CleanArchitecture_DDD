using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class Actor: BaseDomainModel
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public ICollection<Video> Videos { get; set; } = new HashSet<Video>();
}