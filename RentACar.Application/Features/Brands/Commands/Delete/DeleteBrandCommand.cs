using AutoMapper;
using MediatR;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Commands.Delete;
public class DeleteBrandCommand : IRequest<DeletedBrandResponse> //softDelete
{
    public Guid Id { get; set; }

    public class DeleteBrandCommandHandler(
        IBrandRepository brandRepository,
        IMapper mapper) : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
    {
        public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            await brandRepository.DeleteAsync(brand);

            DeletedBrandResponse response = mapper.Map<DeletedBrandResponse>(brand);
            return response;
        }
    }
}
