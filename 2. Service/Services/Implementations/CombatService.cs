using AutoMapper;
using Data.Contracts;
using DnDBeyondAPI.Models;
using Dtos;
using Services.Contracts;

namespace Services.Implementations;

public class CombatService : ICombatService
{
    private readonly ICharacterRepository _characterRepositorty;
    private readonly IMapper _mapper;

    public CombatService(ICharacterRepository characterRepositorty, IMapper mapper)
    {
        _characterRepositorty = characterRepositorty;
        _mapper = mapper;
    }

    public async Task<CharacterDto> DealDamage(int damage, Guid targetId)
    {
        var target = await _characterRepositorty.GetCharacterByIdAsync(targetId);
        if (target != null)
        {
            if ((target.TemporaryHitPoints != 0) && (target.TemporaryHitPoints < damage))
            {
                target.TemporaryHitPoints = 0;
                damage -= target.TemporaryHitPoints;
                target.ActualHitPoints = damage > target.ActualHitPoints ? target.ActualHitPoints = 0 : target.ActualHitPoints -= damage;
            }
            else
            {
                target.TemporaryHitPoints -= damage;
            }

            await _characterRepositorty.UpdateCharacter(target);
            return _mapper.Map<CharacterDto>(target);
        }
        else
            throw new NullReferenceException($"Character with Id {targetId} couldn't be found");
    }
}
