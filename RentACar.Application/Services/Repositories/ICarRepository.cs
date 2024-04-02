using Core.Persistence.Repositories;
using Domain.Entities;

namespace RentACar.Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car, Guid>, IRepository<Car, Guid>
{
}

