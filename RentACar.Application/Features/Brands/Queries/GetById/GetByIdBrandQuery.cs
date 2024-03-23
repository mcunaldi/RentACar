using AutoMapper;
using MediatR;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Queries.GetById;
public class GetByIdBrandQuery : IRequest<GetByIdBrandResponse>
{
    public Guid Id { get; set; }

    public class GetByIdBrandQueryHandler(
        IBrandRepository brandRepository,
        IMapper mapper) : IRequestHandler<GetByIdBrandQuery, GetByIdBrandResponse>
    {
        public async Task<GetByIdBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            Brand? brand = await brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken, withDeleted: true);
            
            GetByIdBrandResponse response = mapper.Map<GetByIdBrandResponse>(brand);
            return response;
        }
    }
}

