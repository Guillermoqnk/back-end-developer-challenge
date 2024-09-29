using DnDBeyondAPI.Models;

namespace Data.Contracts;

public interface ICharacterRepository
{
    Task<IEnumerable<Character>> GetCharactersAsync();
    Task<Character?> GetCharacterByIdAsync(Guid id);
    Task<Guid> AddCharacter(Character character);
    Task<bool> UpdateCharacter(Character character);
}
