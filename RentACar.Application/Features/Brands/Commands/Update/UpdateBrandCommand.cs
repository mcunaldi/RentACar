using AutoMapper;
using MediatR;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Commands.Update;
public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
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
