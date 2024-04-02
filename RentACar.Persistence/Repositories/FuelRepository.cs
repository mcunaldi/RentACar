using Core.Persistence.Repositories;
using Persistence.Contexts;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Persistence.Repositories;

public class FuelRepository : EfRepositoryBase<Fuel, Guid, BaseDbContext>, IFuelRepository
{
    public FuelRepository(BaseDbContext context) : base(context)
    {
    }
}


