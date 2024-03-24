using Core.Persistance.Repositories;
using Domain.Entities;
using RentACar.Application.Services.Repositories;
using RentACar.Persistance.Contexts;

namespace RentACar.Persistance.Repositories;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }
}


