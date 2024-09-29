using Data.Contracts;
using DnDBeyondAPI;
using DnDBeyondAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly DnDContext _context;

    public CharacterRepository(DnDContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Character>> GetCharactersAsync()
    {
        return await _context.Characters
            .Include(x => x.Classes)
            .ToListAsync();
    }

    public async Task<Guid> AddCharacter(Character chara)
    {
        using (var dbContextTransaction = _context.Database.BeginTransaction())
        {

            var result = await _context.Characters.AddAsync(chara).ConfigureAwait(false);

            await dbContextTransaction.CommitAsync();
            _context.SaveChanges();

            if (result != null)
                return result.Entity.Id;
            else return Guid.Empty;
        }
    }
}
