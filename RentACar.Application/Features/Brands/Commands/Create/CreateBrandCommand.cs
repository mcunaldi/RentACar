using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using RentACar.Application.Features.Brands.Rules;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Commands.Create;
public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string Name { get; set; }
    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBrands";

    public class CreateBrandCommandHandler(
        IBrandRepository brandRepository,
        IMapper mapper,
        BrandBusinessRules brandBusinessRules) : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

            Brand brand = mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();

            await brandRepository.AddAsync(brand);
            //await brandRepository.AddAsync(brand);

            CreatedBrandResponse createdBrandResponse = mapper.Map<CreatedBrandResponse>(brand);
            return createdBrandResponse;
        }
    }
}
