﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionsController : Controller
{
    private readonly IRegionRepository _regionRepository;
    private readonly IMapper _mapper;

    public RegionsController(IRegionRepository regionRepository, IMapper mapper)
    {
        _regionRepository = regionRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRegionsAsync()
    {
        var regions = await _regionRepository.GetAllAsync();

        // return DTO regions
        //var regionsDTO = new List<Models.DTO.Region>();
        //regions.ToList().ForEach(region =>
        //{
        //    var regionDTO = new Models.DTO.Region
        //    {
        //        Id = region.Id,
        //        Name = region.Name,
        //        Code = region.Code,
        //        Area = region.Area,
        //        Lat = region.Lat,
        //        Long = region.Long,
        //        Population = region.Population
        //    };

        //    regionsDTO.Add(regionDTO);
        //});

        var regionsDTO = _mapper.Map<List<Models.DTO.Region>>(regions);

        return Ok(regionsDTO);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("GetRegionAsync")]
    public async Task<IActionResult> GetRegionAsync(Guid id)
    {
        var region = await _regionRepository.GetAsync(id);

        if (region == null)
            return NotFound();

        var regionDTO = _mapper.Map<Models.DTO.Region>(region);

        return Ok(regionDTO);
    }

    [HttpPost]
    public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionrequest)
    {
        // Request to Domain model
        var region = _mapper.Map<Models.Domain.Region>(addRegionrequest);

        // Pass details Repository
        region = await _regionRepository.AddAsync(region);

        // Convert back to DTO
        var regionDTO = _mapper.Map<Models.DTO.Region>(region);

        return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteRegionAsync(Guid id)
    {
        // Get region from database
        var region = await _regionRepository.DeleteAsync(id);

        // If null NotFound
        if (region == null)
            return NotFound();

        // Convert response back to DTO
        var regionDTO = _mapper.Map<Models.DTO.Region>(region);


        // return Ok response
        return Ok(regionDTO);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
    {
        // Convert DTO to Domain model
        var region = _mapper.Map<Models.Domain.Region>(updateRegionRequest);

        // Update Region using repository
        region = await _regionRepository.UpdateAsync(id, region);

        // If Null then NotFound
        if (region == null)
            return NotFound();

        // Convert Domain back to DTO
        var regionDTO = _mapper.Map<Models.DTO.Region>(region);

        // Return Ok response
        return Ok(regionDTO);
    }
}
