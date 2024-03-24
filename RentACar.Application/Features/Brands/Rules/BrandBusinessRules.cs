using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using RentACar.Application.Features.Brands.Constants;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Rules;
public class BrandBusinessRules(IBrandRepository brandRepository) : BaseBusinessRules
{
    public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
    {
        Brand? result = await brandRepository.GetAsync(predicate: b=> b.Name.ToLower() == name.ToLower());

        if (result != null)
        {
            throw new BusinessException(BrandsMessages.BrandNameExists);
        }
    }
}
