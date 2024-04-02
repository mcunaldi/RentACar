using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Queries.GetList;
public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListBrandQuery({PageRequest.PageIndex}, {PageRequest.PageSize})";

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetBrands";

    public class GetListBrandQueryHandler(
        IBrandRepository brandRepository,
        IMapper mapper) : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
    {
        public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            Paginate<Brand> brands = await brandRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true);

            GetListResponse<GetListBrandListItemDto> response = mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
            return response;
        }
    }
}
