﻿using Dtos;
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
    
    [HttpPut("HealDamage")]
    public async Task<CharacterDto> HealDamage(int healing, Guid targetId)
    {
        return await _combateService.HealDamage(healing, targetId);
    }

    [HttpPut("AddTemporalHitPoints")]
    public async Task<CharacterDto> AddTemporalHitPoints(int temporalHitPoints, Guid targetId)
    {
        return await _combateService.AddTemporalHitPoints(temporalHitPoints, targetId);
    }
}
