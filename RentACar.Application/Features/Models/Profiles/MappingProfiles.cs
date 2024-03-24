using AutoMapper;
using Core.Application.Responses;
using Core.Persistance.Paging;
using RentACar.Application.Features.Models.Queries.GetList;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, GetListModelListItemDto>().ReverseMap();

        CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();
    }
}


//Dto nesnesinde BrandName olarak belirttiğimiz için aşağıdaki kod ihtiyaç kalmadı. Otomatik maplendi
/*
 CreateMap<Model, GetListModelListItemDto>()
            .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name))
            .ReverseMap(); 
 */