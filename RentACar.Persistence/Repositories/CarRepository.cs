using Core.Persistence.Repositories;
using Domain.Entities;
using RentACar.Application.Services.Repositories;
using Persistence.Contexts;

namespace RentACar.Persistence.Repositories;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }
}


