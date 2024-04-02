using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using RentACar.Application.Services.Repositories;

namespace RentACar.Persistence.Repositories;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, int, BaseDbContext>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(BaseDbContext context)
        : base(context) { }
}

