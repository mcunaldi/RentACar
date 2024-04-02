using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using RentACar.Application.Services.Repositories;

namespace RentACar.Persistence.Repositories;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, int, BaseDbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(BaseDbContext context)
        : base(context) { }
}

