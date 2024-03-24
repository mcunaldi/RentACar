using AutoMapper;
using MediatR;
using RentACar.Application.Features.Brands.Rules;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Commands.Create;
public class CreateBrandCommand : IRequest<CreatedBrandResponse>
{
    public string Name { get; set; }

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

            CreatedBrandResponse createdBrandResponse = mapper.Map<CreatedBrandResponse>(brand);
            return createdBrandResponse;
        }
    }
}
