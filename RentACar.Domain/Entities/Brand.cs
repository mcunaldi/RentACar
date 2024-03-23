using Core.Persistance.Repositories;

namespace RentACar.Domain.Entities;
public class Brand : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public Brand()
    {
        
    }

    public Brand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
