using DnDBeyondAPI.Models;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DnDBeyondAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ILogger<CharacterController> _logger;
    private readonly ICharacterService _characterService;

    public CharacterController(ILogger<CharacterController> logger, ICharacterService characterService)
    {
        _logger = logger;
        _characterService = characterService;
    }

    [HttpGet("GetAllCharacters")]
    public async Task<IActionResult> GetCharactersAsync()
    {
        var result = await _characterService.GetCharactersAsync();
        return Ok(result);
    }

    [HttpPost("AddCharacter")]
    public async Task<IActionResult> AddCharacter(CharacterDto character)
    {
        return Ok(await _characterService.AddCharacter(character));
    }
}