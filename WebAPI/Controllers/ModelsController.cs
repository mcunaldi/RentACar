using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Models.Queries.GetList;
using RentACar.Application.Features.Models.Queries.GetListByDynamic;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModelQuery getListBrandQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListModelListItemDto> response = await Mediator.Send(getListBrandQuery);
        return Ok(response);
    }

    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery = null)
    {
        GetListByDynamicModelQuery getListByDynamicModelQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(getListByDynamicModelQuery);
        return Ok(response);
    }
}
