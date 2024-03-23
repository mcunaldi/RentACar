using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Paging;
using MediatR;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Queries.GetList;
public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBrandQueryHandler(
        IBrandRepository brandRepository,
        IMapper mapper) : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
    {
        public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            Paginate<Brand> brands =  await brandRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true);

            GetListResponse<GetListBrandListItemDto> response = mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
            return response;
        }
    }
}
