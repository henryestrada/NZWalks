using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WalkDifficultiesController : Controller
{
    private readonly IWalkDifficultyRepository _walkDifficultyRepository;
    private readonly IMapper _mapper;

    public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
    {
        _walkDifficultyRepository = walkDifficultyRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWalkDifficultiesAsync()
    {
        var walkDifficulties = await _walkDifficultyRepository.GetAllAsync();

        var walkDifficultiesDTO = _mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulties);

        return Ok(walkDifficultiesDTO);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("GetWalkDifficultyAsync")]
    public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
    {
        var walkDifficulty = await _walkDifficultyRepository.GetAsync(id);

        if (walkDifficulty == null) return NotFound();

        var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

        return Ok(walkDifficultyDTO);
    }

    [HttpPost]
    public async Task<IActionResult> AddWalkDifficultyAsync([FromBody] Models.DTO.AddWalkDifficultyRequest addWalkDifficultyrequest)
    {
        // Request to Domain model
        var walkDifficulty = new Models.Domain.WalkDifficulty
        {
            Code = addWalkDifficultyrequest.Code
        };

        // Pass details Repository
        walkDifficulty = await _walkDifficultyRepository.AddAsync(walkDifficulty);

        // Convert back to DTO
        var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

        return CreatedAtAction(nameof(GetWalkDifficultyAsync), new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid id)
    {
        // Get walkDifficulty from database
        var walkDifficulty = await _walkDifficultyRepository.DeleteAsync(id);

        // If null NotFound
        if (walkDifficulty == null)
            return NotFound();

        // Convert response back to DTO
        var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);


        // return Ok response
        return Ok(walkDifficultyDTO);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
    {
        // Convert DTO to Domain model
        var walkDifficulty = new Models.Domain.WalkDifficulty
        {
            Code = updateWalkDifficultyRequest.Code
        };

        // Update WalkDifficulty using repository
        walkDifficulty = await _walkDifficultyRepository.UpdateAsync(id, walkDifficulty);

        // If Null then NotFound
        if (walkDifficulty == null)
            return NotFound();

        // Convert Domain back to DTO
        var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

        // Return Ok response
        return Ok(walkDifficultyDTO);
    }
}
