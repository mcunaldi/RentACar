using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using RentACar.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Core.Persistance.Paging;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Queries.GetList;
public class GetListModelQuery : IRequest<GetListResponse<GetListModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListModelQueryHandler(
        IModelRepository modelRepository,
        IMapper mapper) : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelListItemDto>>
    {
        public async Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> models = await modelRepository.GetListAsync(
                include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
                );

            var response = mapper.Map<GetListResponse<GetListModelListItemDto>>(models);

            return response;
        }
    }
}
