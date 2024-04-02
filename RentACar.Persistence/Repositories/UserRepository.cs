using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using RentACar.Application.Services.Repositories;

namespace RentACar.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context)
        : base(context) { }
}

