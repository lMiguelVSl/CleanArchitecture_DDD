using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class Director: BaseDomainModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
}