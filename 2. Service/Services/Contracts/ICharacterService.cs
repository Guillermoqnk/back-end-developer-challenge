using DnDBeyondAPI.Models;
using Dtos;

namespace Services.Contracts;

public interface ICharacterService
{
    Task<IEnumerable<Character>> GetCharactersAsync();
    Task<Guid> AddCharacter(CharacterDto chara);
}
