using MediatR;

namespace RentACar.Application.Features.Brands.Commands.Create;
public class CreateBrandCommand : IRequest<CreatedBrandResponse>
{
    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
            createdBrandResponse.Name = request.Name;
            createdBrandResponse.Id = Guid.NewGuid();
            return null;
        }
    }
}
