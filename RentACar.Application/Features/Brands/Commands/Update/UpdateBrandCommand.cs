using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Commands.Update;
public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBrands";
    public class UpdatedBrandCommandHandler(
        IBrandRepository brandRepository,
        IMapper mapper) : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            brand = mapper.Map(request, brand);

            await brandRepository.UpdateAsync(brand);

            UpdatedBrandResponse response = mapper.Map<UpdatedBrandResponse>(brand);
            return response;
        }
    }
}
