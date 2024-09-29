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

    public async Task<Guid> AddCharacter(Character character)
    {
        using (var dbContextTransaction = _context.Database.BeginTransaction())
        {

            var result = await _context.Characters.AddAsync(character).ConfigureAwait(false);

            await dbContextTransaction.CommitAsync();
            _context.SaveChanges();

            if (result != null)
                return result.Entity.Id;
            else return Guid.Empty;
        }
    }

    public async Task<Character?> GetCharacterByIdAsync(Guid id)
    {
        return await _context.Characters.Where(cha => cha.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateCharacter(Character character)
    {
        var entity =  await _context.Characters.SingleAsync(c => c.Id == character.Id);

        entity = character;

        _context.SaveChanges();

        return true;

    }
}
