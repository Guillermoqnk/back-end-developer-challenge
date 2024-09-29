using Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Implementations;

namespace DnDBeyondAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CombatController : ControllerBase
{
    private readonly ICombatService _combateService;

    public CombatController(ICombatService combatService)
    {
        _combateService= combatService;
    }

    [HttpPut("DealDamage")]
    public async Task<CharacterDto> DealDamage(int damage, Guid targetId)
    {
        return await _combateService.DealDamage(damage, targetId);
    }
}
