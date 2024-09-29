using DnDBeyondAPI.Models;

namespace Data.Contracts;

public interface ICharacterRepository
{
    Task<IEnumerable<Character>> GetCharactersAsync();
    Task<Guid> AddCharacter(Character chara);
}
