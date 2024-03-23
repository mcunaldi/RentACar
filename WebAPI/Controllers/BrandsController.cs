using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands.Create;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {        
        CreatedBrandResponse response = await Mediator.Send(createBrandCommand);
        return Ok(response);
    }
}
