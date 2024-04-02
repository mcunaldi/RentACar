using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using RentACar.Application.Services.Repositories;

namespace RentACar.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context)
        : base(context) { }
}

