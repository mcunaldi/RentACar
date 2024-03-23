﻿using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands.Create;
using RentACar.Application.Features.Brands.Commands.Update;
using RentACar.Application.Features.Brands.Queries.GetById;
using RentACar.Application.Features.Brands.Queries.GetList;

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

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(getListBrandQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
        GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandResponse response = await Mediator.Send(updateBrandCommand);
        return Ok(response);
    }
}
