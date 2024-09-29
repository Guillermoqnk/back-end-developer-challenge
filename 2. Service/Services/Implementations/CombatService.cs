using AutoMapper;
using Data.Contracts;
using DnDBeyondAPI.Models;
using Dtos;
using Services.Contracts;

namespace Services.Implementations;

public class CombatService : ICombatService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public CombatService(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<CharacterDto> AddTemporalHitPoints(int temp, Guid targetId)
    {
        var target = await _characterRepository.GetCharacterByIdAsync(targetId);
        if (target != null)
        {
            target.TemporaryHitPoints= temp;
            await _characterRepository.UpdateCharacter(target);
            return _mapper.Map<CharacterDto>(target);
        }
        else
            throw new NullReferenceException($"Character with Id {targetId} couldn't be found");
    }

    public async Task<CharacterDto> DealDamage(int damage, Guid targetId)
    {
        var target = await _characterRepository.GetCharacterByIdAsync(targetId);
        if (target != null)
        {
            if ((target.TemporaryHitPoints > 0) && target.TemporaryHitPoints < damage)
            {
                damage -= target.TemporaryHitPoints;
                target.TemporaryHitPoints = 0;
            }
            else
            {
                target.TemporaryHitPoints -= damage;
                damage = 0;
            }

            target.ActualHitPoints = damage > target.ActualHitPoints ? target.ActualHitPoints = 0 : target.ActualHitPoints -= damage;

            await _characterRepository.UpdateCharacter(target);
            return _mapper.Map<CharacterDto>(target);
        }
        else
            throw new NullReferenceException($"Character with Id {targetId} couldn't be found");
    }

    public async Task<CharacterDto> HealDamage(int healing, Guid targetId)
    {
        var target = await _characterRepository.GetCharacterByIdAsync(targetId);
        if(target != null)
        {
            target.ActualHitPoints = target.ActualHitPoints + healing > target.MaxHitPoints ? target.MaxHitPoints : target.ActualHitPoints += healing;

            await _characterRepository.UpdateCharacter(target);
            return _mapper.Map<CharacterDto>(target);
        }
        else
            throw new NullReferenceException($"Character with Id {targetId} couldn't be found");
    }
}
