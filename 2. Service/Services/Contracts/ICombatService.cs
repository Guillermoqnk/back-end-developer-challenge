using DnDBeyondAPI.Models;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICombatService
    {
        public Task<CharacterDto> DealDamage(int damage, Guid targetId);
        public Task<CharacterDto> HealDamage(int healing, Guid targetid);
        public Task<CharacterDto> AddTemporalHitPoints(int temp, Guid targetId);
    }
}
