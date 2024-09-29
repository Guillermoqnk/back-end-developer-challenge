using AutoMapper;
using Data.Contracts;
using DnDBeyondAPI.Models;
using Dtos;
using Services.Contracts;

namespace Services.Implementations;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Character>> GetCharactersAsync()
    {
        return await _characterRepository.GetCharactersAsync();
    }

    public async Task<Guid> AddCharacter(CharacterDto character)
    {
        return await _characterRepository.AddCharacter(_mapper.Map<Character>(character));
    }
}
